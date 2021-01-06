using DataStructLib.ArrayBackedStruct;
using DataStructLib.LinkedNodeStruct.Abstract;
using DataStructLib.StructInterface;
using System;

namespace DataStructLib.LinkedNodeStruct {
    public class SinglyLinkedList : SinglyLinkedBase, ListInterface {

        public SinglyLinkedList() {
            _head = null;
            _size = 0;
        }

        public object this[int index] {
            get { //O(n)
                return GetNodeAt(index).Item;
            }
            set { //O(n)
                GetNodeAt(index).Item = value;
            }
        }

        //Utility function to get node at the given index. O(n)
        private SinglyLinkedNode GetNodeAt(int index) {
            if (index < 0 || index > _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");

            if (index == _size) return null;

            SinglyLinkedNode curr = _head;
            for (int i = 0; i < index; i++) {
                curr = curr.Next;
            }

            return curr;
        }

        //Utility function to get the node at the looked index given a certain node as a starting point. O(n)
        private SinglyLinkedNode GetNodeAtFrom(int index, SinglyLinkedNode start, int startIndex) {
            //Since this function is strictly use as an utility within this class, it is asserted that the parameters received are always within a proper domain.
            if (index < startIndex) throw new ArgumentOutOfRangeException("index", "The index is smaller then the starting index");
            if (index <= Math.Abs(index - startIndex)) return GetNodeAt(index);
            SinglyLinkedNode curr = start;
            for (int i = 0; i < index - startIndex; i++) {
                curr = curr.Next;
            }

            return curr;
        }

        //Adds the given item object to the end of this list, adjusting the capacity of the list if needed. O(n)
        public void Append(Object item) {
            if (_head == null) {
                _head = new SinglyLinkedNode(item);
                _size++;
                return;
            }

            SinglyLinkedNode curr = _head;
            while (curr.Next != null)
                curr = curr.Next;
            curr.Next = new SinglyLinkedNode(item);
            _size++;
        }

        //Determine if the list contains the given item. O(n)
        public bool Contains(Object item) {
            SinglyLinkedNode curr = _head;
            while (curr != null) {
                if (curr.Item.Equals(item)) return true;
                curr = curr.Next;
            }
            return false;
        }

        //Return the index of the first occurrence of the given item. O(n)
        public int IndexOf(Object item) {
            try {
                return IndexOf(item, 0, _size);
            } catch (ArgumentOutOfRangeException) {
                return -1;
            } 
            
        }

        //Return the index of the first occurrence of the given item beginning the search at index start. O(n)
        public int IndexOf(Object item, int start) {
            return IndexOf(item, start, _size - start);
        }

        //Return the index of the first occurrence of the given item beginning the search at index start, searching through a length of count. O(n)
        public int IndexOf(Object item, int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || start > _size - count) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            SinglyLinkedNode curr = GetNodeAt(start);

            int res = start;
            while ( res < count + start) {
                if (curr.Item.Equals(item)) return res;
                curr = curr.Next;
                res++;
            }
            return -1;
        }

        //Insert an item into this list at a given index. O(n)
        public void Insert(Object item, int index) {
            if (index < 0 || index > _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");

            _size++;
            SinglyLinkedNode newNode = new SinglyLinkedNode(item);
            if (index == 0) {
                newNode.Next = _head;
                _head = newNode;
                return;
            }
            
            SinglyLinkedNode prev = GetNodeAt(index - 1);
            newNode.Next = prev.Next;
            prev.Next = newNode;
        }

        //Return the index of the last occurrence of the given item, making the search backward trough the List. O(n)
        public int LastIndexOf(Object item) {
            try {
                return LastIndexOf(item, 0, _size);
            } catch (ArgumentOutOfRangeException) {
                return -1;
            }
        }

        //Return the index of the last occurrence of the given item, making the search backward trough the list. Starting from the index start. O(n)
        public int LastIndexOf(Object item, int start) {
            return LastIndexOf(item, start, _size - start);
        }

        //Return the index of the last occurrence of the given item. Starting from the index start. O(n)
        public int LastIndexOf(Object item, int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", " The count is out of range");

            SinglyLinkedNode curr = GetNodeAt(start);

            int res = -1;
            for (int i = 0; i < count; i++) {
                if (curr.Item.Equals(item)) res = i;
                curr = curr.Next;
            }

            if (res == -1) return res;
            return res + start;
            
        }

        //Remove the first occurrence of item from the list, if it's contains. O(n)
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

            if(start == 0 && count == _size) {
                _head = null;
                _size = 0;
                return;
            }

            if (start == 0) { //Base case remove from front
                SinglyLinkedNode newHead = GetNodeAt(count);
                _head = newHead;
            } else {
                SinglyLinkedNode prev = GetNodeAt(start - 1);
                SinglyLinkedNode next = GetNodeAtFrom(start + count, prev, start - 1);
                prev.Next = next;
            }
            _size -= count;
        }

        //Reverse the list. O(n)
        public void Reverse() {
            ReverseSection(0, _size);
        }

        //Reverse the items of the list trough the given range. O(n)
        public void ReverseSection(int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size + start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            SinglyLinkedNode begSegEnd = null;
            if (start != 0) begSegEnd = GetNodeAt(start - 1);


            SinglyLinkedNode endSegBeg;
            if (begSegEnd == null) {
                endSegBeg = GetNodeAt(count);
            } else {
                endSegBeg = GetNodeAtFrom(start + count, begSegEnd, start - 1);
            }


            SinglyLinkedNode curr = _head;
            if (begSegEnd != null) curr = begSegEnd.Next;

            for (int i = 0; i < count; i++) {
                SinglyLinkedNode nextCurr = curr.Next;
                curr.Next = endSegBeg;
                endSegBeg = curr;
                curr = nextCurr;
            }

            if (begSegEnd == null) {
                _head = endSegBeg;
                return;
            }

            begSegEnd.Next = endSegBeg;
        }
    }
}
