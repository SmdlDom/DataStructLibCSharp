using DataStructLib.StructInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct {
    public class ArraySet : ArrayBackedBase, SetInterface {

        public ArraySet() {
            _items = new object[_defaultCap];
            _size = 0;
        }

        private ArraySet(Object[] obj) {
            _items = obj;
            _size = obj.Length;
        }

        //Add the item to the set, if not yet present. O(1) amortized.
        public void Add(Object item) {
            if (_size == _items.Length) EnsureCap(_size + 1);
            _items[_size++] = item;
        }

        //Determine if the set contains this item. O(n)
        public bool Contains(Object item) {
            for (int i = 0; i < _size; i++) {
                if ((_items[i] != null) && (_items[i].Equals(item))) return true;
            }
            return false;
        }

        //Return the difference between this set and the one passed as an argument. O(n*m)
        public SetInterface Difference(SetInterface set) {
            ArraySet res = new ArraySet();
            for (int i = 0; i < _size; i++) {
                if (!set.Contains(_items[i])) res.Add(_items[i]);
            }
            return res;
        }

        //return an array containing the elements of this set. O(n)
        public Object[] Enumerate() {
            return ToArray();
        }

        //Return the intersection between this set and the one pass as an argument. O(n*m)
        public SetInterface Intersection(SetInterface set) {
            ArraySet res = new ArraySet();
            for (int i = 0; i < _size; i++) {
                if (set.Contains(_items[i])) res.Add(_items[i]);
            }
            return res;
        }

        //Remove the item from the set if it is present. O(n)
        public void Remove(Object item) {
            for (int i = 0; i < _size; i++) {
                if ((_items[i] != null) && (_items[i].Equals(item))) {
                    for (int j = i; j < _size - 1; j++) {
                        _items[j] = _items[j + 1];
                    }
                    _size--;
                    break;
                }
            }
        }

        //Determine if this set contains as a subset the set pass as an argument. O(n*m)
        public bool Subset(SetInterface set) {
            Object[] setObj = set.Enumerate();
            if (setObj.Length > _size) return false;
            for (int i = 0; i < setObj.Length; i++) {
                if (!Contains(setObj[i])) return false;
            }
            return true;
        }

        //Return the union of this set with the one pass as an argument. O(n*m)
        public SetInterface Union(SetInterface set) {
            ArraySet res = new ArraySet(set.Enumerate());
            for (int i = 0; i < _size; i++) {
                if (!set.Contains(_items[i])) res.Add(_items[i]);
            }
            return res;
        }
    }
}
