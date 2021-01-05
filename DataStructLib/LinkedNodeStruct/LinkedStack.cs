using DataStructLib.LinkedNodeStruct.Abstract;
using DataStructLib.StructInterface;
using System;

namespace DataStructLib.LinkedNodeStruct {
    public class LinkedStack : SinglyLinkedBase, StackInterface {

        public LinkedStack() {
            _head = null;
            _size = 0;
        }

        //Push a new item on top of the stack. O(1)
        public void Push(Object item) {
            SinglyLinkedNode newHead = new SinglyLinkedNode(item);
            newHead.Next = _head;
            _head = newHead;
            _size++;
        }

        //Pop the item on top of the stack. O(1)
        public Object Pop() {
            Object res = _head.Item;
            _head = _head.Next;
            _size--;
            return res;
        }

        //Peek at the item on top of the stack without popping it. O(1)
        public Object Peak() {
            return _head.Item;
        }
    }
}
