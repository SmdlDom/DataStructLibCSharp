using System;

namespace DataStructLib.ArrayBackedStruct {
     public abstract class ArrayBackedBase {
        protected Object[] _items;
        protected int _size;

        protected const int _defaultCap = 8;

        //Property to obtain and modify the capacity of this array backed structure
        public int Cap {
            get {
                return _items.Length;
            }
            set { //Resize the backing array
                if (value < _size) {
                    throw new ArgumentOutOfRangeException("value", "Can't resize the backing array to a size that can't fit all the currently hold data");
                }

                if (value != _items.Length) {
                    if (value > 0) {
                        Object[] newItems = new object[value];
                        if (_size > 0) {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    } else {
                        _items = new Object[_defaultCap];
                    }
                }
            }
        }

        //Read-only property describing the number of element in this ArrayList
        public int Size {
            get {
                return _size;
            }
        }

        //Clears the contents of ArrayList
        public void Clear() {
            if (_size > 0) {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
        }

        //Ensure that the capacity of this list is at least the given minimum value.
        protected void EnsureCap(int min) {
            if (_items.Length < min) {
                int newCap = _items.Length < _defaultCap ? _defaultCap : _items.Length * 2;
                if ((uint)newCap > 0X7FEFFFFF) newCap = 0X7FEFFFFF;
                if (newCap < min) newCap = min;
                Cap = newCap;
            }
        }

        //Halve the capacity of this list if it's size is smaller then a forth of the current capacity
        protected void ReduceCap() {
            if (_size < _items.Length / 4) {
                Cap = _items.Length / 4 < _defaultCap ? _defaultCap : _items.Length / 2;
            }
        }

        //Convert this ArrayBacked Structure to an array
        protected virtual Object[] ToArray() {
            Object[] copy = new object[_size];
            for (int i = 0; i < _size; i++) {
                copy[i] = _items[i];
            }
            return copy;
        }

        //Return a string representation
        public sealed override string ToString() {
            return String.Concat("{", String.Concat(String.Join(", ", ToArray()), "}"));
        }

        //Trim the backing array capacity to fit exactly the size of the structure
        public void TrimToSize() {
            Cap = _size;
        }
    }
}
