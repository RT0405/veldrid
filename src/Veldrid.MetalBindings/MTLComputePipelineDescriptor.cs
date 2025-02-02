using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    public struct MTLComputePipelineDescriptor
    {
        public readonly IntPtr NativePtr;

        public MTLFunction computeFunction
        {
            get => objc_msgSend<MTLFunction>(NativePtr, sel_computeFunction);
            set => objc_msgSend(NativePtr, sel_setComputeFunction, value.NativePtr);
        }

        public MTLPipelineBufferDescriptorArray buffers
            => objc_msgSend<MTLPipelineBufferDescriptorArray>(NativePtr, sel_buffers);

        public static readonly Selector sel_computeFunction = "computeFunction";
        public static readonly Selector sel_setComputeFunction = "setComputeFunction:";
        public static readonly Selector sel_buffers = "buffers";
    }
}