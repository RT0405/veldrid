using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    public struct MTLDepthStencilDescriptor
    {
        public readonly IntPtr NativePtr;
        public MTLDepthStencilDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLCompareFunction depthCompareFunction
        {
            get => (MTLCompareFunction)uint_objc_msgSend(NativePtr, sel_depthCompareFunction);
            set => objc_msgSend(NativePtr, sel_setDepthCompareFunction, (uint)value);
        }

        public Bool8 depthWriteEnabled
        {
            get => bool8_objc_msgSend(NativePtr, sel_isDepthWriteEnabled);
            set => objc_msgSend(NativePtr, sel_setDepthWriteEnabled, value);
        }

        public MTLStencilDescriptor backFaceStencil
        {
            get => objc_msgSend<MTLStencilDescriptor>(NativePtr, sel_backFaceStencil);
            set => objc_msgSend(NativePtr, sel_setBackFaceStencil, value.NativePtr);
        }

        public MTLStencilDescriptor frontFaceStencil
        {
            get => objc_msgSend<MTLStencilDescriptor>(NativePtr, sel_frontFaceStencil);
            set => objc_msgSend(NativePtr, sel_setFrontFaceStencil, value.NativePtr);
        }

        public static readonly Selector sel_depthCompareFunction = "depthCompareFunction";
        public static readonly Selector sel_setDepthCompareFunction = "setDepthCompareFunction:";
        public static readonly Selector sel_isDepthWriteEnabled = "isDepthWriteEnabled";
        public static readonly Selector sel_setDepthWriteEnabled = "setDepthWriteEnabled:";
        public static readonly Selector sel_backFaceStencil = "backFaceStencil";
        public static readonly Selector sel_setBackFaceStencil = "setBackFaceStencil:";
        public static readonly Selector sel_frontFaceStencil = "frontFaceStencil";
        public static readonly Selector sel_setFrontFaceStencil = "setFrontFaceStencil:";
    }
}