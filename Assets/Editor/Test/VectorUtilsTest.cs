using NUnit.Framework;
using UnityEngine;

using Geometry;

namespace Tests
{
    public class VectorUtilsTest
    {
        [Test]
        public void MinMax()
        {
            float min, max;
            VectorUtils.MinMax(1, 2, out min, out max);
            Assert.AreEqual(1, min);
            Assert.AreEqual(2, max);
        }

        [Test]
        public void Area2()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(1, 3);
            Assert.AreEqual(Vector3.Cross(b - a, c - a).z, VectorUtils.Area2(a, b, c));
        }


        [Test]
        public void IsLeft1()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(1, 3);
            Assert.IsTrue(VectorUtils.IsLeft(a, b, c));
        }

        [Test]
        public void IsLeft2()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(4, 1);
            Assert.IsFalse(VectorUtils.IsLeft(a, b, c));
        }

        [Test]
        public void IsLeft3()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(2, 1);
            Assert.IsFalse(VectorUtils.IsLeft(a, b, c));
        }

        [Test]
        public void IsLeft4()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(5, 4);
            Assert.IsFalse(VectorUtils.IsLeft(a, b, c));
        }


        [Test]
        public void IsLeft5()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(4, 3);
            Assert.IsFalse(VectorUtils.IsLeft(a, b, c));
        }

        [Test]
        public void IsLeftOn1()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(1, 3);
            Assert.IsTrue(VectorUtils.IsLeftOn(a, b, c));
        }

        [Test]
        public void IsLeftOn2()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(4, 1);
            Assert.IsFalse(VectorUtils.IsLeftOn(a, b, c));
        }

        [Test]
        public void IsLeftOn3()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(2, 1);
            Assert.IsTrue(VectorUtils.IsLeftOn(a, b, c));
        }

        [Test]
        public void IsLeftOn4()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(5, 4);
            Assert.IsTrue(VectorUtils.IsLeftOn(a, b, c));
        }


        [Test]
        public void IsLeftOn5()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(5, 4);
            var c = new Vector2(4, 3);
            Assert.IsTrue(VectorUtils.IsLeftOn(a, b, c));
        }

        [Test]
        public void IsCollinear1()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(4, 2);
            var c = new Vector2(6, 3);
            Assert.IsTrue(VectorUtils.IsCollinear(a, b, c));
        }

        [Test]
        public void IsCollinear2()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(4, 2);
            var c = new Vector2(5, 3);
            Assert.IsFalse(VectorUtils.IsCollinear(a, b, c));
        }

        [Test]
        public void IsBetween1()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(6, 3);
            var c = new Vector2(4, 2);
            Assert.IsTrue(VectorUtils.IsBetween(a, b, c));
        }

        [Test]
        public void IsBetween2()
        {
            var a = new Vector2(4, 2);
            var b = new Vector2(6, 3);
            var c = new Vector2(2, 1);
            Assert.IsFalse(VectorUtils.IsBetween(a, b, c));
        }

        [Test]
        public void IsBetween3()
        {
            var a = new Vector2(2, 1);
            var b = new Vector2(4, 2);
            var c = new Vector2(6, 3);
            Assert.IsFalse(VectorUtils.IsBetween(a, b, c));
        }
    }
}
