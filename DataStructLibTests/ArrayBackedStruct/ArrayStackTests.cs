using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.ArrayBackedStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass()]
    public class ArrayStackTests {

        private ArrayStack stack = new ArrayStack();

        [TestMethod()]
        public void PushTest() {
            for (int i = 0; i < 8; i++) {
                stack.Push(i);
            }

            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6, 7}", stack.ToString());

            stack.Push(8);
            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6, 7, 8}", stack.ToString());
            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6, 7, 8, , , , , , , }", stack.ToStringInternalRep());
        }

        [TestMethod()]
        public void PopTest() {
            for (int i = 0; i < 9; i++) {
                stack.Push(i);
            }
            Assert.AreEqual(8, stack.Pop());
            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6, 7, 8, , , , , , , }", stack.ToStringInternalRep());
            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6, 7}", stack.ToString());

            for (int i = 0; i < 5; i++) {
                stack.Pop();
            }
            Assert.AreEqual("{0, 1, 2}", stack.ToString());
            Assert.AreEqual("{0, 1, 2, , , , , }", stack.ToStringInternalRep());
        }

        [TestMethod()]
        public void PeakTest() {
            for (int i = 0; i < 9; i++) {
                stack.Push(i);
            }
            Assert.AreEqual(8, stack.Peak());
            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6, 7, 8, , , , , , , }", stack.ToStringInternalRep());
            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6, 7, 8}", stack.ToString());
        }
    }
}