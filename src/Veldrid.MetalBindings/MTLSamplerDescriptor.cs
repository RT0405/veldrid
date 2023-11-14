using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    public struct MTLSamplerDescriptor
    {
        public static readonly ObjCClass s_class = new ObjCClass(nameof(MTLSamplerDescriptor));
        public readonly IntPtr NativePtr;
        public static MTLSamplerDescriptor New() => s_class.AllocInit<MTLSamplerDescriptor>();

        public MTLSamplerAddressMode rAddressMode
        {
            get => (MTLSamplerAddressMode)uint_objc_msgSend(NativePtr, sel_rAddressMode);
            set => objc_msgSend(NativePtr, sel_setRAddressMode, (uint)value);
        }

        public MTLSamplerAddressMode sAddressMode
        {
            get => (MTLSamplerAddressMode)uint_objc_msgSend(NativePtr, sel_sAddressMode);
            set => objc_msgSend(NativePtr, sel_setSAddressMode, (uint)value);
        }

        public MTLSamplerAddressMode tAddressMode
        {
            get => (MTLSamplerAddressMode)uint_objc_msgSend(NativePtr, sel_tAddressMode);
            set => objc_msgSend(NativePtr, sel_setTAddressMode, (uint)value);
        }

        public MTLSamplerMinMagFilter minFilter
        {
            get => (MTLSamplerMinMagFilter)uint_objc_msgSend(NativePtr, sel_minFilter);
            set => objc_msgSend(NativePtr, sel_setMinFilter, (uint)value);
        }

        public MTLSamplerMinMagFilter magFilter
        {
            get => (MTLSamplerMinMagFilter)uint_objc_msgSend(NativePtr, sel_magFilter);
            set => objc_msgSend(NativePtr, sel_setMagFilter, (uint)value);
        }

        public MTLSamplerMipFilter mipFilter
        {
            get => (MTLSamplerMipFilter)uint_objc_msgSend(NativePtr, sel_mipFilter);
            set => objc_msgSend(NativePtr, sel_setMipFilter, (uint)value);
        }

        public float lodMinClamp
        {
            get => float_objc_msgSend(NativePtr, sel_lodMinClamp);
            set => objc_msgSend(NativePtr, sel_setLodMinClamp, value);
        }

        public float lodMaxClamp
        {
            get => float_objc_msgSend(NativePtr, sel_lodMaxClamp);
            set => objc_msgSend(NativePtr, sel_setLodMaxClamp, value);
        }

        public Bool8 lodAverage
        {
            get => bool8_objc_msgSend(NativePtr, sel_lodAverage);
            set => objc_msgSend(NativePtr, sel_setLodAverage, value);
        }

        public UIntPtr maxAnisotropy
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_maxAnisotropy);
            set => objc_msgSend(NativePtr, sel_setMaAnisotropy, value);
        }

        public MTLCompareFunction compareFunction
        {
            get => (MTLCompareFunction)uint_objc_msgSend(NativePtr, sel_compareFunction);
            set => objc_msgSend(NativePtr, sel_setCompareFunction, (uint)value);
        }

        public MTLSamplerBorderColor borderColor
        {
            get => (MTLSamplerBorderColor)uint_objc_msgSend(NativePtr, sel_borderColor);
            set => objc_msgSend(NativePtr, sel_setBorderColor, (uint)value);
        }

        public static readonly Selector sel_rAddressMode = "rAddressMode";
        public static readonly Selector sel_setRAddressMode = "setRAddressMode:";
        public static readonly Selector sel_sAddressMode = "sAddressMode";
        public static readonly Selector sel_setSAddressMode = "setSAddressMode:";
        public static readonly Selector sel_tAddressMode = "tAddressMode";
        public static readonly Selector sel_setTAddressMode = "setTAddressMode:";
        public static readonly Selector sel_minFilter = "minFilter";
        public static readonly Selector sel_setMinFilter = "setMinFilter:";
        public static readonly Selector sel_magFilter = "magFilter";
        public static readonly Selector sel_setMagFilter = "setMagFilter:";
        public static readonly Selector sel_mipFilter = "mipFilter";
        public static readonly Selector sel_setMipFilter = "setMipFilter:";
        public static readonly Selector sel_lodMinClamp = "lodMinClamp";
        public static readonly Selector sel_setLodMinClamp = "setLodMinClamp:";
        public static readonly Selector sel_lodMaxClamp = "lodMaxClamp";
        public static readonly Selector sel_setLodMaxClamp = "setLodMaxClamp:";
        public static readonly Selector sel_lodAverage = "lodAverage";
        public static readonly Selector sel_setLodAverage = "setLodAverage:";
        public static readonly Selector sel_maxAnisotropy = "maxAnisotropy";
        public static readonly Selector sel_setMaAnisotropy = "setMaxAnisotropy:";
        public static readonly Selector sel_compareFunction = "compareFunction";
        public static readonly Selector sel_setCompareFunction = "setCompareFunction:";
        public static readonly Selector sel_borderColor = "borderColor";
        public static readonly Selector sel_setBorderColor = "setBorderColor:";
    }
}