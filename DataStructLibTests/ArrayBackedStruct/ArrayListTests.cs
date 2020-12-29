using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructLib.ArrayBackedStruct.Tests {
    [TestClass]
    public class ArrayListTests {

        private ArrayList arrayList = new ArrayList();

        [TestMethod]
        public void ArrayListTest() {
            arrayList.Append(8);
            arrayList.Append(4);
            arrayList.Append(2);
            arrayList.Append(1);
            Assert.AreEqual("{8, 4, 2, 1}", arrayList.ToString());
            Assert.AreEqual(8, arrayList.Cap);
            arrayList.Insert(6, 1);
            arrayList.Insert(6, 3);
            arrayList.Insert(6, 5);
            arrayList.Insert(6, 7);
            arrayList.Insert(6, 0);
            Assert.AreEqual("{6, 8, 6, 4, 6, 2, 6, 1, 6}", arrayList.ToString());
            Assert.AreEqual(16, arrayList.Cap);
            Assert.AreEqual(0, arrayList.IndexOf(6));
            Assert.AreEqual(2, arrayList.IndexOf(6, 1));
            Assert.AreEqual(-1, arrayList.IndexOf(6, 1, 1));
            Assert.AreEqual(8, arrayList.LastIndexOf(6));
            Assert.AreEqual(6, arrayList.LastIndexOf(6, 1));
            Assert.AreEqual(-1, arrayList.LastIndexOf(6, 1, 1));
            arrayList.Reverse();
            Assert.AreEqual("{6, 1, 6, 2, 6, 4, 6, 8, 6}", arrayList.ToString());
            arrayList.ReverseSection(2, 4);
            Assert.AreEqual("{6, 1, 4, 6, 2, 6, 6, 8, 6}", arrayList.ToString());
            arrayList.Remove(6);
            arrayList.RemoveAtIndex(0);
            Assert.AreEqual("{4, 6, 2, 6, 6, 8, 6}", arrayList.ToString());
            arrayList.RemoveSection(1, 4);
            Assert.AreEqual("{4, 8, 6}", arrayList.ToString());
            Assert.AreEqual(8, arrayList.Cap);
            Assert.AreEqual(true, arrayList.Contains(8));
            arrayList[1] = 12;
            Assert.AreEqual(12, arrayList[1]);
            arrayList.TrimToSize();
            Assert.AreEqual(3, arrayList.Cap);
            arrayList.Insert(0, 1);
            Assert.AreEqual(8, arrayList.Cap);
            arrayList.RemoveAtIndex(0);
            arrayList.RemoveAtIndex(0);
            arrayList.RemoveAtIndex(0);
            Assert.AreEqual(8, arrayList.Cap);
            arrayList.Clear();
            Assert.AreEqual("{}", arrayList.ToString());
        }
   } 
}