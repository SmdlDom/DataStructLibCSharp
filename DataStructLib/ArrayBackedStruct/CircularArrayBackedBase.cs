using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct {
    public abstract class CircularArrayBackedBase : ArrayBackedBase {

        protected int _ptr;

        //Read-only property describing the starting index of the data contains in the circular array backed data structure.
        public int Pointer {
            get {
                return _ptr;
            }
        }

        //Convert this circular array backed data structure to an array
        protected sealed override Object[] ToArray() {
            Object[] copy = new Object[_size];
            for (int i = _ptr; i < _ptr + _size; i++) {
                copy[i - _ptr] = _items[i];
            }
            return copy;
        }

    }
}
