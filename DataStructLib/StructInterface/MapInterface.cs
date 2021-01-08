using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.StructInterface {
    public interface MapInterface {

        //Return the value associated with the given key, if it is found in the structure.
        Object GetValue(int key);

        //Set the item in the structure denoted by this key at a particular value. If no item in the structure match the key insert a new item. Return a boolean determining if a new item was inserted to the structure.
        bool SetValue(int key, Object value);

        //Remove the item matching the given key from the structure, if it is contains. Return a boolean determining if an item was deleted.
        bool Remove(int key);

    }
}
