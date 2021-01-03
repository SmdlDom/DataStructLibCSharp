using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.LinkedNodeStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.LinkedNodeStruct.Tests {
    [TestClass()]
    public class LinkedQueueTests {

        private LinkedQueue queue = new LinkedQueue();

        [TestMethod()]
        public void EnqueueTest() {
            for (int i = 0; i < 4; i++) {
                queue.Enqueue(i);
            }
            Assert.AreEqual("{0, 1, 2, 3}", queue.ToString());
        }

        [TestMethod()]
        public void DequeueTest() {
            for (int i = 0; i < 4; i++) {
                queue.Enqueue(i);
            }
            Assert.AreEqual(0, queue.Dequeue());
            Assert.AreEqual("{1, 2, 3}", queue.ToString());
        }

        [TestMethod()]
        public void PeakTest() {
            for (int i = 0; i < 4; i++) {
                queue.Enqueue(i);
            }
            Assert.AreEqual(0, queue.Peak());
            Assert.AreEqual("{0, 1, 2, 3}", queue.ToString());
        }
    }
}