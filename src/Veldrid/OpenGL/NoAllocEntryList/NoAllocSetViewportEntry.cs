﻿namespace Veldrid.OpenGL.NoAllocEntryList
{
    public struct NoAllocSetViewportEntry
    {
        public readonly uint Index;
        public Viewport Viewport;

        public NoAllocSetViewportEntry(uint index, ref Viewport viewport)
        {
            Index = index;
            Viewport = viewport;
        }
    }
}