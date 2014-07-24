using DataStructures.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mct_48
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void ClearTest()
        {
            var actual = new LinkedList<int> { 1, 2, 3 };
            actual.Clear();

            CollectionAssert.AreEqual(new int[0], actual);
        }

        [TestMethod]
        public void ClearEmptyTest()
        {
            var actual = new LinkedList<int>();
            actual.Clear();

            CollectionAssert.AreEqual(new int[0], actual);
        }

        [TestMethod]
        public void ClearNotBrokenTest()
        {
            var actual = new LinkedList<int>{ 1, 2 };
            actual.Clear();

            actual.Add(3);
            actual.Add(4);
            actual.Add(5);

            CollectionAssert.AreEqual(new [] { 3, 4, 5 }, actual);

            actual.Clear();
            actual.Clear();
            CollectionAssert.AreEqual(new int[0], actual);
        }

        [TestMethod]
        public void ContainsTest()
        {
            var list = new LinkedList<int> { 1, 2, 3 };

            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
            Assert.IsFalse(list.Contains(4));
        }

        [TestMethod]
        public void ContainsEmptyTest()
        {
            var list = new LinkedList<int>();
            Assert.IsFalse(list.Contains(1));
        }

        [TestMethod]
        public void ContainsNotBrokenTest()
        {
            var list = new LinkedList<int> { 1, 2, 3 };
            Assert.IsTrue(list.Contains(1));

            list.Remove(1);
            Assert.IsFalse(list.Contains(1));
            Assert.IsTrue(list.Contains(2));
        }
    }
}
