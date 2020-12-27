using DataStructLib.StructInterface;
using System;

namespace DataStructLib.ArrayBackedStruct {
    //TODO handle array overflow
    public class ArrayList: ArrayBackedBase, ListInterface {

        public ArrayList() {
            _items = new Object[_defaultCap];
            _size = 0;
        }

        public ArrayList(int cap) {
            if (cap < 0) throw new ArgumentOutOfRangeException("cap", "Argument cap must be non-negative");

            if (cap < _defaultCap) _items = new Object[_defaultCap];
            else _items = new Object[cap];
            _size = 0;
        }

        //Sets or Gets the element at the given index
        public Object this[int index] {
            get {
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");
                return _items[index];
            }
            set {
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");
                _items[index] = value;
            }
        }

        //Adds the given item to the end of this list, adjusting the capacity of the list if needed.
        public void Append(Object item) {
            if (_size == _items.Length) EnsureCap(_size + 1);
            _items[_size++] = item;
        }

        //Determine if the list contains the given item in a linear time O(n).
        public bool Contains(Object item) {
            if (IndexOf(item) != -1) return true;
            return false;
        }

        //Return the index of the first occurrence of the given item. Return -1 if the item is not found
        public int IndexOf(Object item) {
            return IndexOf(item, 0, _size);
        }

        //Return the index of the first occurrence of the given item beginning the search at index start. Return -1 if the item is not found.
        public int IndexOf(Object item, int start) {
            return IndexOf(item, start, _size - start);
        }

        //Return the index of the first occurrence of the given item beginning the search at index start, searching through a length of count.
        public int IndexOf(Object item, int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || start > _size - count) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            if (item == null) {
                for (int i = start; i < start + count; i++)
                    if (_items[i] == null) return i;
                return -1;
            } else {
                for (int i = start; i < start + count; i++)
                    if ((_items[i] != null) && (_items[i].Equals(item))) return i;
                return -1;
            }
        }

        //Insert an item into this list at a given index.
        public void Insert(Object item, int index) {
            if (index < 0 || index > _size) throw new ArgumentOutOfRangeException("index", ToString());
            if(index == _size) {
                Append(item);
                return;
            }
            if (_size == _items.Length) EnsureCap(_size + 1);
            for (int i = _size - 1; i >= index; i--) {
                _items[i + 1] = _items[i];
            }
            _items[index] = item;
            _size++;
        }

        //Return the index of the last occurrence of the given item, making the search backward trough the List
        public int LastIndexOf(Object item) {
            return LastIndexOf(item, 0, _size);
        }

        //Return the index of the last occurrence of the given item, making the search backward trough the list. Starting from the index start.
        public int LastIndexOf(Object item, int start) {
            return LastIndexOf(item, start, _size - start);
        }

        //Return the index of the last occurrence of the given item, making the search backward trough the list. Starting from the index start.
        public int LastIndexOf(Object item, int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            if (item == null) {
                for (int i = _size - 1 - start; i > _size - 1 - start - count; i--)
                    if (_items[i] == null) return i;
                return -1;
            } else {
                for (int i = _size - 1 - start; i > _size - 1 - start - count; i--)
                    if ((_items[i] != null) && (_items[i].Equals(item))) return i;
                return -1;
            }
        }

        //Remove the first occurrence of item from the list, if it's contains.
        public void Remove(Object item) {
            RemoveRange(IndexOf(item), 1);
        }

        //Remove the item at the given index.
        public void RemoveAtIndex(int index) {
            RemoveRange(index, 1);
        }

        //Remove the items trough the specified range.
        public void RemoveRange(int start, int count) {
            for (int i = start; i < _size - count; i++) {
                _items[i] = _items[i + count];
            }
            _size -= count;
            ReduceCap();
        }

        //Reverse the list.
        public void Reverse() {
            ReverseRange(0, _size);
        }

        //Reverse the items of the list trough the given range.
        public void ReverseRange(int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size + start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            Object[] reversed = new Object[count];
            for (int i = start; i < count + start; i++) {
                reversed[count - (i - start + 1)] = _items[i];
            }

            for (int i = start; i < start + count; i++) {
                _items[i] = reversed[i - start];
            }
        }
    }
}
