using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.ArrayBackedStruct.MapStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.MapStruct.Tests {
    [TestClass()]
    public class PriorityQueueTests {

        private PriorityQueue queue = new PriorityQueue();

        [TestMethod()]
        public void PushTest() {
            queue.Push(0, 1);
            queue.Push(0, 3);
            queue.Push(1, 3);
            queue.Push(3, 4);
            queue.Push(2, 5);

            Assert.AreEqual("{<0:1, 3>, <1:3>, <2:5>, <3:4>}", queue.ToString());
        }

        [TestMethod()]
        public void PopTest() {
            queue.Push(0, 1);
            queue.Push(0, 3);
            queue.Push(1, 3);
            queue.Push(3, 4);
            queue.Push(2, 5);

            Assert.AreEqual(1, queue.Pop());
            Assert.AreEqual(3, queue.Pop());
            Assert.AreEqual(3, queue.Pop());
            Assert.AreEqual("{<2:5>, <3:4>}", queue.ToString());
        }

        [TestMethod()]
        public void PeakTest() {
            queue.Push(0, 1);
            queue.Push(0, 3);
            queue.Push(1, 3);
            queue.Push(3, 4);
            queue.Push(2, 5);

            Assert.AreEqual(1, queue.Peak());
            Assert.AreEqual("{<0:1, 3>, <1:3>, <2:5>, <3:4>}", queue.ToString());
        }
    }
}