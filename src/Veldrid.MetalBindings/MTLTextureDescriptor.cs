using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    public struct MTLTextureDescriptor
    {
        public static readonly ObjCClass s_class = new ObjCClass(nameof(MTLTextureDescriptor));
        public readonly IntPtr NativePtr;
        public static MTLTextureDescriptor New() => s_class.AllocInit<MTLTextureDescriptor>();

        public MTLTextureType textureType
        {
            get => (MTLTextureType)uint_objc_msgSend(NativePtr, sel_textureType);
            set => objc_msgSend(NativePtr, sel_setTextureType, (uint)value);
        }

        public MTLPixelFormat pixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, Selectors.pixelFormat);
            set => objc_msgSend(NativePtr, Selectors.setPixelFormat, (uint)value);
        }

        public UIntPtr width
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_width);
            set => objc_msgSend(NativePtr, sel_setWidth, value);
        }

        public UIntPtr height
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_height);
            set => objc_msgSend(NativePtr, sel_setHeight, value);
        }

        public UIntPtr depth
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_depth);
            set => objc_msgSend(NativePtr, sel_setDepth, value);
        }

        public UIntPtr mipmapLevelCount
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_mipmapLevelCount);
            set => objc_msgSend(NativePtr, sel_setMipmapLevelCount, value);
        }

        public UIntPtr sampleCount
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_sampleCount);
            set => objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        public UIntPtr arrayLength
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_arrayLength);
            set => objc_msgSend(NativePtr, sel_setArrayLength, value);
        }

        public MTLResourceOptions resourceOptions
        {
            get => (MTLResourceOptions)uint_objc_msgSend(NativePtr, sel_resourceOptions);
            set => objc_msgSend(NativePtr, sel_setResourceOptions, (uint)value);
        }

        public MTLCPUCacheMode cpuCacheMode
        {
            get => (MTLCPUCacheMode)uint_objc_msgSend(NativePtr, sel_cpuCacheMode);
            set => objc_msgSend(NativePtr, sel_setCpuCacheMode, (uint)value);
        }

        public MTLStorageMode storageMode
        {
            get => (MTLStorageMode)uint_objc_msgSend(NativePtr, sel_storageMode);
            set => objc_msgSend(NativePtr, sel_setStorageMode, (uint)value);
        }

        public MTLTextureUsage textureUsage
        {
            get => (MTLTextureUsage)uint_objc_msgSend(NativePtr, sel_textureUsage);
            set => objc_msgSend(NativePtr, sel_setTextureUsage, (uint)value);
        }

        public static readonly Selector sel_textureType = "textureType";
        public static readonly Selector sel_setTextureType = "setTextureType:";
        public static readonly Selector sel_width = "width";
        public static readonly Selector sel_setWidth = "setWidth:";
        public static readonly Selector sel_height = "height";
        public static readonly Selector sel_setHeight = "setHeight:";
        public static readonly Selector sel_depth = "depth";
        public static readonly Selector sel_setDepth = "setDepth:";
        public static readonly Selector sel_mipmapLevelCount = "mipmapLevelCount";
        public static readonly Selector sel_setMipmapLevelCount = "setMipmapLevelCount:";
        public static readonly Selector sel_sampleCount = "sampleCount";
        public static readonly Selector sel_setSampleCount = "setSampleCount:";
        public static readonly Selector sel_arrayLength = "arrayLength";
        public static readonly Selector sel_setArrayLength = "setArrayLength:";
        public static readonly Selector sel_resourceOptions = "resourceOptions";
        public static readonly Selector sel_setResourceOptions = "setResourceOptions:";
        public static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        public static readonly Selector sel_setCpuCacheMode = "setCpuCacheMode:";
        public static readonly Selector sel_storageMode = "storageMode";
        public static readonly Selector sel_setStorageMode = "setStorageMode:";
        public static readonly Selector sel_textureUsage = "textureUsage";
        public static readonly Selector sel_setTextureUsage = "setTextureUsage:";
    }
}