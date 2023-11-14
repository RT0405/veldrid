using System;
using System.IO;

namespace Veldrid.NeoDemo
{
    public static class AssetHelper
    {
        public static readonly string s_assetRoot = Path.Combine(AppContext.BaseDirectory, "Assets");

        public static string GetPath(string assetPath)
        {
            return Path.Combine(s_assetRoot, assetPath);
        }
    }
}