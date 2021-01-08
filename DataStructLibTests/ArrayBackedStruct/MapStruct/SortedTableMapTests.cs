using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructLib.ArrayBackedStruct.MapStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.MapStruct.Tests {
    [TestClass()]
    public class SortedTableMapTests {

        private SortedTableMap map = new SortedTableMap();

        [TestMethod()]
        public void SetValueTest() {
            for (int i = 0; i < 4; i++) {
                map.SetValue(i * 2, i);
            }
            Assert.AreEqual("{<0, 0>, <2, 1>, <4, 2>, <6, 3>}", map.ToString());
            for (int i = 0; i < 4; i++) {
                map.SetValue(i, i * 2);
            }
            Assert.AreEqual("{<0, 0>, <1, 2>, <2, 4>, <3, 6>, <4, 2>, <6, 3>}", map.ToString());
        }
    }
}