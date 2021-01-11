using DataStructLib.ArrayBackedStruct.MapStruct.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.MapStruct {
    public class PriorityQueue : BucketMapBase {

        public PriorityQueue() {
            _items = new Bucket[_defaultCap];
            _size = 0;
            _slots = 0;
        }

        //Insert a new item of the given priority inside the structure. Return a boolean determining if a new bucket was inserted. O(n)
        public bool Push(int key, Object item) {
            _size++;
            for (int i = 0; i < _slots; i++) {
                if (key == _items[i].Key) { // Append to existing bucket
                    _items[i].Enqueue(item);
                    return false;
                } else if (key < _items[i].Key) { // Insert a new bucket
                    if (_slots == _items.Length) EnsureCap(_slots + 1);
                    for (int j = i; j < _slots; j++) {
                        _items[j + 1] = _items[j];
                    }
                    Bucket newBuc = new Bucket(key);
                    newBuc.Enqueue(item);
                    _items[i] = newBuc;
                    _slots++;
                    return true;
                }
            }

            //Base case of an empty PriorityQueue or bucket inserted at the end.
            if (_slots == _items.Length) EnsureCap(_slots + 1);
            Bucket newBucket = new Bucket(key);
            newBucket.Enqueue(item);
            _items[_slots++] = newBucket;
            return true;
        }

        //Take out and return the highest priority object in the structure. O(n)
        public Object Pop() {
            if (_size == 0) throw new IndexOutOfRangeException("The structure is empty");
            _size--;
            if (_items[0].Size == 1) {
                Object res = _items[0].Dequeue();
                _slots--;
                for (int i = 0; i < _slots; i++) {
                    _items[i] = _items[i + 1];
                }
                return res;
            } else {
                return _items[0].Dequeue();
            }
        }

        //Peak at he item in front of the priority queue. O(n)
        public Object Peak() {
            if (_size == 0) throw new IndexOutOfRangeException("The structure is empty");
            return _items[0].Peak();
        }
    }
}
