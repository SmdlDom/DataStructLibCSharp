using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass()]
    public class ArrayStackTests {

        private ArrayStack arrayStack = new ArrayStack();

        [TestMethod()]
        public void ArrayStackTest() {
            arrayStack.Push(0);
            arrayStack.Push(1);
            arrayStack.Push(2);
            arrayStack.Push(3);
            arrayStack.Push(4);
            arrayStack.Push(5);
            arrayStack.Push(6);
            arrayStack.Push(7);
            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6, 7}", arrayStack.ToString());
            Assert.AreEqual(7, arrayStack.Pop());
            Assert.AreEqual(6, arrayStack.Peek());
            Assert.AreEqual("{0, 1, 2, 3, 4, 5, 6}", arrayStack.ToString());

        }
    }
}