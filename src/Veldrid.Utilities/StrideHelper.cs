using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Veldrid.Utilities
{
    public unsafe struct StrideHelper<T>
    {
        public readonly byte* _basePtr;
        public readonly int _count;
        public readonly int _stride;

        public StrideHelper(void* ptr, int count, int stride)
        {
            _basePtr = (byte*)ptr;
            _count = count;
            _stride = stride;
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(_basePtr, _count, _stride);
        }

        public struct Enumerator : IEnumerator<T>
        {
            public byte* _basePtr;
            public int _count;
            public int _stride;
            public int _currentItemIndex;

            public Enumerator(byte* basePtr, int count, int stride)
            {
                _basePtr = basePtr;
                _count = count;
                _stride = stride;
                _currentItemIndex = -1;
            }

            public T Current
            {
                get
                {
                    if (_currentItemIndex == -1 || _currentItemIndex >= _count) { throw new InvalidOperationException(); }
                    else
                    {
                        return Unsafe.Read<T>(_basePtr + (_currentItemIndex * _stride));
                    }
                }
            }
            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _currentItemIndex += 1;
                return _currentItemIndex < _count;
            }

            public void Reset()
            {
                _currentItemIndex = -1;
            }
        }
    }
}
