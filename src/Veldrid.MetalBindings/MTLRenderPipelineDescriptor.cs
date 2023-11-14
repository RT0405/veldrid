using static Veldrid.MetalBindings.ObjectiveCRuntime;
using System;
using System.Runtime.InteropServices;

namespace Veldrid.MetalBindings
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPipelineDescriptor
    {
        public readonly IntPtr NativePtr;

        public MTLRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public static MTLRenderPipelineDescriptor New()
        {
            var cls = new ObjCClass("MTLRenderPipelineDescriptor");
            var ret = cls.AllocInit<MTLRenderPipelineDescriptor>();
            return ret;
        }

        public MTLFunction vertexFunction
        {
            get => objc_msgSend<MTLFunction>(NativePtr, sel_vertexFunction);
            set => objc_msgSend(NativePtr, sel_setVertexFunction, value.NativePtr);
        }

        public MTLFunction fragmentFunction
        {
            get => objc_msgSend<MTLFunction>(NativePtr, sel_fragmentFunction);
            set => objc_msgSend(NativePtr, sel_setFragmentFunction, value.NativePtr);
        }

        public MTLRenderPipelineColorAttachmentDescriptorArray colorAttachments
            => objc_msgSend<MTLRenderPipelineColorAttachmentDescriptorArray>(NativePtr, sel_colorAttachments);

        public MTLPixelFormat depthAttachmentPixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, sel_depthAttachmentPixelFormat);
            set => objc_msgSend(NativePtr, sel_setDepthAttachmentPixelFormat, (uint)value);
        }

        public MTLPixelFormat stencilAttachmentPixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, sel_stencilAttachmentPixelFormat);
            set => objc_msgSend(NativePtr, sel_setStencilAttachmentPixelFormat, (uint)value);
        }

        public UIntPtr sampleCount
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_sampleCount);
            set => objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        public MTLVertexDescriptor vertexDescriptor => objc_msgSend<MTLVertexDescriptor>(NativePtr, sel_vertexDescriptor);

        public Bool8 alphaToCoverageEnabled
        {
            get => bool8_objc_msgSend(NativePtr, sel_isAlphaToCoverageEnabled);
            set => objc_msgSend(NativePtr, sel_setAlphaToCoverageEnabled, value);
        }

        public static readonly Selector sel_vertexFunction = "vertexFunction";
        public static readonly Selector sel_setVertexFunction = "setVertexFunction:";
        public static readonly Selector sel_fragmentFunction = "fragmentFunction";
        public static readonly Selector sel_setFragmentFunction = "setFragmentFunction:";
        public static readonly Selector sel_colorAttachments = "colorAttachments";
        public static readonly Selector sel_depthAttachmentPixelFormat = "depthAttachmentPixelFormat";
        public static readonly Selector sel_setDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";
        public static readonly Selector sel_stencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";
        public static readonly Selector sel_setStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";
        public static readonly Selector sel_sampleCount = "sampleCount";
        public static readonly Selector sel_setSampleCount = "setSampleCount:";
        public static readonly Selector sel_vertexDescriptor = "vertexDescriptor";
        public static readonly Selector sel_isAlphaToCoverageEnabled = "isAlphaToCoverageEnabled";
        public static readonly Selector sel_setAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";
    }
}
