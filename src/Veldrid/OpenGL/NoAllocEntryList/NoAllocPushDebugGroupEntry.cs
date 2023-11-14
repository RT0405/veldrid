namespace Veldrid.OpenGL.NoAllocEntryList
{
    public struct NoAllocPushDebugGroupEntry
    {
        public Tracked<string> Name;

        public NoAllocPushDebugGroupEntry(Tracked<string> name)
        {
            Name = name;
        }
    }
}
