using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.StructInterface {
    public interface SetInterface {

        //Add the item to the set, if not yet present.
        void Add(Object item);

        //Determine if the set contains this item
        bool Contains(Object item);

        //Return the difference between this set and the one passed as an argument
        SetInterface Difference(SetInterface set);

        //return an array containing the elements of this set
        Object[] Enumerate();

        //Return the intersection between this set and the one pass as an argument
        SetInterface Intersection(SetInterface set); 

        //Remove the item from the set if it is present.
        void Remove(Object item);

        //Determine if this set contains as a subset the set pass as an argument.
        bool Subset(SetInterface set);

        //Return the union of this set with the one pass as an argument
        SetInterface Union(SetInterface set);
    }
}
