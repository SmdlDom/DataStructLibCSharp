using System;

namespace DataStructLib.StructInterface {
    interface ListInterface {
        //Adds the given item object to the end of this list, adjusting the capacity of the list if needed.
        void Append(Object item);

        //TODO implement a variant of Append that let you append any list implementing this interface. Need to implement an Iterator

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

        //TODO implement a variant of Insert that insert any list implementing this interface. Need to implement an Iterator

        //Return the index of the last occurrence of the given item, making the search backward trough the List
        int LastIndexOf(Object item);

        //Return the index of the last occurrence of the given item, making the search backward trough the list. Starting from the index start.
        int LastIndexOf(Object item, int start);

        //Return the index of the last occurrence of the given item, making the search backward trough the list. Starting from the index start.
        int LastIndexOf(Object item, int start, int count);

        //Remove the first occurrence of item from the list, if it's contains.
        void Remove(Object item);

        //Remove the item at the given index.
        void RemoveAtIndex(int index);

        //Remove the items trough the specified range.
        void RemoveRange(int start, int count);

        //Reverse the list.
        void Reverse();

        //Reverse the items of the list trough the given range.
        void ReverseRange(int start, int count);

        //TODO implement a sorting algorithm
    }
}
