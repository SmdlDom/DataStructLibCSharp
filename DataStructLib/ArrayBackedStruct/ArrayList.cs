using DataStructLib.ArrayBackedStruct.Abstract;
using DataStructLib.StructInterface;
using System;

namespace DataStructLib.ArrayBackedStruct {

    public class ArrayList : ArrayBacked, ListInterface {
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
            get { //O(1)
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");
                return _items[index];
            }
            set { //O(1)
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");
                _items[index] = value;
            }
        }

        //Adds the given item to the end of this list, adjusting the capacity of the list if needed. O(1) amortized
        public void Append(Object item) { 
            if (_size == _items.Length) EnsureCap(_size + 1);
            _items[_size++] = item;
        }

        //Determine if the list contains the given item. O(n)
        public bool Contains(Object item) { 
            if (IndexOf(item) != -1) return true;
            return false;
        }

        //Return the index of the first occurrence of the given item. Return -1 if the item is not found. O(n)
        public int IndexOf(Object item) {
            try {
                return IndexOf(item, 0, _size);
            } catch (ArgumentOutOfRangeException) {
                return -1;
            }
        }

        //Return the index of the first occurrence of the given item beginning the search at index start. Return -1 if the item is not found. O(n)
        public int IndexOf(Object item, int start) {
            return IndexOf(item, start, _size - start);
        }

        //Return the index of the first occurrence of the given item beginning the search at index start, searching through a length of count. O(n)r
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

        //Insert an item into this list at a given index. O(n)
        public void Insert(Object item, int index) {
            if (index < 0 || index > _size) throw new ArgumentOutOfRangeException("index", "the index is out of range");
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

        //Return the index of the last occurrence of the given item, making the search backward trough the List. O(n)
        public int LastIndexOf(Object item) {
            return LastIndexOf(item, 0, _size);
        }

        //Return the index of the last occurrence of the given item, making the search backward trough the list. Starting from the index start. O(n)
        public int LastIndexOf(Object item, int start) {
            return LastIndexOf(item, start, _size - start);
        }

        //Return the index of the last occurrence of the given item. Starting from the index start. O(n)
        public int LastIndexOf(Object item, int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            //throw new Exception((_items.Length).ToString());

            int res = -1;
            if (item == null) {
                for (int i = start; i < count + start; i++)
                    if (_items[i] == null) res = i;
                return res;
            } else {
                for (int i = start; i < count + start; i++)
                    if ((_items[i] != null) && (_items[i].Equals(item))) res = i;
                return res;
            }
        }

        //Remove the first occurrence of item from the list, if it's contains. O(2n) TODO make this O(n)
        public void Remove(Object item) {
            try {
                RemoveSection(IndexOf(item), 1);
            } catch (ArgumentOutOfRangeException) {
                //pass
            }
        }

        //Remove the item at the given index. O(n)
        public void RemoveAtIndex(int index) {
            RemoveSection(index, 1);
        }

        //Remove the items trough the specified range. O(n)
        public void RemoveSection(int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            for (int i = start; i < _size - count; i++) {
                _items[i] = _items[i + count];
            }
            _size -= count;
            ReduceCap();
        }

        //Reverse the list. O(n)
        public void Reverse() { 
            ReverseSection(0, _size);
        }

        //Reverse the items of the list trough the given range. O(n)
        public void ReverseSection(int start, int count) {
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
