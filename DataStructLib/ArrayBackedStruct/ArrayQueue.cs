using DataStructLib.StructInterface;
using System;

namespace DataStructLib.ArrayBackedStruct {
    public class ArrayQueue : CircularArrayBackedBase, QueueInterface {

        public ArrayQueue() {
            _items = new Object[_defaultCap];
            _size = 0;
            _ptr = 0;
        }

        public ArrayQueue(int cap) {
            if (cap < 0) throw new ArgumentOutOfRangeException("cap", "Argument cap must be non-negative");

            if (cap < _defaultCap) _items = new Object[_defaultCap];
            else _items = new Object[cap];
            _size = 0;
            _ptr = 0;
        }
            
        //Push a new item to the queue
        public void Enqueue(Object item) {
            if (_size == _items.Length) EnsureCap(_size + 1);           
            _items[(_size++ + _ptr) % _items.Length] = item;
        }

        //Pop an item from the queue
        public Object Dequeue() {
            if (_size == 0) throw new IndexOutOfRangeException("The structure is empty");
            Object res = _items[_ptr];
            _ptr++;
            if (_ptr == _items.Length) _ptr = 0;
            _size--;
            ReduceCap();
            return res;
        }

        //Peek at the item at the front of the queue
        public Object Peak() {
            if (_size == 0) throw new IndexOutOfRangeException("The structure is empty");
            return _items[_ptr];
        }
    }
}
