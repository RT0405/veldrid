namespace Veldrid.OpenGL.NoAllocEntryList
{
    public struct NoAllocGenerateMipmapsEntry
    {
        public readonly Tracked<Texture> Texture;

        public NoAllocGenerateMipmapsEntry(Tracked<Texture> texture)
        {
            Texture = texture;
        }
    }
}