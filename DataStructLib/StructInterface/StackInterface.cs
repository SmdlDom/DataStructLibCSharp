using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.StructInterface {
    public interface StackInterface {
        //Push a new item on top of the stack
        void Push(Object item);

        //Pop the item on top of the stack
        Object Pop();

    }
}
