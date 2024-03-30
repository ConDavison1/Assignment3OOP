using NUnit.Framework;
using System;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        private SLL linkedList;
        private User user1;
        private User user2;
        private User user3;

        [SetUp]
        public void Setup()
        {
            linkedList = new SLL();
            user1 = new User(1, "Connor Davison", "connor@email.com", "password");
            user2 = new User(2, "Gabby Perez", "gabby@email.com", "password");
            user3 = new User(3, "Chris Hemsworth", "chris@email.com", "password");
        }

        [Test]
        public void TestEmptyLinkedList()
        {
            Assert.IsTrue(linkedList.IsEmpty());
            Assert.AreEqual(0, linkedList.Count());
        }

        [Test]
        public void TestPrepend()
        {
            linkedList.AddFirst(user1);

            Assert.IsFalse(linkedList.IsEmpty());
            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestAppend()
        {
            linkedList.AddLast(user1);

            Assert.IsFalse(linkedList.IsEmpty());
            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestInsertAtIndex()
        {
            linkedList.AddFirst(user1);
            linkedList.Add(user2, 1);

            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual(user2, linkedList.GetValue(1));
        }

        [Test]
        public void TestReplace()
        {
            linkedList.AddFirst(user1);
            linkedList.Replace(user2, 0);

            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user2, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteFromBeginning()
        {
            linkedList.AddFirst(user1);
            linkedList.AddLast(user2);

            linkedList.RemoveFirst();

            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user2, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteFromEnd()
        {
            linkedList.AddFirst(user1);
            linkedList.AddLast(user2);

            linkedList.RemoveLast();

            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteFromMiddle()
        {
            linkedList.AddFirst(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);

            linkedList.Remove(1);

            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
            Assert.AreEqual(user3, linkedList.GetValue(1));
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            linkedList.AddFirst(user1);

            Assert.IsTrue(linkedList.Contains(user1));
            Assert.AreEqual(0, linkedList.IndexOf(user1));
        }

        [Test]
        public void TestReverse()
        {
            linkedList.AddLast(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);

            linkedList.Reverse();

            Assert.AreEqual(user3, linkedList.GetValue(0));
            Assert.AreEqual(user2, linkedList.GetValue(1));
            Assert.AreEqual(user1, linkedList.GetValue(2));
        }

        [Test]
        public void TestCopyToArray()
        {
            linkedList.AddLast(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);

            User[] array = linkedList.CopyToArray();

            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(user1, array[0]);
            Assert.AreEqual(user2, array[1]);
            Assert.AreEqual(user3, array[2]);
        }
    }
}
