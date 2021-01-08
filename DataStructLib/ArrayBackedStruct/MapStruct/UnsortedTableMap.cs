using DataStructLib.MapStruct.Abstract;
using DataStructLib.StructInterface;
using System;

namespace DataStructLib.MapStruct {
    public class UnsortedTableMap : ArrayMapBase, MapInterface {

        public UnsortedTableMap() {
            _items = new Item[_defaultCap];
            _size = 0;
        }

        //Return the value associated with the given key, if it is found in the structure. O(n)
        public Object GetValue(int key) {
            for (int i = 0; i < _size; i++) {
                if (_items[i].Key == key) return _items[i].Value;
            }
            throw new ArgumentOutOfRangeException("Key", "the given key is not contains in the structure");
        }

        //Set the item in the structure denoted by this key at a particular value. If no item in the structure match the key insert a new item. Return a boolean determining if a new item was inserted to the structure. O(n)
        public bool SetValue(int key, Object value) {
            int index = -1;
            for (int i = 0; i < _size; i++) {
                if (_items[i].Key == key) {
                    index = i;
                    break;
                }
            }
            if (index == -1) {
                _items[_size++] = new Item(key, value);
                return true;
            } else {
                _items[index].Value = value;
                return false;
            }
        }

        //Remove the item matching the given key from the structure, if it is contains. Return a boolean determining if an item was deleted. O(n)
        public bool Remove(int key) {
            for (int i = 0; i < _size; i++) {
                if (_items[i].Key == key) {
                    for (int j = i; j < _items.Length - 1; j++) {
                        _items[j] = _items[j + 1];
                    }
                    _size--;
                    return true;
                }
            }
            return false;
        }
    }
}
