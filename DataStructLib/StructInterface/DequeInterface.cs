using System;

namespace DataStructLib.StructInterface {
    interface DequeInterface : QueueInterface {
        //Push an item to the front of the deque
        void EnqueueFront(Object item);

        //Pop the item at the back of the deque
        Object DequeueBack();

        //Peek at the item at the back of the deque
        Object PeakBack();
    }
}
