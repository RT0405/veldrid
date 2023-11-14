﻿namespace Veldrid.OpenGL.NoAllocEntryList
{
    public struct NoAllocDispatchIndirectEntry
    {
        public Tracked<DeviceBuffer> IndirectBuffer;
        public uint Offset;

        public NoAllocDispatchIndirectEntry(Tracked<DeviceBuffer> indirectBuffer, uint offset)
        {
            IndirectBuffer = indirectBuffer;
            Offset = offset;
        }
    }
}