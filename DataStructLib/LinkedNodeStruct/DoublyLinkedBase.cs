using System;

namespace DataStructLib.LinkedNodeStruct {
    public abstract class DoublyLinkedBase : SinglyLinkedBase {
        protected class DoublyLinkedNode {
            private Object _item;
            private DoublyLinkedNode _next;
            private DoublyLinkedNode _prev;

            public DoublyLinkedNode(Object item) {
                _item = item;
                _next = null;
                _prev = null;
            }

            //Property to obtain and modify this node contained item.
            public Object Item {
                get {
                    return _item;
                }
                set {
                    _item = value;
                }
            }

            //Property to obtain and modify this node pointer to the next node.
            public DoublyLinkedNode Next {
                get {
                    return _next;
                }
                set {
                    _next = value;
                }
            }

            //Property to obtain and modify this node pointer to the previous node.
            public DoublyLinkedNode Prev {
                get {
                    return _prev;
                }
                set {
                    _prev = value;
                }
            }
        }

        protected new DoublyLinkedNode _head;
        protected DoublyLinkedNode _tail;

        //Convert this structure to an array.
        protected sealed override Object[] ToArray() {
            Object[] copy = new object[_size];
            DoublyLinkedNode curr = _head;
            for (int i = 0; i < _size; i++) {
                copy[i] = curr.Item;
                curr = curr.Next;
            }
            return copy;
        }
    }
}
