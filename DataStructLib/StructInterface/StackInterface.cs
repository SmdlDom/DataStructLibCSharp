using System;

namespace DataStructLib.StructInterface {
    interface StackInterface {
        //Push a new item on top of the stack
        void Push(Object item);

        //Pop the item on top of the stack
        Object Pop();

        //Peek at the item on top of the stack without popping it
        Object Peek();
    }
}
