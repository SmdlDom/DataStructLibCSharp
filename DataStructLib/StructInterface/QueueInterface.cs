using System;

namespace DataStructLib.StructInterface {
    public interface QueueInterface {
        //Push a new item to the queue
        void Enqueue(Object item);

        //Pop an item from the queue
        Object Dequeue();

        //Peek at the item at the front of the queue
        Object Peak();
    }
}
