using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.LinkedNodeStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.LinkedNodeStruct.Tests {
    [TestClass()]
    public class LinkedDequeTests {

        private LinkedDeque deque = new LinkedDeque();

        [TestMethod()]
        public void EnqueueFrontTest() {
            for (int i = 0; i < 4; i++) {
                deque.EnqueueFront(i);
            }
            Assert.AreEqual("{3, 2, 1, 0}", deque.ToString());
        }

        [TestMethod()]
        public void DequeueBackTest() {
            for (int i = 0; i < 4; i++) {
                deque.EnqueueFront(i);
            }
            Assert.AreEqual(0, deque.DequeueBack());
            Assert.AreEqual("{3, 2, 1}", deque.ToString());
        }

        [TestMethod()]
        public void PeakBackTest() {
            for (int i = 0; i < 4; i++) {
                deque.EnqueueFront(i);
            }
            Assert.AreEqual(0, deque.PeakBack());
            Assert.AreEqual("{3, 2, 1, 0}", deque.ToString());
        }
    }
}