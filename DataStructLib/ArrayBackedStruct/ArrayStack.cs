using System;

namespace DataStructLib.ArrayBackedStruct {
    public class ArrayStack : ArrayBackedBase {

        public ArrayStack() {
            _items = new Object[_defaultCap];
            _size = 0;
        }

        public ArrayStack(int cap) {
            if (cap < 0) throw new ArgumentOutOfRangeException("cap", "Argument cap must be non-negative");

            if (cap < _defaultCap) _items = new object[_defaultCap];
            else _items = new object[cap];
            _size = 0;
        }

        //Push a new item on top of the stack. O(1) amortized
        public void Push(Object item) {
            if (_size == _items.Length) EnsureCap(_size + 1);
            _items[_size++] = item;
        }

        //Pop the item on top of the stack. O(1) amortized
        public Object Pop() {
            Object res = _items[--_size];
            ReduceCap();
            return res;
        }

        //Peek at the item on top of the stack without popping it. O(1)
        public Object Peak() {
            return _items[_size - 1];
        }
    }
}
