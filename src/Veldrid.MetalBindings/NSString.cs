using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    public unsafe struct NSString
    {
        public readonly IntPtr NativePtr;
        public NSString(IntPtr ptr) => NativePtr = ptr;
        public static implicit operator IntPtr(NSString nss) => nss.NativePtr;

        public static NSString New(string s)
        {
            var nss = s_class.Alloc<NSString>();

            fixed (char* utf16Ptr = s)
            {
                UIntPtr length = (UIntPtr)s.Length;
                IntPtr newString = IntPtr_objc_msgSend(nss, sel_initWithCharacters, (IntPtr)utf16Ptr, length);
                return new NSString(newString);
            }
        }

        public string GetValue()
        {
            byte* utf8Ptr = bytePtr_objc_msgSend(NativePtr, sel_utf8String);
            return MTLUtil.GetUtf8String(utf8Ptr);
        }

        public static readonly ObjCClass s_class = new ObjCClass(nameof(NSString));
        public static readonly Selector sel_initWithCharacters = "initWithCharacters:length:";
        public static readonly Selector sel_utf8String = "UTF8String";
    }
}