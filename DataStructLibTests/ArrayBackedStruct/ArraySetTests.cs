using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass()]
    public class ArraySetTests {

        private ArraySet set = new ArraySet();
        
        [TestMethod()]
        public void AddTest() {
            for(int i = 0; i < 4; i++) {
                set.Add(i);
            }
            Assert.AreEqual("{0, 1, 2, 3}", set.ToString());
        }

        [TestMethod()]
        public void ContainsTest() {
            for (int i = 0; i < 4; i++) {
                set.Add(i);
            }
            Assert.AreEqual(true, set.Contains(3));
            Assert.AreEqual(false, set.Contains(4));
        }

        [TestMethod()]
        public void DifferenceTest() {
            for (int i = 0; i < 4; i++) {
                set.Add(i);
            }
            ArraySet set1 = new ArraySet();
            for (int i = 2; i < 6; i++) {
                set1.Add(i);
            }
            Assert.AreEqual("{0, 1}", set.Difference(set1).ToString());
        }

        [TestMethod()]
        public void IntersectionTest() {
            for (int i = 0; i < 4; i++) {
                set.Add(i);
            }
            ArraySet set1 = new ArraySet();
            for (int i = 2; i < 6; i++) {
                set1.Add(i);
            }
            Assert.AreEqual("{2, 3}", set.Intersection(set1).ToString());
        }

        [TestMethod()]
        public void RemoveTest() {
            for (int i = 0; i < 6; i++) {
                set.Add(i);
            }
            set.Remove(0);
            set.Remove(2);
            set.Remove(4);
            Assert.AreEqual("{1, 3, 5}", set.ToString());
        }

        [TestMethod()]
        public void SubsetTest() {
            for (int i = 0; i < 6; i++) {
                set.Add(i);
            }
            ArraySet set1 = new ArraySet();
            for (int i = 2; i < 6; i++) {
                set1.Add(i);
            }
            ArraySet set2 = new ArraySet();
            for (int i = 2; i < 7; i++) {
                set2.Add(i);
            }
            Assert.AreEqual(true, set.Subset(set1));
            Assert.AreEqual(false, set.Subset(set2));
        }

        [TestMethod()]
        public void UnionTest() {
            for (int i = 0; i < 4; i++) {
                set.Add(i);
            }
            ArraySet set1 = new ArraySet();
            for (int i = 2; i < 6; i++) {
                set1.Add(i);
            }
            Assert.AreEqual("{2, 3, 4, 5, 0, 1}", set.Union(set1).ToString());
        }
    }
}