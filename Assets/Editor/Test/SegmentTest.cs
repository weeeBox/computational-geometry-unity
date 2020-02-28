using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SegmentTest
    {
        [Test]
        public void TestExtremePoints()
        {
            var segment = new Segment(new Vector3(1, 4), new Vector3(3, 2));
            Assert.AreEqual(1, segment.minX);
            Assert.AreEqual(3, segment.maxX);
            Assert.AreEqual(2, segment.minY);
            Assert.AreEqual(4, segment.maxY);
        }
    }
}
