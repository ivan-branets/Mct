using DataStructures.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mct_48
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void IsNewListEmpty()
        {
            CollectionAssert.AreEqual(new int[0], new LinkedList<int>());                            
        }

        [TestMethod]
        public void AddTest()
        {
            var actual = new LinkedList<int>();
            var expected = new System.Collections.Generic.List<int>();

            for (var i = 0; i < 5; i++)
            {
                actual.Add(i);
                expected.Add(i);

                CollectionAssert.AreEqual(expected, actual);                
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            var actual = new LinkedList<int>{ -1, -2 };
            var expected = new System.Collections.Generic.List<int> { -1, -2 };

            for (var i = 0; i < 5; i++)
            {
                var middle = expected.Count / 2;

                actual.Insert(middle, i * 10);
                expected.Insert(middle, i * 10);

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void InsertFirstTest()
        {
            var actual = new LinkedList<int>();
            var expected = new System.Collections.Generic.List<int>();

            for (var i = 0; i < 5; i++)
            {
                actual.Insert(0, i * 10);
                expected.Insert(0, i * 10);

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void InsertLastTest()
        {
            var actual = new LinkedList<int>();
            var expected = new System.Collections.Generic.List<int>();

            for (var i = 0; i < 5; i++)
            {
                actual.Insert(i, i * 10);
                expected.Insert(i, i * 10);

                CollectionAssert.AreEqual(expected, actual);
            }
        }

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
        public void ContainsTest()
        {
            var actual = new LinkedList<int> { 0, 1, 2, 3, 4, 5 };

            for (var i = 0; i <= 5; i++)
            {
                Assert.IsTrue(actual.Contains(i));
                Assert.IsFalse(actual.Contains(i + 100));
            }
        }

        [TestMethod]
        public void ContainsEmptyTest()
        {
            var list = new LinkedList<int>();
            Assert.IsFalse(list.Contains(1));
        }
    }
}
