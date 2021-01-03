using DataStructLib.StructInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.LinkedNodeStruct {
    public class LinkedDeque : LinkedQueue , DequeInterface {

        public LinkedDeque() {
            _head = null;
            _tail = null;
            _size = 0;
        }

        //Push an item to the front of the deque. O(1)
        public void EnqueueFront(Object item) {
            DoublyLinkedNode newHead = new DoublyLinkedNode(item);
            newHead.Next = _head;
            _head = newHead;
            if (_tail == null) _tail = newHead;
            _size++;
        }

        //Pop the item at the back of the deque. O(1)
        public Object DequeueBack() {
            Object res = _tail.Item;
            _tail = _tail.Prev;
            _size--;
            return res;
        }

        //Peek at the item at the back of the deque. O(1)
        public Object PeakBack() {
            return _tail.Item;
        }
    }
}
