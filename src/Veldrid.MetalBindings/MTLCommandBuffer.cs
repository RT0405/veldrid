using static Veldrid.MetalBindings.ObjectiveCRuntime;
using System;
using System.Runtime.InteropServices;

namespace Veldrid.MetalBindings
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLCommandBuffer
    {
        public readonly IntPtr NativePtr;

        public MTLRenderCommandEncoder renderCommandEncoderWithDescriptor(MTLRenderPassDescriptor desc)
        {
            return new MTLRenderCommandEncoder(
                IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoderWithDescriptor, desc.NativePtr));
        }

        public void presentDrawable(IntPtr drawable) => objc_msgSend(NativePtr, sel_presentDrawable, drawable);

        public void commit() => objc_msgSend(NativePtr, sel_commit);

        public MTLBlitCommandEncoder blitCommandEncoder()
            => objc_msgSend<MTLBlitCommandEncoder>(NativePtr, sel_blitCommandEncoder);

        public MTLComputeCommandEncoder computeCommandEncoder()
            => objc_msgSend<MTLComputeCommandEncoder>(NativePtr, sel_computeCommandEncoder);

        public void waitUntilCompleted() => objc_msgSend(NativePtr, sel_waitUntilCompleted);

        public void addCompletedHandler(MTLCommandBufferHandler block)
            => objc_msgSend(NativePtr, sel_addCompletedHandler, block);
        public void addCompletedHandler(IntPtr block)
            => objc_msgSend(NativePtr, sel_addCompletedHandler, block);

        public MTLCommandBufferStatus status => (MTLCommandBufferStatus)uint_objc_msgSend(NativePtr, sel_status);

        public static readonly Selector sel_renderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";
        public static readonly Selector sel_presentDrawable = "presentDrawable:";
        public static readonly Selector sel_commit = "commit";
        public static readonly Selector sel_blitCommandEncoder = "blitCommandEncoder";
        public static readonly Selector sel_computeCommandEncoder = "computeCommandEncoder";
        public static readonly Selector sel_waitUntilCompleted = "waitUntilCompleted";
        public static readonly Selector sel_addCompletedHandler = "addCompletedHandler:";
        public static readonly Selector sel_status = "status";
    }
}