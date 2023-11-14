using System.Numerics;

namespace Veldrid.NeoDemo
{
    public struct PointLightInfo
    {
        public Vector3 Position;
#pragma warning disable 0169
        public float _padding0;
#pragma warning restore 0169
        public Vector3 Color;
        public float _padding1;
        public float Range;
#pragma warning disable 0169
        public float _padding2;
        public float _padding3;
        public float _padding4;
#pragma warning restore 0169
    }

    public struct PointLightsInfo
    {
        public PointLightInfo[] PointLights;
        public int NumActiveLights;
#pragma warning disable 0169
        public float _padding0;
        public float _padding1;
        public float _padding2;
#pragma warning restore 0169
        public Blittable GetBlittable()
        {
            return new Blittable
            {
                NumActiveLights = NumActiveLights,
                PointLights0 = PointLights[0],
                PointLights1 = PointLights[1],
                PointLights2 = PointLights[2],
                PointLights3 = PointLights[3],
            };
        }

        public struct Blittable
        {
            public PointLightInfo PointLights0;
            public PointLightInfo PointLights1;
            public PointLightInfo PointLights2;
            public PointLightInfo PointLights3;
            public int NumActiveLights;

#pragma warning disable 0169
            public float _padding0;
            public float _padding1;
            public float _padding2;
#pragma warning restore 0169
        }
    }
}
