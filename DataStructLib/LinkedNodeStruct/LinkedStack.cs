﻿using DataStructLib.StructInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.LinkedNodeStruct {
    public class LinkedStack : SinglyLinkedBase, StackInterface {

        public LinkedStack() {
            _head = null;
            _size = 0;
        }

        //Push a new item on top of the stack
        public void Push(Object item) {
            SinglyLinkedNode newHead = new SinglyLinkedNode(item);
            //throw new Exception((newHead.Item == null).ToString());
            newHead.Next = _head;
            _head = newHead;
            _size++;
        }

        //Pop the item on top of the stack
        public Object Pop() {
            Object res = _head.Item;
            _head = _head.Next;
            _size--;
            return res;
        }

        //Peek at the item on top of the stack without popping it
        public Object Peak() {
            return _head.Item;
        }
    }
}