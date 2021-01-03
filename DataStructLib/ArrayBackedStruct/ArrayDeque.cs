using DataStructLib.StructInterface;
using System;

namespace DataStructLib.ArrayBackedStruct {
    public class ArrayDeque : ArrayQueue, DequeInterface {
        
        public ArrayDeque() {
            _items = new Object[_defaultCap];
            _size = 0;
            _ptr = 0;
        }

        public ArrayDeque(int cap) {
            if (cap < 0) throw new ArgumentOutOfRangeException("cap", "Argument cap must be non-negative");

            if (cap < _defaultCap) _items = new object[_defaultCap];
            else _items = new object[cap];
            _size = 0;
            _ptr = 0;
        }

        //Push an item to the front of the deque. O(1) amortized.
        public void EnqueueFront(Object item) {
            if (_size == _items.Length) EnsureCap(_size + 1);
            _ptr--;
            if (_ptr == -1) _ptr = _items.Length - 1;
            _items[_ptr] = item;
            _size++;
        }

        //Pop the item at the back of the deque. O(1) amortized.
        public Object DequeueBack() {
            if (_size == 0) throw new IndexOutOfRangeException("The structure is empty");
            Object res = _items[(_ptr + _size - 1) % _items.Length];
            _size--;
            ReduceCap();
            return res;
        }

        //Peek at the item at the back of the deque. O(1)
        public Object PeakBack() {
            if (_size == 0) throw new IndexOutOfRangeException("The structure is empty");
            return _items[(_ptr + _size - 1) % _items.Length];
        }

    }
}
