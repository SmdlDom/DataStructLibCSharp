using System;

namespace DataStructLib.ArrayBackedStruct {
     public abstract class ArrayBackedBase {
        protected Object[] _items;
        protected int _size;

        protected const int _defaultCap = 8;

        //Property to obtain and modify the capacity of this array backed structure
        public virtual int Cap {
            get {
                return _items.Length;
            }
            set { //Resize the backing array
                if (value < _size) {
                    throw new ArgumentOutOfRangeException("value", "Can't resize the backing array to a size that can't fit all the currently hold data");
                }

                if (value != _items.Length) {
                    Object[] newItems;
                    if (value > _defaultCap) {
                        newItems = new Object[value];   
                    } else {
                        newItems =  new Object[_defaultCap];
                    }
                    
                    for (int i = 0; i < _size; i++) {
                        newItems[i] = _items[i];
                    }
                    _items = newItems;
                }
            }
        }

        //Read-only property describing the number of element in this structure
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

        //Check if this array backed structure is empty
        public bool IsEmpty() {
            if (_size == 0) return true;
            return false;
        }

        //Halve the capacity of this list if it's size is smaller then a forth of the current capacity
        protected virtual void ReduceCap() {
            if (_items.Length != _defaultCap && _size < _items.Length / 4) {
                Cap = _items.Length / 4 < _defaultCap ? _defaultCap : _items.Length / 2;
            }
        }

        //Convert this ArrayBacked Structure to an array
        public virtual Object[] ToArray() {
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

        //Return a string representation of the internal array
        public string ToStringInternalRep() {
            return String.Concat("{", String.Concat(String.Join(", ", _items), "}"));
        }

        //Trim the backing array capacity to fit exactly the size of the structure
        public void TrimToSize() {
            Object[] newItems = new object[_size];

            for (int i = 0; i < _size; i++) {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }
    }
}
