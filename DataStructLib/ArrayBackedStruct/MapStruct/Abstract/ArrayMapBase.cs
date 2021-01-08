using DataStructLib.ArrayBackedStruct.Abstract;
using System;
using System.Text;

namespace DataStructLib.MapStruct.Abstract {
    public abstract class ArrayMapBase : ArrayBacked {

        //Nested class for map structure representing a pair of key-value. 
        protected class Item {

            private int _key;
            private Object _value;

            public Item(int key, Object value) {
                _key = key;
                _value = value;
            }

            //Read-Only property to obtain the key of this item. O(n)
            public int Key => _key; 

            //Property to access and modify this item value. O(n)
            public Object Value {
                get => _value;
                set => _value = value;

            }

            //Determine if two item contains the same pair of value. O(n)
            public bool Equals(Item other) {
                return _key == other.Key && _value.Equals(other.Value);
            }

            //Determine if the two item have the same key. O(n)
            public bool KeysEquals(Item other) {
                return _key == other.Key;
            }

            //Determine if this item have a key which is less then the pass Item key. O(n)
            public bool LT(Item other) {
                return _key < other.Key;
            }

            //Determine if this item have a key which is greater or equal then the pass Item key. O(n)
            public bool GE(Item other) {
                return _key >= other.Key;
            }

            //Return a string representation of this item
            public sealed override string ToString() {
                return String.Concat("<", _key.ToString(),", ", _value.ToString(), ">");
            }
        }

        protected new Item[] _items;

        //Convert this array map to an array. O(n)
        protected new Item[] ToArray() {
            Item[] copy = new Item[_size];
            for (int i = 0; i < _size; i++) {
                copy[i] = _items[i];
            }
            return copy;
        }

        //Return a string representation. O(n)
        public sealed override string ToString() {
            Item[] items = ToArray();
            StringBuilder sb = new StringBuilder("{");
            for (int i = 0; i < items.Length; i++) {
                sb.Append(items[i].ToString());
                if (i != items.Length - 1) sb.Append(", "); 
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
