using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Veldrid.Utilities
{
    /// <summary>
    /// A parser for Wavefront MTL files.
    /// </summary>
    public class MtlParser
    {
        public static readonly string[] s_newline = new string[] { "\n" };

        public readonly ParseContext _pc = new ParseContext();

        /// <summary>
        /// Parses a <see cref="MtlFile"/> from the given array of text lines.
        /// </summary>
        /// <param name="lines">The raw text lines of the MTL file.</param>
        /// <returns>A new <see cref="MtlFile"/>.</returns>
        public MtlFile Parse(string[] lines)
        {
            foreach (string line in lines)
            {
                _pc.Process(line);
            }
            _pc.EndOfFileReached();

            return _pc.FinalizeFile();
        }

        /// <summary>
        /// Parses a <see cref="MtlFile"/> from the given stream
        /// </summary>
        /// <param name="s">The stream to parse from.</param>
        /// <returns>A new <see cref="MtlFile"/>.</returns>
        public MtlFile Parse(Stream s)
        {
            string text;
            using (StreamReader sr = new StreamReader(s))
            {
                text = sr.ReadToEnd();
            }

            int lineStart = 0;
            int lineEnd = -1;
            while ((lineEnd = text.IndexOf('\n', lineStart)) != -1)
            {
                string line;

                if (lineEnd != 0 && text[lineEnd - 1] == '\r')
                {
                    line = text.Substring(lineStart, lineEnd - lineStart - 1);
                }
                else
                {
                    line = text.Substring(lineStart, lineEnd - lineStart);
                }

                _pc.Process(line);
                lineStart = lineEnd + 1;
            }

            _pc.EndOfFileReached();
            return _pc.FinalizeFile();
        }

        public class ParseContext
        {
            public static readonly char[] s_whitespaceChars = new char[] { ' ' };

            public readonly List<MaterialDefinition> _definitions = new List<MaterialDefinition>();
            public MaterialDefinition _currentDefinition;

            public int _currentLine;
            public string _currentLineText;

            public void Process(string line)
            {
                _currentLine++;
                _currentLineText = line;

                string[] pieces = line.Split(s_whitespaceChars, StringSplitOptions.RemoveEmptyEntries);
                if (pieces.Length == 0 || pieces[0].StartsWith("#"))
                {
                    return;
                }
                switch (pieces[0].ToLowerInvariant().Trim())
                {
                    case "newmtl":
                        ExpectExactly(pieces, 1, "newmtl");
                        FinalizeCurrentMaterial();
                        _currentDefinition = new MaterialDefinition(pieces[1]);
                        break;
                    case "ka":
                        ExpectExactly(pieces, 3, "Ka");
                        _currentDefinition.AmbientReflectivity = ParseVector3(pieces[1], pieces[2], pieces[3], "Ka");
                        break;
                    case "kd":
                        ExpectExactly(pieces, 3, "Kd");
                        _currentDefinition.DiffuseReflectivity = ParseVector3(pieces[1], pieces[2], pieces[3], "Kd");
                        break;
                    case "ks":
                        ExpectExactly(pieces, 3, "Ks");
                        _currentDefinition.SpecularReflectivity = ParseVector3(pieces[1], pieces[2], pieces[3], "Ks");
                        break;
                    case "ke": // Non-standard?
                        ExpectExactly(pieces, 3, "Ke");
                        _currentDefinition.EmissiveCoefficient = ParseVector3(pieces[1], pieces[2], pieces[3], "Ks");
                        break;
                    case "tf":
                        ExpectExactly(pieces, 3, "Tf");
                        _currentDefinition.TransmissionFilter = ParseVector3(pieces[1], pieces[2], pieces[3], "Tf");
                        break;
                    case "illum":
                        ExpectExactly(pieces, 1, "illum");
                        _currentDefinition.IlluminationModel = ParseInt(pieces[1], "illum");
                        break;
                    case "d": // "Dissolve", or opacity
                        ExpectExactly(pieces, 1, "d");
                        _currentDefinition.Opacity = ParseFloat(pieces[1], "d");
                        break;
                    case "tr": // Transparency
                        ExpectExactly(pieces, 1, "Tr");
                        _currentDefinition.Opacity = 1 - ParseFloat(pieces[1], "Tr");
                        break;
                    case "ns":
                        ExpectExactly(pieces, 1, "Ns");
                        _currentDefinition.SpecularExponent = ParseFloat(pieces[1], "Ns");
                        break;
                    case "sharpness":
                        ExpectExactly(pieces, 1, "sharpness");
                        _currentDefinition.Sharpness = ParseFloat(pieces[1], "sharpness");
                        break;
                    case "ni": // "Index of refraction"
                        ExpectExactly(pieces, 1, "Ni");
                        _currentDefinition.OpticalDensity = ParseFloat(pieces[1], "Ni");
                        break;
                    case "map_ka":
                        ExpectExactly(pieces, 1, "map_ka");
                        _currentDefinition.AmbientTexture = pieces[1];
                        break;
                    case "map_kd":
                        ExpectExactly(pieces, 1, "map_kd");
                        _currentDefinition.DiffuseTexture = pieces[1];
                        break;
                    case "map_ks":
                        ExpectExactly (pieces, 1, "map_ks");
                        _currentDefinition.SpecularColorTexture = pieces [1];
                        break;
                    case "map_bump":
                    case "bump":
                        ExpectExactly(pieces, 1, "map_bump");
                        _currentDefinition.BumpMap = pieces[1];
                        break;
                    case "map_d":
                        ExpectExactly(pieces, 1, "map_d");
                        _currentDefinition.AlphaMap = pieces[1];
                        break;
                    case "map_ns":
                        ExpectExactly(pieces, 1, "map_ns");
                        _currentDefinition.SpecularHighlightTexture = pieces[1];
                        break;


                    default:
                        throw new ObjParseException(
                            string.Format("An unsupported line-type specifier, '{0}', was used on line {1}, \"{2}\"",
                            pieces[0],
                            _currentLine,
                            _currentLineText));
                }
            }

            public void FinalizeCurrentMaterial()
            {
                if (_currentDefinition != null)
                {
                    _definitions.Add(_currentDefinition);
                    _currentDefinition = null;
                }
            }

            public void EndOfFileReached()
            {
                FinalizeCurrentMaterial();
            }

            public MtlFile FinalizeFile()
            {
                return new MtlFile(_definitions);
            }

            public Vector3 ParseVector3(string xStr, string yStr, string zStr, string location)
            {
                try
                {
                    float x = float.Parse(xStr, CultureInfo.InvariantCulture);
                    float y = float.Parse(yStr, CultureInfo.InvariantCulture);
                    float z = float.Parse(zStr, CultureInfo.InvariantCulture);

                    return new Vector3(x, y, z);
                }
                catch (FormatException fe)
                {
                    throw CreateParseException(location, fe);
                }
            }

            public Vector2 ParseVector2(string xStr, string yStr, string location)
            {
                try
                {
                    float x = float.Parse(xStr, CultureInfo.InvariantCulture);
                    float y = float.Parse(yStr, CultureInfo.InvariantCulture);

                    return new Vector2(x, y);
                }
                catch (FormatException fe)
                {
                    throw CreateParseException(location, fe);
                }
            }

            public int ParseInt(string intStr, string location)
            {
                try
                {
                    int i = int.Parse(intStr, CultureInfo.InvariantCulture);
                    return i;
                }
                catch (FormatException fe)
                {
                    throw CreateParseException(location, fe);
                }
            }

            public float ParseFloat(string intStr, string location)
            {
                try
                {
                    float f = float.Parse(intStr, CultureInfo.InvariantCulture);
                    return f;
                }
                catch (FormatException fe)
                {
                    throw CreateParseException(location, fe);
                }
            }

            public void ExpectExactly(string[] pieces, int count, string name)
            {
                if (pieces.Length != count + 1)
                {
                    string message = string.Format(
                        "Expected exactly {0} components to a line starting with {1}, on line {2}, \"{3}\".",
                        count,
                        name,
                        _currentLine,
                        _currentLineText);
                    throw new MtlParseException(message);
                }
            }

            public void ExpectAtLeast(string[] pieces, int count, string name)
            {
                if (pieces.Length < count + 1)
                {
                    string message = string.Format(
                        "Expected at least {0} components to a line starting with {1}, on line {2}, \"{3}\".",
                        count,
                        name,
                        _currentLine,
                        _currentLineText);
                    throw new MtlParseException(message);
                }
            }

            public MtlParseException CreateParseException(string location, Exception e)
            {
                string message = string.Format("An error ocurred while parsing {0} on line {1}, \"{2}\"", location, _currentLine, _currentLineText);
                return new MtlParseException(message, e);
            }
        }
    }

    public class MtlParseException : Exception
    {
        public MtlParseException(string message) : base(message)
        {
        }

        public MtlParseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents a parsed MTL definition file.
    /// </summary>
    public class MtlFile
    {
        /// <summary>
        /// Gets a mapping of all <see cref="MaterialDefinition"/>s contained in this <see cref="MtlFile"/>.
        /// </summary>
        public IReadOnlyDictionary<string, MaterialDefinition> Definitions { get; }

        /// <summary>
        /// Constructs a new <see cref="MtlFile"/> from pre-parsed material definitions.
        /// </summary>
        /// <param name="definitions">A collection of material definitions.</param>
        public MtlFile(IEnumerable<MaterialDefinition> definitions)
        {
            Definitions = definitions.ToDictionary(def => def.Name);
        }
    }

    /// <summary>
    /// An individual material definition from a Wavefront MTL file.
    /// </summary>
    public class MaterialDefinition
    {
        public MaterialDefinition(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public Vector3 AmbientReflectivity { get; set; }
        public Vector3 DiffuseReflectivity { get; set; }
        public Vector3 SpecularReflectivity { get; set; }
        public Vector3 EmissiveCoefficient { get; set; }
        public Vector3 TransmissionFilter { get; set; }
        public int IlluminationModel { get; set; }
        public float Opacity { get; set; }
        public float Transparency => 1 - Opacity;
        public float SpecularExponent { get; set; }
        public float Sharpness { get; set; }
        public float OpticalDensity { get; set; }

        public string AmbientTexture { get; set; }
        public string DiffuseTexture { get; set; }
        public string SpecularColorTexture { get; set; }
        public string SpecularHighlightTexture { get; set; }
        public string AlphaMap { get; set; }
        public string BumpMap { get; set; }
        public string DisplacementMap { get; set; }
        public string StencilDecalTexture { get; set; }
    }
}