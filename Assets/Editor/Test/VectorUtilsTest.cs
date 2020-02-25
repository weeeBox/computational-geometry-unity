using NUnit.Framework;
using UnityEngine;

using Geometry;
using System.Linq;

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

        [Test]
        public void Intersect1()
        {
            TestIntersect("0 0 5 5 0 6 6 0", true);
        }

        [Test]
        public void Intersect2()
        {
            TestIntersect("0 0 3 3 0 6 6 0", true);
        }

        [Test]
        public void Intersect3()
        {
            TestIntersect("5 5 3 3 0 6 6 0", true);
        }

        [Test]
        public void Intersect4()
        {
            TestIntersect("1 1 1 3 1 3 1 6", true);
        }

        [Test]
        public void Intersect5()
        {
            TestIntersect("1 1 1 4 1 3 1 6", true);
        }

        [Test]
        public void Intersect6()
        {
            TestIntersect("1 1 1 6 1 2 1 4", true);
        }

        [Test]
        public void Intersect7()
        {
            TestIntersect("1 1 1 6 1 1 1 6", true);
        }

        [Test]
        public void Intersect8()
        {
            TestIntersect("1 1 1 3 1 4 1 6", false);
        }

        [Test]
        public void Intersect9()
        {
            TestIntersect("1 1 2 1 3 1 4 1", false);
        }

        [Test]
        public void Intersect10()
        {
            TestIntersect("1 1 3 1 2 1 4 1", true);
        }

        [Test]
        public void Intersect11()
        {
            TestIntersect("1 1 4 1 1 1 2 1", true);
        }

        [Test]
        public void Intersect12()
        {
            TestIntersect("1 1 2 1 2 1 3 1", true);
        }

        [Test]
        public void Intersect13()
        {
            TestIntersect("1 1 2 1 2 1 3 1", true);
        }

        [Test]
        public void Intersect14()
        {
            TestIntersect("4 1 6 4 8 7 10 10", false);
        }

        [Test]
        public void Intersect15()
        {
            TestIntersect("4 1 6 4 8 7 10 10", false);
        }

        [Test]
        public void Intersect16()
        {
            TestIntersect("4 1 8 7 6 4 10 10", true);
        }

        [Test]
        public void Intersect17()
        {
            TestIntersect("4 1 10 10 6 4 8 7", true);
        }

        [Test]
        public void Intersect18()
        {
            TestIntersect("4 1 10 10 6 4 8 7", true);
        }

        [Test]
        public void Intersect19()
        {
            TestIntersect("4 1 6 4 6 4 10 10", true);
        }

        [Test]
        public void Intersect20()
        {
            TestIntersect("5 5 0 6 0 6 6 0", true);
        }

        [Test]
        public void Intersect21()
        {
            TestIntersect("5 5 6 0 0 6 6 0", true);
        }

        [Test]
        public void Intersect22()
        {
            TestIntersect("5 5 6 0 0 6 5 0", false);
        }

        [Test]
        public void Intersect23()
        {
            TestIntersect("5 5 6 0 6 5 7 0", false);
        }

        [Test]
        public void Intersect24()
        {
            TestIntersect("5 5 6 0 6 5 6 1", false);
        }

        [Test]
        public void Intersect25()
        {
            TestIntersect("5 5 4 5 6 5 6 1", false);
        }

        [Test]
        public void Intersect26()
        {
            TestIntersect("5 5 7 0 6 5 7 5", false);
        }

        [Test]
        public void Intersect27()
        {
            TestIntersect("5 5 5 0 6 5 7 5", false);
        }

        [Test]
        public void Intersect28()
        {
            TestIntersect("5 5 5 0 6 5 7 5", false);
        }

        private void TestIntersect(string points, bool expected)
        {
            string[] tokens = points.Split();
            var first = string.Join(" ", tokens.Take(tokens.Length / 2));
            var second = string.Join(" ", tokens.Skip(tokens.Length / 2));
            Debug.LogFormat("fig = figure()\nplot_line(fig, '{0}', color = 'r')\nplot_line(fig, '{1}', color = 'b')\n\n", first, second);

            
            Assert.AreEqual(8, tokens.Length);
            var a = new Vector2(int.Parse(tokens[0]), int.Parse(tokens[1]));
            var b = new Vector2(int.Parse(tokens[2]), int.Parse(tokens[3]));
            var c = new Vector2(int.Parse(tokens[4]), int.Parse(tokens[5]));
            var d = new Vector2(int.Parse(tokens[6]), int.Parse(tokens[7]));
            Assert.AreEqual(expected, VectorUtils.Intersect(a, b, c, d));
            Assert.AreEqual(expected, VectorUtils.Intersect(a, b, d, c));
            Assert.AreEqual(expected, VectorUtils.Intersect(b, a, c, d));
            Assert.AreEqual(expected, VectorUtils.Intersect(b, a, d, c));
            Assert.AreEqual(expected, VectorUtils.Intersect(c, d, a, b));
            Assert.AreEqual(expected, VectorUtils.Intersect(c, d, b, a));
            Assert.AreEqual(expected, VectorUtils.Intersect(d, c, a, b));
            Assert.AreEqual(expected, VectorUtils.Intersect(d, c, b, a));
        }
    }
}
