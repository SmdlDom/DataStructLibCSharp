
using System;

namespace DataStructLib.StructInterface {
    public interface ListInterface {

        Object this[int index] { get; set; }

        int Size { get; }

        //Adds the given item object to the end of this list, adjusting the capacity of the list if needed.
        void Append(Object item);

        //Determine if the list contains the given item.
        bool Contains(Object item);

        //Return the index of the first occurrence of the given item.
        int IndexOf(Object item);

        //Return the index of the first occurrence of the given item beginning the search at index start.
        int IndexOf(Object item, int start);

        //Return the index of the first occurrence of the given item beginning the search at index start, searching through a length of count.
        int IndexOf(Object item, int start, int count);

        //Insert an item into this list at a given index.
        void Insert(Object item, int index);

        //Return the index of the last occurrence of the given item.
        int LastIndexOf(Object item);

        //Return the index of the last occurrence of the given item. Starting from the index start.
        int LastIndexOf(Object item, int start);

        //Return the index of the last occurrence of the given item, making the search backward trough the list. Starting from the index start.
        int LastIndexOf(Object item, int start, int count);

        //Remove the first occurrence of item from the list, if it's contains.
        void Remove(Object item);

        //Remove the item at the given index.
        void RemoveAtIndex(int index);

        //Remove the items trough the specified range.
        void RemoveSection(int start, int count);

        //Reverse the list.
        void Reverse();

    }
}
