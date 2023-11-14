using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPipelineColorAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;

        public MTLRenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLPixelFormat pixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, Selectors.pixelFormat);
            set => objc_msgSend(NativePtr, Selectors.setPixelFormat, (uint)value);
        }

        public MTLColorWriteMask writeMask
        {
            get => (MTLColorWriteMask)uint_objc_msgSend(NativePtr, sel_writeMask);
            set => objc_msgSend(NativePtr, sel_setWriteMask, (uint)value);
        }

        public Bool8 blendingEnabled
        {
            get => bool8_objc_msgSend(NativePtr, sel_isBlendingEnabled);
            set => objc_msgSend(NativePtr, sel_setBlendingEnabled, value);
        }

        public MTLBlendOperation alphaBlendOperation
        {
            get => (MTLBlendOperation)uint_objc_msgSend(NativePtr, sel_alphaBlendOperation);
            set => objc_msgSend(NativePtr, sel_setAlphaBlendOperation, (uint)value);
        }

        public MTLBlendOperation rgbBlendOperation
        {
            get => (MTLBlendOperation)uint_objc_msgSend(NativePtr, sel_rgbBlendOperation);
            set => objc_msgSend(NativePtr, sel_setRGBBlendOperation, (uint)value);
        }

        public MTLBlendFactor destinationAlphaBlendFactor
        {
            get => (MTLBlendFactor)uint_objc_msgSend(NativePtr, sel_destinationAlphaBlendFactor);
            set => objc_msgSend(NativePtr, sel_setDestinationAlphaBlendFactor, (uint)value);
        }

        public MTLBlendFactor destinationRGBBlendFactor
        {
            get => (MTLBlendFactor)uint_objc_msgSend(NativePtr, sel_destinationRGBBlendFactor);
            set => objc_msgSend(NativePtr, sel_setDestinationRGBBlendFactor, (uint)value);
        }

        public MTLBlendFactor sourceAlphaBlendFactor
        {
            get => (MTLBlendFactor)uint_objc_msgSend(NativePtr, sel_sourceAlphaBlendFactor);
            set => objc_msgSend(NativePtr, sel_setSourceAlphaBlendFactor, (uint)value);
        }

        public MTLBlendFactor sourceRGBBlendFactor
        {
            get => (MTLBlendFactor)uint_objc_msgSend(NativePtr, sel_sourceRGBBlendFactor);
            set => objc_msgSend(NativePtr, sel_setSourceRGBBlendFactor, (uint)value);
        }

        public static readonly Selector sel_isBlendingEnabled = "isBlendingEnabled";
        public static readonly Selector sel_setBlendingEnabled = "setBlendingEnabled:";
        public static readonly Selector sel_writeMask = "writeMask";
        public static readonly Selector sel_setWriteMask = "setWriteMask:";
        public static readonly Selector sel_alphaBlendOperation = "alphaBlendOperation";
        public static readonly Selector sel_setAlphaBlendOperation = "setAlphaBlendOperation:";
        public static readonly Selector sel_rgbBlendOperation = "rgbBlendOperation";
        public static readonly Selector sel_setRGBBlendOperation = "setRgbBlendOperation:";
        public static readonly Selector sel_destinationAlphaBlendFactor = "destinationAlphaBlendFactor";
        public static readonly Selector sel_setDestinationAlphaBlendFactor = "setDestinationAlphaBlendFactor:";
        public static readonly Selector sel_destinationRGBBlendFactor = "destinationRGBBlendFactor";
        public static readonly Selector sel_setDestinationRGBBlendFactor = "setDestinationRGBBlendFactor:";
        public static readonly Selector sel_sourceAlphaBlendFactor = "sourceAlphaBlendFactor";
        public static readonly Selector sel_setSourceAlphaBlendFactor = "setSourceAlphaBlendFactor:";
        public static readonly Selector sel_sourceRGBBlendFactor = "sourceRGBBlendFactor";
        public static readonly Selector sel_setSourceRGBBlendFactor = "setSourceRGBBlendFactor:";
    }
}