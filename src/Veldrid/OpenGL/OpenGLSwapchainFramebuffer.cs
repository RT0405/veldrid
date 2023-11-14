using System;
using System.Collections.Generic;

namespace Veldrid.OpenGL
{
    public class OpenGLSwapchainFramebuffer : Framebuffer
    {
        public readonly PixelFormat? _depthFormat;
        public bool _disposed;

        public override uint Width => _colorTexture.Width;
        public override uint Height => _colorTexture.Height;

        public override OutputDescription OutputDescription { get; }
        public override string Name { get; set; }
        public override bool IsDisposed => _disposed;

        public readonly OpenGLPlaceholderTexture _colorTexture;
        public readonly OpenGLPlaceholderTexture _depthTexture;

        public readonly FramebufferAttachment[] _colorTargets;
        public readonly FramebufferAttachment? _depthTarget;

        public override IReadOnlyList<FramebufferAttachment> ColorTargets => _colorTargets;
        public override FramebufferAttachment? DepthTarget => _depthTarget;

        public bool DisableSrgbConversion { get; }

        public OpenGLSwapchainFramebuffer(
            uint width, uint height,
            PixelFormat colorFormat,
            PixelFormat? depthFormat,
            bool disableSrgbConversion)
        {
            _depthFormat = depthFormat;
            // This is wrong, but it's not really used.
            OutputAttachmentDescription? depthDesc = _depthFormat != null
                ? new OutputAttachmentDescription(_depthFormat.Value)
                : (OutputAttachmentDescription?)null;
            OutputDescription = new OutputDescription(
                depthDesc,
                new OutputAttachmentDescription(colorFormat));

            _colorTexture = new OpenGLPlaceholderTexture(
                width,
                height,
                colorFormat,
                TextureUsage.RenderTarget,
                TextureSampleCount.Count1);
            _colorTargets = new[] { new FramebufferAttachment(_colorTexture, 0) };

            if (_depthFormat != null)
            {
                _depthTexture = new OpenGLPlaceholderTexture(
                    width,
                    height,
                    depthFormat.Value,
                    TextureUsage.DepthStencil,
                    TextureSampleCount.Count1);
                _depthTarget = new FramebufferAttachment(_depthTexture, 0);
            }

            OutputDescription = OutputDescription.CreateFromFramebuffer(this);

            DisableSrgbConversion = disableSrgbConversion;
        }

        public void Resize(uint width, uint height)
        {
            _colorTexture.Resize(width, height);
            _depthTexture?.Resize(width, height);
        }

        public override void Dispose()
        {
            _disposed = true;
        }
    }
}
