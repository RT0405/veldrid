﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Veldrid.Vk
{
    /// <summary>
    /// A super-dangerous stack-only list which can hold up to 256 bytes of blittable data.
    /// </summary>
    /// <typeparam name="T">The type of element held in the list. Must be blittable.</typeparam>
    public unsafe struct StackList<T> where T : struct
    {
        public const int CapacityInBytes = 256;
        public static readonly int s_sizeofT = Unsafe.SizeOf<T>();

        public fixed byte _storage[CapacityInBytes];
        public uint _count;

        public uint Count => _count;
        public void* Data => Unsafe.AsPointer(ref this);

        public void Add(T item)
        {
            byte* basePtr = (byte*)Data;
            int offset = (int)(_count * s_sizeofT);
#if DEBUG
            Debug.Assert((offset + s_sizeofT) <= CapacityInBytes);
#endif
            Unsafe.Write(basePtr + offset, item);

            _count += 1;
        }

        public ref T this[uint index]
        {
            get
            {
                byte* basePtr = (byte*)Unsafe.AsPointer(ref this);
                int offset = (int)(index * s_sizeofT);
                return ref Unsafe.AsRef<T>(basePtr + offset);
            }
        }

        public ref T this[int index]
        {
            get
            {
                byte* basePtr = (byte*)Unsafe.AsPointer(ref this);
                int offset = index * s_sizeofT;
                return ref Unsafe.AsRef<T>(basePtr + offset);
            }
        }
    }

    /// <summary>
    /// A super-dangerous stack-only list which can hold a number of bytes determined by the second type parameter.
    /// </summary>
    /// <typeparam name="T">The type of element held in the list. Must be blittable.</typeparam>
    /// <typeparam name="TSize">A type parameter dictating the capacity of the list.</typeparam>
    public unsafe struct StackList<T, TSize> where T : struct where TSize : struct
    {
        public static readonly int s_sizeofT = Unsafe.SizeOf<T>();

#pragma warning disable 0169 // Unused field. This is used implicity because it controls the size of the structure on the stack.
        public TSize _storage;
#pragma warning restore 0169
        public uint _count;

        public uint Count => _count;
        public void* Data => Unsafe.AsPointer(ref this);

        public void Add(T item)
        {
            ref T dest = ref Unsafe.Add(ref Unsafe.As<TSize, T>(ref _storage), (int)_count);
#if DEBUG
            int offset = (int)(_count * s_sizeofT);
            Debug.Assert((offset + s_sizeofT) <= Unsafe.SizeOf<TSize>());
#endif
            dest = item;

            _count += 1;
        }

        public ref T this[int index] => ref Unsafe.Add(ref Unsafe.AsRef<T>(Data), index);
        public ref T this[uint index] => ref Unsafe.Add(ref Unsafe.AsRef<T>(Data), (int)index);
    }

    public unsafe struct Size16Bytes { public fixed byte Data[16]; }
    public unsafe struct Size64Bytes { public fixed byte Data[64]; }
    public unsafe struct Size128Bytes { public fixed byte Data[64]; }
    public unsafe struct Size512Bytes { public fixed byte Data[1024]; }
    public unsafe struct Size1024Bytes { public fixed byte Data[1024]; }
    public unsafe struct Size2048Bytes { public fixed byte Data[2048]; }
#pragma warning disable 0649 // Fields are not assigned directly -- expected.
    public unsafe struct Size2IntPtr { public IntPtr First; public IntPtr Second; }
    public unsafe struct Size6IntPtr { public IntPtr First; public IntPtr Second; public IntPtr Third; public IntPtr Fourth; public IntPtr Fifth; public IntPtr Sixth; }
#pragma warning restore 0649
}
