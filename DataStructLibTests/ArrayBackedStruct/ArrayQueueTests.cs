using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.ArrayBackedStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass()]
    public class ArrayQueueTests {

        private ArrayQueue queue = new ArrayQueue();

        [TestMethod()]
        public void EnqueueTest() {
            for (int i = 0; i < 6; i++) {
                queue.Enqueue(i);
            }

            Assert.AreEqual("{0, 1, 2, 3, 4, 5}", queue.ToString());
        }

        [TestMethod()]
        public void DequeueTest() {
            for (int i = 0; i < 6; i++) {
                queue.Enqueue(i);
            }
            
            for(int i = 0; i < 2; i++) {
                queue.Dequeue();
            }
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual("{3, 4, 5}", queue.ToString());
        }

        [TestMethod()]
        public void PeakTest() {
            for (int i = 0; i < 6; i++) {
                queue.Enqueue(i);
            }
            Assert.AreEqual(0, queue.Peak());
            Assert.AreEqual("{0, 1, 2, 3, 4, 5}", queue.ToString());
        }
    }
}