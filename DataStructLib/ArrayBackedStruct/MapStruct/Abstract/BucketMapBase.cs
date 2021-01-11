using DataStructLib.ArrayBackedStruct.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.MapStruct.Abstract {
    public class BucketMapBase : ArrayBacked {

        //Nested class representing the bucket associated with a particular key.
        protected class Bucket {
            private int _key;
            private ArrayQueue _bucket;

            public Bucket(int key) {
                _key = key;
                _bucket = new ArrayQueue();
            }

            public int Key => _key;

            public int Size => _bucket.Size;

            //Determine if the bucket is empty. O(1)
            public bool IsEmpty() {
                if (Size == 0) return true;
                return false;
            }

            //Enqueue a new item in the bucket. O(1) amortized
            public void Enqueue(Object item) {
                _bucket.Enqueue(item);
            }

            //Dequeue the item at the front of the queue. O(1) amortized
            public Object Dequeue() {
                return _bucket.Dequeue();

            }

            //Peak at the item at the front of the queue.
            public Object Peak() {
                return _bucket.Peak();
            }

            //Return a string representation of this bucket
            public override string ToString() {
                Object[] items = _bucket.ToArray();
                StringBuilder sb = new StringBuilder("<");
                sb.Append(_key.ToString());
                sb.Append(":");
                for (int i = 0; i < items.Length; i++) {
                    sb.Append(items[i].ToString());
                    if (i != items.Length - 1) sb.Append(", ");
                }
                sb.Append(">");
                return sb.ToString();
            }
        }

        protected new Bucket[] _items;
        protected int _slots;

        //Ensure that the capacity of this list is at least the given minimum value. O(n)
        protected sealed override void EnsureCap(int min) {
            if (_items.Length < min) {
                int newCap = _items.Length < _defaultCap ? _defaultCap : _items.Length * 2;
                if ((uint)newCap > 0X7FEFFFFF) newCap = 0X7FEFFFFF;
                if (newCap < min) newCap = min;
                Cap = newCap;
            }
        }

        //Halve the capacity of this list if it's size is smaller then a forth of the current capacity. O(n)
        protected sealed override void ReduceCap() {
            if (_items.Length != _defaultCap && _size < _items.Length / 4) {
                Cap = _items.Length / 4 < _defaultCap ? _defaultCap : _items.Length / 2;
            }
        }

        //Convert this bucket array to an array. O(n)
        protected new Bucket[] ToArray() {
            Bucket[] copy = new Bucket[_slots];
            for (int i = 0; i < _slots; i++) {
                copy[i] = _items[i];
            }
            return copy;
        }

        //Return a string representation. O(n)
        public sealed override string ToString() {
            Bucket[] items = ToArray();
            StringBuilder sb = new StringBuilder("{");
            for (int i = 0; i < _slots; i++) {
                sb.Append(items[i].ToString());
                if (i != items.Length - 1) sb.Append(", ");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
