using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    public struct MTLVertexBufferLayoutDescriptor
    {
        public readonly IntPtr NativePtr;

        public MTLVertexBufferLayoutDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexStepFunction stepFunction
        {
            get => (MTLVertexStepFunction)uint_objc_msgSend(NativePtr, sel_stepFunction);
            set => objc_msgSend(NativePtr, sel_setStepFunction, (uint)value);
        }

        public UIntPtr stride
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_stride);
            set => objc_msgSend(NativePtr, sel_setStride, value);
        }

        public UIntPtr stepRate
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_stepRate);
            set => objc_msgSend(NativePtr, sel_setStepRate, value);
        }

        public static readonly Selector sel_stepFunction = "stepFunction";
        public static readonly Selector sel_setStepFunction = "setStepFunction:";
        public static readonly Selector sel_stride = "stride";
        public static readonly Selector sel_setStride = "setStride:";
        public static readonly Selector sel_stepRate = "stepRate";
        public static readonly Selector sel_setStepRate = "setStepRate:";
    }
}