﻿using System.Numerics;
using System.Runtime.InteropServices;

namespace Veldrid.NeoDemo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LightInfo
    {
        public Vector3 Direction;
        public float _padding;
    }
}
