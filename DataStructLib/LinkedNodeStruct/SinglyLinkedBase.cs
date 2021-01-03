using System;

namespace DataStructLib.LinkedNodeStruct {
    public abstract class SinglyLinkedBase {

        protected class SinglyLinkedNode {
            private Object _item;
            private SinglyLinkedNode _next;

            public SinglyLinkedNode(Object item) {
                _item = item;
                _next = null;
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
            public SinglyLinkedNode Next {
                get {
                    return _next;
                }
                set {
                    _next = value;
                }
            }
        }

        protected SinglyLinkedNode _head;
        protected int _size;

        //Read-only property describing the number of element in this structure
        public int Size {
            get {
                return _size;
            }
        }

        //Clears the contents of this structure. O(1)
        public void Clear() {
            _head = null;
            _size = 0;
        }

        //Check if this structure is empty. O(1)
        public bool IsEmpty() {
            if (_size == 0) return true;
            return false;
        }

        //Convert this structure to an array. O(n)
        protected virtual Object[] ToArray() {
            Object[] copy = new Object[_size];
            SinglyLinkedNode curr = _head;
            for (int i = 0; i < _size; i++) {
                copy[i] = curr.Item;
                curr = curr.Next;
            }
            return copy;
        }

        //Return a string representation of this structure. O(n)

        public sealed override string ToString() {
            return String.Concat("{", String.Concat(String.Join(", ", ToArray()), "}"));
        }
    }
}
