﻿using DataStructLib.StructInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.LinkedNodeStruct {
    public class SinglyLinkedList : SinglyLinkedBase, ListInterface {

        public SinglyLinkedList() {
            _head = null;
            _size = 0;
        }

        //Adds the given item object to the end of this list, adjusting the capacity of the list if needed.
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

        //Determine if the list contains the given item.
        public bool Contains(Object item) {
            SinglyLinkedNode curr = _head;
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

            SinglyLinkedNode curr = _head;
            for (int i = 0; i < start; i++) {
                curr = curr.Next;
            }

            int res = start;
            while ( res < count + start) {
                if (curr.Item.Equals(item)) return res;
                curr = curr.Next;
                res++;
            }
            return -1;
        }

        //Insert an item into this list at a given index.
        public void Insert(Object item, int index) {
            if (index < 0 || index > _size) throw new ArgumentOutOfRangeException("index", "The index is out of range");

            _size++;
            SinglyLinkedNode newNode = new SinglyLinkedNode(item);
            if (index == 0) {
                newNode.Next = _head;
                _head = newNode;
                return;
            }
            
            SinglyLinkedNode prev = _head;
            for (int i = 0; i < index - 1; i++) 
                prev = prev.Next;
            newNode.Next = prev.Next;
            prev.Next = newNode;
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
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", " The count is out of range");

            SinglyLinkedNode curr = _head;
            for (int i = 0; i < _size - start - count; i++)
                curr = curr.Next;

            int res = -1;
            for (int i = 0; i < count; i++) {
                if (curr.Item.Equals(item)) res = i;
                curr = curr.Next;
            }

            if (res == -1) return res;
            return res + _size - start - count;
            
        }

        //Remove the first occurrence of item from the list, if it's contains.
        public void Remove(Object item) {
            RemoveSection(IndexOf(item), 1);
        }

        //Remove the item at the given index.
        public void RemoveAtIndex(int index) {
            RemoveSection(index, 1);
        }

        //Remove the items trough the specified range.
        public void RemoveSection(int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size - start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            _size -= count;
            if (start == 0) {
                SinglyLinkedNode newHead = _head;
                for (int i = 0; i < count; i++) {
                    newHead = newHead.Next;
                }
                _head = newHead;
                return;
            }

            SinglyLinkedNode prev = _head;
            for (int i = 0; i < start - 1; i++)
                prev = prev.Next;
            SinglyLinkedNode next = prev.Next;
            for (int i = 0; i < count; i++) 
                next = next.Next;

            prev.Next = next;
        }

        //Reverse the list.
        public void Reverse() {
            ReverseSection(0, _size);
        }

        //Reverse the items of the list trough the given range.
        public void ReverseSection(int start, int count) {
            if (start < 0 || start >= _size) throw new ArgumentOutOfRangeException("start", "The start index is out of range");
            if (count < 0 || count > _size + start) throw new ArgumentOutOfRangeException("count", "The count is out of range");

            SinglyLinkedNode begSegEnd = null;
            if (start != 0) {
                begSegEnd = _head;
                for (int i = 0; i < start - 1; i++) {
                    begSegEnd = begSegEnd.Next;
                }
            }

            SinglyLinkedNode endSegBeg;
            if (begSegEnd == null) {
                endSegBeg = _head;
            } else {
                endSegBeg = begSegEnd.Next;
            }

            for (int i = 0; i < count; i++) {
                endSegBeg = endSegBeg.Next;
            }



            SinglyLinkedNode curr;
            if (begSegEnd == null) {
                curr = _head;
            } else {
                curr = begSegEnd.Next;
            }

            for(int i = 0; i < count; i++) {
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
