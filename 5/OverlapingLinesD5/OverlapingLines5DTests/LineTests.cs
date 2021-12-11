using NUnit.Framework;
using OverlapingLinesD5;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OverlapingLines5DTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(372, 378)]
        [TestCase(974, 980)]
        public void GetY_IncreasingFunc_ShouldReturnY(int x, int expectedY)
        {
            Line line = new Line(new Point(974, 980), new Point(28, 34));
            int y = line.GetY(x);
            Assert.AreEqual(y, expectedY);
        }

        [Test]
        [TestCase(100, 664)]
        [TestCase(431, 333)]
        public void GetY_DecreasingFunc_ShouldReturnY(int x, int expectedY)
        {
            Line line = new Line(new Point(25, 739), new Point(431, 333));
            int y = line.GetY(x);
            Assert.AreEqual(y, expectedY);
        }

        [Test]
        [TestCase(770, 356)]
        public void GetY_SameX_ShouldThrowArgumentExcepton(int x, int expectedY)
        {
            Line line = new Line(new Point(770, 318), new Point(770, 437));
            Assert.Throws<ArgumentException>(() => { line.GetY(x); });
        }

        [Test]
        [TestCase(471, 914)]
        public void GetY_SameY_ShouldReturnY(int x, int expectedY)
        {
            Line line = new Line(new Point(543, 914), new Point(359, 914));
            int y = line.GetY(x);
            Assert.AreEqual(y, expectedY);
        }

        [Test]
        public void GetPoints_SameX_ShouldReturnPoints()
        {
            Line line = new Line(new Point(770, 318), new Point(770, 437));
            List<Point> points = line.GetPoints().ToList();
            Assert.AreEqual(120, points.Count);
            Assert.AreEqual(318, points.First().Y);
            Assert.AreEqual(437, points.Last().Y);
        }

        [Test]
        public void GetPoints_ShouldReturnPoints() 
        {
            Line line = new Line(new Point(25, 739), new Point(431, 333));
            List<Point> points = line.GetPoints().ToList();
            Assert.AreEqual(407, points.Count);
            Assert.AreEqual(739, points.First().Y);
            Assert.AreEqual(333, points.Last().Y);
        }
    }
}