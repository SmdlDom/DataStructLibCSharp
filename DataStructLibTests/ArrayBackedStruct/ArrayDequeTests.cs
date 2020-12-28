using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.ArrayBackedStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass()]
    public class ArrayDequeTests {

        private ArrayDeque arrayDeque = new ArrayDeque();

        [TestMethod()]
        public void ArrayDequeTest() {
            for (int i = 0; i < 4; i++) {
                arrayDeque.Enqueue(i);
                arrayDeque.EnqueueFront(i * 2);
            }
            Assert.AreEqual("{6, 4, 2, 0, 0, 1, 2, 3}", arrayDeque.ToString());
            Assert.AreEqual("{0, 1, 2, 3, 6, 4, 2, 0}", arrayDeque.ToStringInternalRep());

            for (int i = 0; i < 5; i++) {
                arrayDeque.Dequeue();
            }
            Assert.AreEqual("{1, 2, 3}", arrayDeque.ToString());
            Assert.AreEqual("{0, 1, 2, 3, 6, 4, 2, 0}", arrayDeque.ToStringInternalRep());

            for (int i = 0; i < 7; i++) {
                arrayDeque.Enqueue(i);
            }
            Assert.AreEqual("{1, 2, 3, 0, 1, 2, 3, 4, 5, 6}", arrayDeque.ToString());
            Assert.AreEqual("{1, 2, 3, 0, 1, 2, 3, 4, 5, 6, , , , , , }", arrayDeque.ToStringInternalRep());

            arrayDeque.EnqueueFront(9);
            Assert.AreEqual("{9, 1, 2, 3, 0, 1, 2, 3, 4, 5, 6}", arrayDeque.ToString());
            Assert.AreEqual("{1, 2, 3, 0, 1, 2, 3, 4, 5, 6, , , , , , 9}", arrayDeque.ToStringInternalRep());

            for (int i = 0; i < 2; i++) {
                arrayDeque.DequeueBack();
            }

            Assert.AreEqual(4, arrayDeque.DequeueBack());

            Assert.AreEqual("{9, 1, 2, 3, 0, 1, 2, 3}", arrayDeque.ToString());
            Assert.AreEqual("{1, 2, 3, 0, 1, 2, 3, 4, 5, 6, , , , , , 9}", arrayDeque.ToStringInternalRep());
            Assert.AreEqual(9, arrayDeque.Peak());
            Assert.AreEqual(3, arrayDeque.PeakBack());

            for (int i= 0; i < 5; i++) {
                arrayDeque.DequeueBack();
            }
            Assert.AreEqual("{9, 1, 2}", arrayDeque.ToString());
            Assert.AreEqual("{9, 1, 2, , , , , }", arrayDeque.ToStringInternalRep());
        }
    }
}