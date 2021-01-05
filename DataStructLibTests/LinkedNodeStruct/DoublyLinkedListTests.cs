using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.LinkedNodeStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.LinkedNodeStruct.Tests {
    [TestClass()]
    public class DoublyLinkedListTests {
        
        //TODO verify that the test triggers from the back selection
        //TODO implement a ToStringFromBackward to make sure that the prev pointers are properly set
        private DoublyLinkedList list = new DoublyLinkedList();

        [TestMethod()]
        public void AppendTest() {
            for (int i = 0; i < 4; i ++) {
                list.Append(i);
            }
            Assert.AreEqual("{0, 1, 2, 3}", list.ToString());
        }

        [TestMethod()]
        public void ContainsTest() {
            for (int i = 0; i < 4; i++) {
                list.Append(i);
            }
            Assert.AreEqual(true, list.Contains(3));
            Assert.AreEqual(false, list.Contains(4));
        }

        [TestMethod()]
        public void IndexOfTest() {
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            Assert.AreEqual(2, list.IndexOf(3));
            Assert.AreEqual(-1, list.IndexOf(4));
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            Assert.AreEqual(5, list.IndexOf(3, 3));
            Assert.AreEqual(-1, list.IndexOf(3, 3, 2));
        }

        [TestMethod()]
        public void InsertTest() {
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            list.Insert(0, 0);
            list.Insert(4, 1);
            list.Insert(5, 4);
            list.Insert(6, 6);
            Assert.AreEqual("{0, 4, 1, 2, 5, 3, 6}", list.ToString());
        }

        [TestMethod()]
        public void IndexingTest() {
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            Assert.AreEqual(2, list[1]);
            list[1] = 3;
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod()]
        public void LastIndexOfTest() {
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            Assert.AreEqual(5, list.LastIndexOf(3));
            Assert.AreEqual(-1, list.LastIndexOf(4));
            list.Insert(0, 0);
            Assert.AreEqual(-1, list.LastIndexOf(0, 1));
            Assert.AreEqual(3, list.LastIndexOf(3, 1, 3));
        }

        [TestMethod()]
        public void RemoveTest() {
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            list.Remove(1);
            list.Remove(3);
            list.Remove(3);
            Assert.AreEqual("{2, 1, 2}", list.ToString());
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            list.RemoveAtIndex(0);
            list.RemoveAtIndex(1);
            list.RemoveAtIndex(3);
            Assert.AreEqual("{1, 1, 2}", list.ToString());
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            list.RemoveSection(1, 4);
            Assert.AreEqual("{1, 3}", list.ToString());
            list.RemoveAtIndex(0);
            Assert.AreEqual("{3}", list.ToString());
            list.RemoveAtIndex(0);
            Assert.AreEqual("{}", list.ToString());

        }

        [TestMethod()]
        public void ReverseTest() {
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            list.Reverse();
            Assert.AreEqual("{3, 2, 1, 3, 2, 1}", list.ToString());
            list.ReverseSection(1, 4);
            Assert.AreEqual("{3, 2, 3, 1, 2, 1}", list.ToString());
        }
    }
}