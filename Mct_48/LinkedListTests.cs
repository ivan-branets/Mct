using System;
using System.Diagnostics;
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
        public void IndexTest()
        {
            var actual = new LinkedList<int> { 1, 2, 3};
            var exptected = new System.Collections.Generic.List<int> { 1, 2, 3 };

            for (var i = 0; i < exptected.Count; i++)
            {
                Assert.AreEqual(exptected[i], actual[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOutOfRangeTest()
        {
            var actual = new LinkedList<int>();
            Debug.WriteLine(actual[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOutOfRangeNagativeTest()
        {
            var actual = new LinkedList<int> { 1, 2, 3 };
            Debug.WriteLine(actual[-10]);
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
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertOutOfRangeTest()
        {
            var actual = new LinkedList<int>();
            actual.Insert(2, 100);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var actual = new LinkedList<int> { 1, 2, 3 };

            Assert.IsTrue(actual.Remove(2));
            CollectionAssert.AreEqual(new [] { 1, 3 }, actual);
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            var actual = new LinkedList<int> { 1, 2, 3 };

            Assert.IsTrue(actual.Remove(1));
            CollectionAssert.AreEqual(new[] { 2, 3 }, actual);
        }

        [TestMethod]
        public void RemoveLastTest()
        {
            var actual = new LinkedList<int> { 1, 2, 3 };

            Assert.IsTrue(actual.Remove(3));
            CollectionAssert.AreEqual(new[] { 1, 2 }, actual);
        }

        [TestMethod]
        public void RemoveSingleTest()
        {
            var actual = new LinkedList<int> { 1 };

            Assert.IsTrue(actual.Remove(1));
            CollectionAssert.AreEqual(new int[0], actual);
        }

        [TestMethod]
        public void RemoveNotExistedTest()
        {
            var actual = new LinkedList<int> { 1, 2, 3 };

            Assert.IsFalse(actual.Remove(4));
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, actual);
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            var actual = new LinkedList<int> { 10, 20, 30 };

            actual.RemoveAt(1);
            CollectionAssert.AreEqual(new[] { 10, 30 }, actual);
        }

        [TestMethod]
        public void RemoveAtFirstTest()
        {
            var actual = new LinkedList<int> { 10, 20, 30 };

            actual.RemoveAt(0);
            CollectionAssert.AreEqual(new[] { 20, 30 }, actual);
        }

        [TestMethod]
        public void RemoveAtLastTest()
        {
            var actual = new LinkedList<int> { 10, 20, 30 };

            actual.RemoveAt(2);
            CollectionAssert.AreEqual(new[] { 10, 20 }, actual);
        }

        [TestMethod]
        public void RemoveAtSingleTest()
        {
            var actual = new LinkedList<int> { 1 };

            actual.RemoveAt(0);
            CollectionAssert.AreEqual(new int[0], actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtNotExistedTest()
        {
            var actual = new LinkedList<int> { 10, 20, 30 };

            actual.RemoveAt(3);
            CollectionAssert.AreEqual(new[] { 10, 20, 30 }, actual);
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
