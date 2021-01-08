using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.MapStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.MapStruct.Tests {
    [TestClass()]
    public class UnsortedTableMapTests {

        private UnsortedTableMap map = new UnsortedTableMap();

        [TestMethod()]
        public void GetValueTest() {
            for (int i = 0; i < 5; i++) {
                map.SetValue(i, i + 1);
            }
            Assert.AreEqual(3, map.GetValue(2));

            try {
                map.GetValue(5);
            } catch (ArgumentOutOfRangeException e) {
                Assert.AreEqual(true, e is ArgumentOutOfRangeException);
            }
        }

        [TestMethod()]
        public void SetValueTest() {
            for (int i = 0; i < 5; i ++) {
                map.SetValue(i, i + 1);
            }
            Assert.AreEqual("{<0, 1>, <1, 2>, <2, 3>, <3, 4>, <4, 5>}", map.ToString());

            for (int i = 0; i < 5; i++) {
                map.SetValue(i, i + 2);
            }
            Assert.AreEqual("{<0, 2>, <1, 3>, <2, 4>, <3, 5>, <4, 6>}", map.ToString());

        }

        [TestMethod()]
        public void RemoveTest() {
            for (int i = 0; i < 5; i++) {
                map.SetValue(i, i + 1);
            }
            map.Remove(0);
            map.Remove(5);
            Assert.AreEqual("{<1, 2>, <2, 3>, <3, 4>, <4, 5>}", map.ToString());
        }
    }
}