using DataStructLib.ArrayBackedStruct;
using DataStructLib.LinkedNodeStruct.Abstract;
using DataStructLib.StructInterface;
using System;

namespace DataStructLib.LinkedNodeStruct {
    public class DoublyLinkedList : DoublyLinkedBase, ListInterface {

        public DoublyLinkedList() {
            _head = null;
            _tail = null;
            _size = 0;
        }

        //TODO make a reach index function
        public object this[int index] {
            get { //O(n)
                return GetNodeAt(index).Item;
            }
            set { //O(n)
                GetNodeAt(index).Item = value;
            }
        }

        //Utility function to get node at the given index. O(n)
        private DoublyLinkedNode GetNodeAt(int index) {
            if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");

            DoublyLinkedNode curr = _head;
            if (index <= _size / 2) {
                for (int i = 0; i < index; i++) {
                    curr = curr.Next;
                }
            } else {
                curr = _tail;
                for (int i = 0; i < _size - index - 1; i++) {
                    curr = curr.Prev;
                }
            }
            return curr;
        }

        //Utility function to get the node at the looked index given a certain node as a starting point.
        private DoublyLinkedNode GetNodeAtFrom(int index, DoublyLinkedNode start, int startIndex) {
            //Since this function is strictly use as an utility within this class, it is asserted that the parameters received are always within a proper domain.
            if (index <= Math.Abs(index - startIndex) || _size - index < Math.Abs(index - startIndex)) return GetNodeAt(index);
            DoublyLinkedNode curr = start;
            if (index - startIndex > 0) { //look moving forward
                for (int i = 0; i <= index - startIndex; i++) {
                    curr = curr.Next;
                }
            } else if (index - startIndex < 0) {//look moving backward
                for (int i = 0; i <= startIndex - index; i++) {
                    curr = curr.Prev;
                }
            }
            return curr;
        }

        //Adds the given item object to the end of this list, adjusting the capacity of the list if needed. O(1)
        public void Append(Object item) {
            DoublyLinkedNode newTail = new DoublyLinkedNode(item);
            _size++;
            if(_head == null) {
                _head = newTail;
                _tail = newTail;
                return;
            }

            newTail.Prev = _tail;
            _tail.Next = newTail;
            _tail = newTail;
        }

        //Determine if the list contains the given item. O(n)
        public bool Contains(Object item) {
            DoublyLinkedNode curr = _head;
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

            
            if (start <= _size - count - start) { //Start search from the front
                DoublyLinkedNode curr = GetNodeAt(start);
                int res = start;
                while (res < count + start) {
                    if (curr.Item.Equals(item)) return res;
                    curr = curr.Next;
                    res++;
                }
                return -1;
            } else { //Start search from the back
                DoublyLinkedNode curr = GetNodeAt(start + count - 1);
                
                int ptr = 0;
                int res = -1;
                while (ptr < count ) {
                    if (curr.Item.Equals(item)) res = start + count - ptr -1;
                    curr = curr.Prev;
                    ptr++;
                }
                return res;
            }
        }

        //Insert an item into this list at a given index. O(n)
        public void Insert(Object item, int index) {
            if (index < 0 || index > _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");

            _size++;
            DoublyLinkedNode newNode = new DoublyLinkedNode(item);
            if (index == 0) { //Base case insert in front
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
                return;
            } else if (index == _size - 1) {  //Base case insert at the back
                newNode.Prev = _tail;
                _tail.Next = newNode;
                _tail = newNode;
                return;
            } else if (index  < _size / 2) { //reach index from the front
                DoublyLinkedNode prev = GetNodeAt(index - 1);
                newNode.Next = prev.Next;
                prev.Next.Prev = newNode;
                newNode.Prev = prev;
                prev.Next = newNode;
            } else { //Reach index from the back
                DoublyLinkedNode next = GetNodeAt(index + 1);
                newNode.Prev = next.Prev;
                next.Prev.Next = newNode;
                newNode.Next = next;
                next.Prev = newNode;
            }
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
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            if (start <= _size - count - start) { //Start search from the front    
                DoublyLinkedNode curr = GetNodeAt(start);
                int res = -1;
                for (int i = 0; i < count; i++) {
                    if (curr.Item.Equals(item)) res = i + start;
                    curr = curr.Next;
                }
                return res;
            } else { //Start search from the back
                DoublyLinkedNode curr = GetNodeAt(start + count - 1);
                for (int i = 0; i < count; i++) {
                    if (curr.Item.Equals(item)) return start + count - 1 - i;
                    curr = curr.Prev;
                }
                return -1;
            }
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

            if (start == 0 && count == _size) { //fully empty the list
                _head = null;
                _tail = null;
                _size = 0;
                return;
            }

            if (start == 0) { //Base case remove from front
                DoublyLinkedNode newHead = GetNodeAt(count);
                newHead.Prev = null;
                _head = newHead;
            } else if (start + count == _size) { //Base case remove from back,
                DoublyLinkedNode newTail = GetNodeAt(start -1);
                newTail.Next = null;
                _tail = newTail;
            } else if (start <= _size - count - start) { //reach the index from the front
                DoublyLinkedNode prev = GetNodeAt(start -1);
                DoublyLinkedNode next = GetNodeAtFrom(start + count, prev, start - 1);
                prev.Next = next;
                next.Prev = prev;
            } else { // reach the index from the back
                DoublyLinkedNode next = GetNodeAt(start + count);
                DoublyLinkedNode prev = GetNodeAtFrom(start - 1, next, start + count);
                prev.Next = next;
                next.Prev = prev;
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
            if (count < 0 || count > _size + start) throw new ArgumentOutOfRangeException("count", "the count is out of range");

            if (count <= 1) return;

            DoublyLinkedNode begSegEnd = null;
            DoublyLinkedNode endSegBeg = null;
            if (start <= _size - start) { //Find begSegEnd from the beginning
                if (start != 0) begSegEnd = GetNodeAt(start -1);
                if (count < _size - start - count && endSegBeg != null) { //Find endSegBeg from continuing from begSegEnd
                    endSegBeg = GetNodeAtFrom(start + count, begSegEnd, start -1); 
                } else { //Find endSegBeg
                    if (_size - start - count != 0) endSegBeg = GetNodeAt(start + count);
                }
            } else { // Find endSegBeg from the ending then continue to find begSegEnd
                if (_size - start - count != 0) endSegBeg = GetNodeAt(start + count);
                begSegEnd = GetNodeAtFrom(start - 1, endSegBeg, start + count); 
            }

            DoublyLinkedNode curr = _head;
            if (begSegEnd != null) curr = begSegEnd.Next;
            if (endSegBeg == null) _tail = curr;

            for (int i = 0; i < count; i++) {
                DoublyLinkedNode nextCurr = curr.Next;
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
