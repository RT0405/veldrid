namespace Veldrid.OpenGL.NoAllocEntryList
{
    public struct NoAllocSetFramebufferEntry
    {
        public readonly Tracked<Framebuffer> Framebuffer;

        public NoAllocSetFramebufferEntry(Tracked<Framebuffer> fb)
        {
            Framebuffer = fb;
        }
    }
}