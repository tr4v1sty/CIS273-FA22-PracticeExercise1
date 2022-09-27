using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeExercise1;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        
        [TestMethod]
        public void TestLength()
        {
            IList list = new ArrayList();

            Assert.AreEqual(0, list.Length);

            for (int i = 0; i < 10; i++)
            {
                list.Append(i);
            }

            Assert.AreEqual(10, list.Length);

            for (int i =0; i < 32; i++)
            {
                list.Append(i);
            }

            Assert.AreEqual(42, list.Length);

        }

        [TestMethod]
        public void TestIsEmpty()
        {
            IList list = new ArrayList();

            Assert.IsTrue(list.IsEmpty);

            for (int i = 0; i < 10; i++)
            {
                list.Append(i);
            }

            Assert.IsFalse(list.IsEmpty);

        }

        [TestMethod]
        public void TestFirst()
        {
            IList list = new ArrayList();

            //Assert.ThrowsException<NullReferenceException>(() =>
            //{
            //    int i = list.First;
            //});

            int? nullFirst = list.First;

            Assert.IsNull(nullFirst);

            for (int i = 0; i < 10; i++)
            {
                list.Append(i);
                Assert.AreEqual(0, list.First);
            }

            Assert.AreEqual(10, list.Length);

            for (int i = 0; i < 32; i++)
            {
                list.Append(i);
                Assert.AreEqual(0, list.First);
            }

        }

        [TestMethod]
        public void TestLast()
        {
            IList list = new ArrayList();

            //Assert.ThrowsException<NullReferenceException>(() =>
            //{
            //    int i = list.Last;
            //});

            int? nullLast = list.Last;

            Assert.IsNull(nullLast);

            list.Append(0);

            Assert.AreEqual(0, list.Last);

            for (int i = 0; i < 10; i++)
            {
                list.Append(i);
                Assert.AreEqual(i, list.Last);
            }

            for (int i = 0; i < 32; i++)
            {
                list.Append(i);
                Assert.AreEqual(i, list.Last);
            }

        }

        [TestMethod]
        public void TestAppend()
        {
            IList list = new ArrayList();

            for (int i = 0; i < 10; i++)
            {
                list.Append(i);
                Assert.AreEqual(i, list.Last);
            }

            Assert.AreEqual("[0,1,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));
            Assert.AreEqual(10, list.Length);

            for (int i = 0; i < 32; i++)
            {
                list.Append(i);
                Assert.AreEqual(i, list.Last);
            }

            Assert.AreEqual("[0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31]", list.ToString().Replace(" ", ""));

        }

        [TestMethod]
        public void TestPrepend()
        {
            IList list = new ArrayList();
            list.Prepend(0);
            Assert.AreEqual(0, list.First);

            list = new ArrayList();

            for (int i = 9; i >=0; i--)
            {
                list.Prepend(i);
                Assert.AreEqual(i, list.First);
            }

            Assert.AreEqual("[0,1,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));
            Assert.AreEqual(10, list.Length);

            for (int i = 31; i >= 0; i--)
            {
                list.Prepend(i);
                Assert.AreEqual(i, list.First);
            }

            Assert.AreEqual("[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,0,1,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));

        }

        [TestMethod]
        public void TestInsertAfter()
        {
            IList list = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                list.Append(i);
            }

            list.InsertAfter(42, 0);
            Assert.AreEqual("[0,42,1,2,3,4]", list.ToString().Replace(" ", ""));

            list.InsertAfter(42, 3);
            Assert.AreEqual("[0,42,1,2,3,42,4]", list.ToString().Replace(" ", ""));

            list.InsertAfter(42, 4);
            Assert.AreEqual("[0,42,1,2,3,42,4,42]", list.ToString().Replace(" ", ""));

            list.InsertAfter(42, 42);
            Assert.AreEqual("[0,42,42,1,2,3,42,4,42]", list.ToString().Replace(" ", ""));

            list.InsertAfter(400, 8);
            Assert.AreEqual("[0,42,42,1,2,3,42,4,42,400]", list.ToString().Replace(" ", ""));

            list = new ArrayList();
            list.InsertAfter(42, 3);
            Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestInsertAt()
        {
            IList list = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                list.Append(i);
                Assert.AreEqual(i, list.Last);
            }

            list.InsertAt(42, 0);
            Assert.AreEqual("[42,0,1,2,3,4]", list.ToString().Replace(" ", ""));

            list.InsertAt(52, 3);
            Assert.AreEqual("[42,0,1,52,2,3,4]", list.ToString().Replace(" ", ""));

            list.InsertAt(62, list.Length-1);
            Assert.AreEqual("[42,0,1,52,2,3,62,4]", list.ToString().Replace(" ", ""));

            list.InsertAt(72, list.Length);
            Assert.AreEqual("[42,0,1,52,2,3,62,4,72]", list.ToString().Replace(" ", ""));

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                list.InsertAt(42, 42);
            });

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                list.InsertAt(42, -5);
            });

            list = new ArrayList();
            list.InsertAt(42, 0);
            Assert.AreEqual("[42]", list.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestFirstIndexOf()
        {
            IList list = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                list.Append(i);
            }

            Assert.AreEqual(0, list.FirstIndexOf(0));
            Assert.AreEqual(4, list.FirstIndexOf(4));
            Assert.AreEqual(-1, list.FirstIndexOf(10));

            for (int i = 0; i < 50; i++)
            {
                list.Append(i);
            }
            // changed list index to 15 from 10 because idk if it was meant to match or not since it would be -1 otherwise
            Assert.AreEqual(0, list.FirstIndexOf(0));
            Assert.AreEqual(4, list.FirstIndexOf(4));
            Assert.AreEqual(15, list.FirstIndexOf(10));
        }

        [TestMethod]
        public void TestRemove()
        {
            IList list = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                list.Append(i);
            }

            list.Remove(0);
            Assert.AreEqual("[1,2,3,4]", list.ToString().Replace(" ", ""));

            list.Remove(4);
            Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));

            list.Remove(5);
            Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));

            for (int i = 0; i < 10; i++)
            {
                list.Append(i);
            }
            Assert.AreEqual("[1,2,3,0,1,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));

            list.Remove(1);
            list.Remove(1);
            Assert.AreEqual("[2,3,0,2,3,4,5,6,7,8,9]", list.ToString().Replace(" ", ""));


            // Empty list
            list = new ArrayList();
            list.Remove(3);
            Assert.AreEqual("[]", list.ToString().Replace(" ", ""));

        }

        [TestMethod]
        public void TestRemoveAt()
        {
            IList list = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                list.Append(i);
                Assert.AreEqual(i, list.Last);
            }

            list.RemoveAt(0);
            Assert.AreEqual("[1,2,3,4]", list.ToString().Replace(" ", ""));

            list.RemoveAt(list.Length - 1);
            Assert.AreEqual("[1,2,3]", list.ToString().Replace(" ", ""));

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                list.RemoveAt(list.Length);
            });


            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                list.RemoveAt(42);
            });

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                list.RemoveAt(-5);
            });

            list = new ArrayList();
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                list.RemoveAt(0);
            });

        }

        [TestMethod]
        public void TestClear()
        {
            IList list = new ArrayList();
            list.Clear();
            Assert.AreEqual(0, list.Length);

            for (int i = 0; i < 10; i++)
            {
                list.Append(i);
            }

            list.Clear();
            Assert.AreEqual(0, list.Length);

            

            for (int i = 0; i < 64; i++)
            {
                list.Append(i);
                Assert.AreEqual(i, list.Last);
            }
            list.Clear();
            Assert.AreEqual(0, list.Length);

        }

        [TestMethod]
        public void TestReverse()
        {
            IList list = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                list.Append(i);
            }

            var reversed = list.Reverse();
            Assert.AreEqual("[4,3,2,1,0]", reversed.ToString().Replace(" ", ""));
            Assert.AreEqual("[0,1,2,3,4]", list.ToString().Replace(" ", ""));

            Assert.AreEqual("[0,1,2,3,4]", reversed.Reverse().ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestGet()
        {
            IList list = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                list.Append(i);
            }

            Assert.AreEqual(0, list.Get(0));
            Assert.AreEqual(1, list.Get(1));
            Assert.AreEqual(2, list.Get(2));
            
            for (int i = 5; i < 50; i++)
            {
                list.Append(i);
            }

            Assert.AreEqual(45, list.Get(45));
            Assert.AreEqual(10, list.Get(10));
        }
    }

}


