using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructLib.LinkedNodeStruct.Tests {
    [TestClass()]
    public class SinglyLinkedListTests {

        private SinglyLinkedList list = new SinglyLinkedList();
        [TestMethod()]
        public void AppendTest() {
            for(int i = 0; i < 3; i++) {
                list.Append(i);
            }
            Assert.AreEqual("{0, 1, 2}", list.ToString());
        }

        [TestMethod()]
        public void ContainsTest() {
            Assert.AreEqual(false, list.Contains(0));
            for (int i = 0; i < 3; i++) {
                list.Append(i);
            }
            Assert.AreEqual(true, list.Contains(0));
            Assert.AreEqual(true, list.Contains(2));
            Assert.AreEqual(false, list.Contains(4));
        }

        [TestMethod()]
        public void IndexOfTest() {
            Assert.AreEqual(-1, list.IndexOf(2));
            for (int i = 0; i < 3; i++) {
                list.Append(i);
            }
            for (int i = 0; i < 3; i++) {
                list.Append(i);
            }
            Assert.AreEqual(2, list.IndexOf(2));
            Assert.AreEqual(3, list.IndexOf(0, 3));
            Assert.AreEqual(-1, list.IndexOf(2, 3, 2));
        }

        [TestMethod()]
        public void InsertTest() {
            list.Insert(0, 0);
            Assert.AreEqual("{0}", list.ToString());
            list.Insert(1, 0);
            list.Insert(2, 0);
            Assert.AreEqual("{2, 1, 0}", list.ToString());
            list.Insert(3, 1);
            Assert.AreEqual("{2, 3, 1, 0}", list.ToString());
            list.Insert(4, 3);
            Assert.AreEqual("{2, 3, 1, 4, 0}", list.ToString());
            list.Insert(5, 5);
            Assert.AreEqual("{2, 3, 1, 4, 0, 5}", list.ToString());

        }

        //TODO redo test
        [TestMethod()]
        public void LastIndexOfTest() {
            for (int i = 0; i < 4; i++) {
                list.Append(i);
            }
            for (int i = 0; i < 4; i++) {
                list.Append(i);
            }

            Assert.AreEqual(6, list.LastIndexOf(2));
            Assert.AreEqual(-1, list.LastIndexOf(4));
            Assert.AreEqual(2, list.LastIndexOf(2, 2));
            Assert.AreEqual(2, list.LastIndexOf(2, 2, 4));
           
        }

        [TestMethod()]
        public void RemoveTest() {
            for (int i = 0; i < 3; i++) {
                list.Append(i);
            }
            for (int i = 0; i < 3; i++) {
                list.Append(i);
            }

            list.Remove(0);
            Assert.AreEqual("{1, 2, 0, 1, 2}", list.ToString());
            list.Remove(2);
            Assert.AreEqual("{1, 0, 1, 2}", list.ToString());
            list.RemoveAtIndex(1);
            Assert.AreEqual("{1, 1, 2}", list.ToString());

            for (int i = 0; i < 3; i++) {
                list.Append(i);
            }
            list.RemoveSection(1, 4);
            Assert.AreEqual("{1, 2}", list.ToString());
            list.RemoveSection(0, 2);
            Assert.AreEqual("{}", list.ToString());
            Assert.AreEqual(true, list.IsEmpty());
        }


        [TestMethod()]
        public void ReverseTest() {
            for (int i = 0; i < 3; i++) {
                list.Append(i);
            }
            for (int i = 0; i < 3; i++) {
                list.Append(i);
            }
            list.Reverse();
            Assert.AreEqual("{2, 1, 0, 2, 1, 0}", list.ToString());
            list.ReverseSection(1, 4);
            Assert.AreEqual("{2, 1, 2, 0, 1, 0}", list.ToString());
        }
    }
}