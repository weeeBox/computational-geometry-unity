using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PriorityQueueTest
    {
        [Test]
        public void TestElements()
        {
            var queue = new PriorityQueue<int>();
            
            queue.Offer(2);
            queue.Offer(1);
            queue.Offer(3);
            queue.Offer(1);
            queue.Offer(3);

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Poll());

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Poll());

            Assert.AreEqual(2, queue.Peek());
            Assert.AreEqual(2, queue.Poll());

            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Poll());

            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Poll());
        }

        [Test]
        public void TestExistingElements()
        {
            var elements = new int[] { 2, 1, 3, 1, 3 };
            var queue = new PriorityQueue<int>(elements);

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Poll());

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Poll());

            Assert.AreEqual(2, queue.Peek());
            Assert.AreEqual(2, queue.Poll());

            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Poll());

            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Poll());
        }

        [Test]
        public void TestComparer()
        {
            var queue = new PriorityQueue<int>(Comparer<int>.Create((a, b) => {
                return b.CompareTo(a);
            }));

            queue.Offer(2);
            queue.Offer(1);
            queue.Offer(3);
            queue.Offer(1);
            queue.Offer(3);

            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Poll());

            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Poll());

            Assert.AreEqual(2, queue.Peek());
            Assert.AreEqual(2, queue.Poll());

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Poll());

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Poll());
        }

        [Test]
        public void TestExistingElementsComparer()
        {
            var elements = new int[] { 2, 1, 3, 1, 3 };
            var queue = new PriorityQueue<int>(elements, Comparer<int>.Create((a, b) => {
                return b.CompareTo(a);
            }));

            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Poll());

            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Poll());

            Assert.AreEqual(2, queue.Peek());
            Assert.AreEqual(2, queue.Poll());

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Poll());

            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Poll());
        }
    }
}
