namespace Veldrid.OpenGL.NoAllocEntryList
{
    public struct NoAllocInsertDebugMarkerEntry
    {
        public Tracked<string> Name;

        public NoAllocInsertDebugMarkerEntry(Tracked<string> name)
        {
            Name = name;
        }
    }
}
