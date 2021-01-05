using System;

namespace DataStructLib.ArrayBackedStruct.Abstract {
    public abstract class CircularArrayBacked : ArrayBacked {

        protected int _ptr;

        //Read-only property describing the starting index of the data contains in the circular array backed data structure.
        public int Pointer {
            get { 
                return _ptr;
            }
        }

        public sealed override int Cap {
            get {
                return _items.Length;
            }
            set {  //resize the backing array reseting the pointer at 0. O(n).
                if (value < _size) {
                    throw new ArgumentOutOfRangeException("value", "Can't resize the backing array to a size that can't fit all the currently hold data");
                }

                if (value != _items.Length) {
                    Object[] newItems;
                    if (value > _defaultCap) {
                        newItems = new Object[value];
                    } else {
                        newItems = new Object[_defaultCap];
                    }

                    for (int i = _ptr; i < _size + _ptr; i++) {
                        newItems[i - _ptr] = _items[i % _items.Length];
                    }
                    _ptr = 0;
                    _items = newItems;
                }
            }
        }

        //Convert this circular array backed data structure to an array. O(n)
        protected sealed override Object[] ToArray() {
            Object[] copy = new Object[_size];
            for (int i = _ptr; i < _ptr + _size; i++) {
                copy[i - _ptr] = _items[i % _items.Length];
            }
            return copy;
        }
    }
}
