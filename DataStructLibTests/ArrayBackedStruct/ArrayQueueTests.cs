using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass()]
    public class ArrayQueueTests {

        private ArrayQueue arrayQueue = new ArrayQueue();
     
        [TestMethod()]
        public void ArrayQueueTest() {
            arrayQueue.Enqueue(0);
            arrayQueue.Enqueue(1);
            arrayQueue.Enqueue(2);
            Assert.AreEqual("{0, 1, 2}", arrayQueue.ToString());
            Assert.AreEqual(3, arrayQueue.Size);
            Assert.AreEqual(0, arrayQueue.Peak());
            Assert.AreEqual(0, arrayQueue.Dequeue());
            Assert.AreEqual("{1, 2}", arrayQueue.ToString());
            Assert.AreEqual("{0, 1, 2, , , , , }", arrayQueue.ToStringInternalRep());
            Assert.AreEqual(1, arrayQueue.Dequeue());
            Assert.AreEqual(2, arrayQueue.Dequeue());
            Assert.AreEqual(0, arrayQueue.Size);
            Assert.AreEqual(3, arrayQueue.Pointer);
            Assert.AreEqual("{}", arrayQueue.ToString());
            arrayQueue.Enqueue(0);
            arrayQueue.Enqueue(1);
            arrayQueue.Enqueue(2);
            arrayQueue.Enqueue(0);
            arrayQueue.Enqueue(1);
            Assert.AreEqual("{0, 1, 2, 0, 1, 2, 0, 1}", arrayQueue.ToStringInternalRep());
            Assert.AreEqual("{0, 1, 2, 0, 1}", arrayQueue.ToString());
            arrayQueue.Enqueue(2);
            Assert.AreEqual("{2, 1, 2, 0, 1, 2, 0, 1}", arrayQueue.ToStringInternalRep());
            Assert.AreEqual("{0, 1, 2, 0, 1, 2}", arrayQueue.ToString());
            arrayQueue.Enqueue(0);
            arrayQueue.Enqueue(1);
            Assert.AreEqual("{0, 1, 2, 0, 1, 2, 0, 1}", arrayQueue.ToString());
            Assert.AreEqual("{2, 0, 1, 0, 1, 2, 0, 1}", arrayQueue.ToStringInternalRep());
            arrayQueue.Enqueue(2); 
            Assert.AreEqual("{0, 1, 2, 0, 1, 2, 0, 1, 2}", arrayQueue.ToString());
            Assert.AreEqual("{0, 1, 2, 0, 1, 2, 0, 1, 2, , , , , , , }", arrayQueue.ToStringInternalRep());
        }
    }
}