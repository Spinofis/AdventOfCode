using NUnit.Framework;
using OverlapingLinesD5;

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
        public void GetY_ShouldReturnY_IncreasingFunc(int x, int expectedY)
        {
            Line line = new Line(new Point(974, 980), new Point(28, 34));
            int y = line.GetY(x);
            Assert.AreEqual(y, expectedY);
        }

        [Test]
        [TestCase(100, 664)]
        [TestCase(431, 333)]
        public void GetY_ShouldReturnY_DecreasingFunc(int x, int expectedY)
        {
            Line line = new Line(new Point(25, 739), new Point(431, 333));
            int y = line.GetY(x);
            Assert.AreEqual(y, expectedY);
        }
    }
}