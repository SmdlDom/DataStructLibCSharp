using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructLib.LinkedNodeStruct.Tests {
    [TestClass()]
    public class LinkedStackTests {

        private LinkedStack stack = new LinkedStack();

        [TestMethod()]
        public void PushTest() {
            for (int i = 0; i < 4; i++) {
                stack.Push(i);
            }
            Assert.AreEqual("{3, 2, 1, 0}", stack.ToString());
        }

        [TestMethod()]
        public void PopTest() {
            for (int i = 0; i < 4; i++) {
                stack.Push(i);
            }
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual("{2, 1, 0}", stack.ToString());

        }

        [TestMethod()]
        public void PeakTest() {
            for (int i = 0; i < 4; i++) {
                stack.Push(i);
            }
            Assert.AreEqual(3, stack.Peak());
            Assert.AreEqual("{3, 2, 1, 0}", stack.ToString());
        }
    }
}