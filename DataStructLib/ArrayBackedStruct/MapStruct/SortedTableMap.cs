using DataStructLib.MapStruct;
using DataStructLib.StructInterface;
using System;

namespace DataStructLib.ArrayBackedStruct.MapStruct {
    public class SortedTableMap : UnsortedTableMap, MapInterface {

        public SortedTableMap() {
            _items = new Item[_defaultCap];
            _size = 0;
        }

        
        //Set the item in the structure denoted by this key at a particular value. If no item in the structure match the key insert a new item. Return a boolean determining if a new item was inserted to the structure. O(n).
        public sealed override bool SetValue(int key, Object value) {
            int index = -1;
            bool matched = false;
            for (int i = 0; i < _size; i++) {
                if (_items[i].Key == key) {
                    index = i;
                    matched = true;
                    break;
                } else if (_items[i].Key > key) {
                    index = i;
                    break;
                }
            }

            if (matched) {
                _items[index].Value = value;
                return false;
            } else {
                if (_size == _items.Length) EnsureCap(_size + 1);
                _size++;
                if (index == -1) {
                    _items[_size - 1] = new Item(key, value);
                } else {
                    for (int i = _size - 1; i > index; i--) {
                        _items[i] = _items[i - 1];
                    }
                    _items[index] = new Item(key, value);
                }
                return true;
            }
        }

    }
}
