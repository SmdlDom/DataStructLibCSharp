using DataStructLib.StructInterface;
using System;

namespace DataStructLib.LinkedNodeStruct {
    public class DoublyLinkedList : DoublyLinkedBase, ListInterface {

        public DoublyLinkedList() {
            _head = null;
            _tail = null;
            _size = 0;
        }

        //Adds the given item object to the end of this list, adjusting the capacity of the list if needed.
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

        //Determine if the list contains the given item.
        public bool Contains(Object item) {
            DoublyLinkedNode curr = _head;
            while (curr != null) {
                if (curr.Item.Equals(item)) return true;
                curr = curr.Next;
            }
            return false;
        }

        //Return the index of the first occurrence of the given item.
        public int IndexOf(Object item) {
            try {
                return IndexOf(item, 0, _size);
            } catch (ArgumentOutOfRangeException) {
                return -1;
            }
        }

        //Return the index of the first occurrence of the given item beginning the search at index start.
        public int IndexOf(Object item, int start) {
            return IndexOf(item, start, _size - start);
        }

        //Return the index of the first occurrence of the given item beginning the search at index start, searching through a length of count.
        public int IndexOf(Object item, int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || start > _size - count) throw new ArgumentOutOfRangeException("count", "The count is out of range");


            if (start <= _size - count - start) { //Start search from the front
                DoublyLinkedNode curr = _head;
                for (int i = 0; i < start; i++) {
                    curr = curr.Next;
                }

                int res = start; 
                while (res < count + start) {
                    if (curr.Item.Equals(item)) return res;
                    curr = curr.Next;
                    res++;
                }
                return -1;
            } else { //Start search from the back
                DoublyLinkedNode curr = _tail;
                int startBack = _size - count - start;
                for (int i = 0; i < startBack; i++) {
                    curr = curr.Prev;
                }

                int ptr = startBack;
                int res = -1;
                while (ptr < count + startBack) {
                    if (curr.Item.Equals(item)) res = _size - 1 - ptr;
                    curr = curr.Prev;
                    ptr++;
                }
                return res;
            }
        }

        //Insert an item into this list at a given index.
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
                DoublyLinkedNode prev = _head;
                for (int i = 0; i < index - 1; i++) 
                    prev = prev.Next;
                newNode.Next = prev.Next;
                prev.Next.Prev = newNode;
                newNode.Prev = prev;
                prev.Next = newNode;
            } else { //Reach index from the back
                DoublyLinkedNode next = _tail;
                for (int i = 0; i < _size - 1 - index - 1; i++) 
                    next = next.Prev;
                newNode.Prev = next.Prev;
                next.Prev.Next = newNode;
                newNode.Next = next;
                next.Prev = newNode;
            }
        }

        //Return the index of the last occurrence of the given item, making the search backward trough the List
        public int LastIndexOf(Object item) {
            try {
                return LastIndexOf(item, 0, _size);
            } catch (ArgumentOutOfRangeException) {
                return -1;
            }
        }

        //Return the index of the last occurrence of the given item, making the search backward trough the list. Starting from the index start.
        public int LastIndexOf(Object item, int start) {
            return LastIndexOf(item, start, _size - start);            
        }

        //Return the index of the last occurrence of the given item. Starting from the index start.
        public int LastIndexOf(Object item, int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            if (start <= _size - count - start) { //Start search from the front    
                DoublyLinkedNode curr = _head;
                for (int i = 0; i < start; i++)
                    curr = curr.Next;

                int res = -1;
                for (int i = 0; i < count; i++) {
                    if (curr.Item.Equals(item)) res = i;
                    curr = curr.Next;
                }

                if (res == -1) return res;
                return res + start;
            } else { //Start search from the back
                DoublyLinkedNode curr = _tail;
                for (int i = 0; i < _size - start - count; i++)
                    curr = curr.Prev;

                for (int i = 0; i < count; i++) {
                    if (curr.Item.Equals(item)) return start + count - 1 - i;
                    curr = curr.Prev;
                }
                return -1;
            }
        }

        //Remove the first occurrence of item from the list, if it's contains.
        public void Remove(Object item) {
            try {
                RemoveSection(IndexOf(item), 1);
            } catch (ArgumentOutOfRangeException) {
                //pass
            }
        }

        //Remove the item at the given index.
        public void RemoveAtIndex(int index) {
            RemoveSection(index, 1);
        }

        //Remove the items trough the specified range.
        public void RemoveSection(int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            if (start == 0) { //Base case remove from front
                DoublyLinkedNode newHead = _head;
                for (int i = 0; i < count; i++) 
                    newHead = newHead.Next;
                
                newHead.Prev = null;
                _head = newHead;
            } else if (start + count == _size) { //Base case remove from back,
                DoublyLinkedNode newTail = _tail;
                for (int i = 0; i < count; i++) 
                    newTail = newTail.Prev;
 
                newTail.Next = null;
                _tail = newTail;
            } else if (start <= _size - count - start) { //reach the index from the front
                DoublyLinkedNode prev = _head;
                for (int i = 0; i < start - 1; i++)
                    prev = prev.Next;
                DoublyLinkedNode next = prev.Next;
                for (int i = 0; i < count; i++) 
                    next = next.Next;

                prev.Next = next;
                next.Prev = prev;
            } else { // reach the index from the back
                DoublyLinkedNode next = _tail;
                for (int i = 0; i < _size - 1 - start - count -1; i ++)
                    next = next.Prev;
           
                DoublyLinkedNode prev = next.Prev;
                for (int i = 0; i < count; i ++) 
                    prev = prev.Prev;

                prev.Next = next;
                next.Prev = prev;
            }
            _size -= count;
        }

        //Reverse the list.
        public void Reverse() {
            ReverseSection(0, _size);
        }

        //Reverse the items of the list trough the given range.
        public void ReverseSection(int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size + start) throw new ArgumentOutOfRangeException("count", "the count is out of range");

            if (count <= 1) return;

            DoublyLinkedNode begSegEnd = null;
            DoublyLinkedNode endSegBeg = null;
            if (start <= _size - start) { //Find begSegEnd from the beginning
                if (start != 0) begSegEnd = _head;
                for (int i = 0; i < start - 1; i++) 
                    begSegEnd = begSegEnd.Next;
                if (count < _size - start - count) { //Find endSegBeg from continuing from begSegEnd
                    endSegBeg = begSegEnd.Next;
                    for (int i = 0; i < count; i++) 
                        endSegBeg = endSegBeg.Next;
                } else { //Find endSegBeg from the ending
                    if (_size - start - count != 0) endSegBeg = _tail;
                    for (int i = 0; i < _size - start - count - 1; i++)
                        endSegBeg = endSegBeg.Prev;
                }
            } else { // Find endSegBeg from the ending then continue to find begSegEnd
                if (_size - start - count != 0) endSegBeg = _tail;
                for (int i = 0; i < _size - count - start - 1; i++)
                    endSegBeg = endSegBeg.Prev;
                begSegEnd = endSegBeg;
                for (int i = 0; i < count; i++)
                    begSegEnd = begSegEnd.Prev;
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
