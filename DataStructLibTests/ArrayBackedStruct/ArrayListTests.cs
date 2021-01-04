using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.ArrayBackedStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass()]
    public class ArrayListTests {

        private ArrayList list = new ArrayList();

        [TestMethod()]
        public void AppendTest() {
            for (int i = 0; i < 4; i++) {
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
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            Assert.AreEqual(2, list.IndexOf(3));
            Assert.AreEqual(-1, list.IndexOf(4));
            Assert.AreEqual(5, list.IndexOf(3, 3));
            Assert.AreEqual(-1, list.IndexOf(3, 3, 2));
            Assert.AreEqual("{1, 2, 3, 1, 2, 3}", list.ToString());
        }


        [TestMethod()]
        public void InsertTest() {
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            list.Insert(4, 0);
            list.Insert(5, 1);
            list.Insert(6, 5);
            Assert.AreEqual("{4, 5, 1, 2, 3, 6}", list.ToString());
        }

        //TODO redo test
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
            Assert.AreEqual(3, list.LastIndexOf(1, 3));
            Assert.AreEqual(-1, list.LastIndexOf(3, 0, 2));
        }

        [TestMethod()]
        public void RemoveTest() {
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            for (int i = 1; i < 4; i++) {
                list.Append(i);
            }
            list.Remove(3);
            list.RemoveAtIndex(0);
            Assert.AreEqual("{2, 1, 2, 3}", list.ToString());
            list.RemoveSection(1, 2);
            Assert.AreEqual("{2, 3}", list.ToString());
            list.RemoveSection(0, 2);
            Assert.AreEqual(true, list.IsEmpty());
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