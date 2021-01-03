﻿using DataStructLib.StructInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.LinkedNodeStruct {
    public class LinkedQueue : DoublyLinkedBase, QueueInterface {

        public LinkedQueue() {
            _head = null;
            _tail = null;
            _size = 0;
        }

        //Push a new item to the queue
        public void Enqueue(Object item) {
            DoublyLinkedNode newTail = new DoublyLinkedNode(item);
            if (_head == null) {
                _head = newTail;
            } else {
                newTail.Prev = _tail;
                _tail.Next = newTail;
            }
            _tail = newTail;
            _size++;
        }

        //Pop an item from the queue
        public Object Dequeue() {
            Object res = _head.Item;
            _head = _head.Next;
            _size--;
            return res;
        }

        //Peek at the item at the front of the queue
        public Object Peak() {
            return _head.Item;
        }
    }
}