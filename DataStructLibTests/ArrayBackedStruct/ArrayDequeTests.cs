using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.ArrayBackedStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass()]
    public class ArrayDequeTests {

        private ArrayDeque deque = new ArrayDeque();

        [TestMethod()]
        public void EnqueueFrontTest() {
            for (int i = 0; i < 3; i++) {
                deque.Enqueue(i);
            }
            Assert.AreEqual("{0, 1, 2}", deque.ToString());
            for (int i = 0; i < 3; i++) {
                deque.EnqueueFront(i);
            }
            Assert.AreEqual("{2, 1, 0, 0, 1, 2}", deque.ToString());
        }

        [TestMethod()]
        public void DequeueBackTest() {
            for (int i = 0; i < 3; i++) {
                deque.Enqueue(i);
            }
            for (int i = 0; i < 3; i++) {
                deque.EnqueueFront(i);
            }
            Assert.AreEqual(2, deque.DequeueBack());
            Assert.AreEqual("{2, 1, 0, 0, 1}", deque.ToString());
            for (int i = 0; i < 5; i++) {
                deque.DequeueBack();
            }
            Assert.AreEqual(true, deque.IsEmpty());
        }

        [TestMethod()]
        public void PeakBackTest() {
            for (int i = 0; i < 3; i++) {
                deque.Enqueue(i);
            }
            Assert.AreEqual(2, deque.PeakBack());
            Assert.AreEqual("{0, 1, 2}", deque.ToString());
        }
    }
}