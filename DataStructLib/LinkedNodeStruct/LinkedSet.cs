using DataStructLib.StructInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.LinkedNodeStruct {
    public class LinkedSet : SinglyLinkedBase, SetInterface {

        public LinkedSet() {
            _head = null;
            _size = 0;
        }

        private LinkedSet(Object[] obj) {
            if (obj.Length == 0) {
                _head = null;
                _size = 0;
            } else {
                _head = new SinglyLinkedNode(obj[0]);
                _size = 1;
                SinglyLinkedNode curr = _head;
                for (int i = 1; i < obj.Length; i++) {
                    SinglyLinkedNode newNode = new SinglyLinkedNode(obj[i]);
                    curr.Next = newNode;
                    curr = newNode;
                    _size++;
                }
            }
        }

        //Add the item to the set, if not yet present. O(n)
        public void Add(Object item) {
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

        //Determine if the set contains this item. O(n)
        public bool Contains(Object item) {
            SinglyLinkedNode curr = _head;
            while (curr != null) {
                if (curr.Item.Equals(item)) return true;
                curr = curr.Next;
            }
            return false;
        }

        //Return the difference between this set and the one passed as an argument. O(n*m)
        public SetInterface Difference(SetInterface set) {
            LinkedSet res = new LinkedSet();
            SinglyLinkedNode curr = _head;
            while (curr != null) {
                if (!set.Contains(curr.Item)) res.Add(curr.Item);
                curr = curr.Next;
            }
            return res;
        }

        //return an array containing the elements of this set. O(n)
        public Object[] Enumerate() {
            return ToArray();
        }

        //Return the intersection between this set and the one pass as an argument O(n*m)
        public SetInterface Intersection(SetInterface set) {
            LinkedSet res = new LinkedSet();
            SinglyLinkedNode curr = _head;
            while (curr != null) {
                if (set.Contains(curr.Item)) res.Add(curr.Item);
                curr = curr.Next;
            }
            return res;
        }

        //Remove the item from the set if it is present. O(n)
        public void Remove(Object item) {
            SinglyLinkedNode curr = _head;
            if (curr.Item.Equals(item)) {
                _head = _head.Next;
                _size--;
                return;
            }
            SinglyLinkedNode prev = curr;
            curr = curr.Next;
            while (curr != null) {
                if (curr.Item.Equals(item)) {
                    prev.Next = curr.Next;
                    _size--;
                    break;
                }
                prev = curr;
                curr = curr.Next;
            }
        }

        //Determine if this set contains as a subset the set pass as an argument. O(n*m)
        public bool Subset(SetInterface set) {
            Object[] setObj = set.Enumerate();
            if (setObj.Length > _size) return false;
            for (int i = 0; i < setObj.Length; i++) {
                if (!Contains(setObj[i])) return false;
            }
            return true;
        }

        //Return the union of this set with the one pass as an argument. O(n*m)
        public SetInterface Union(SetInterface set) {
            LinkedSet res = new LinkedSet(set.Enumerate());
            SinglyLinkedNode curr = _head;
            while (curr != null) {
                if (!set.Contains(curr.Item)) res.Add(curr.Item);
                curr = curr.Next;
            }
            return res;
        }
    }
}
