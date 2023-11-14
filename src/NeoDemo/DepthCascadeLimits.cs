﻿using System.Runtime.InteropServices;

namespace Veldrid.NeoDemo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DepthCascadeLimits
    {
        public float NearLimit;
        public float MidLimit;
        public float FarLimit;
        public float _padding;
    }
}
