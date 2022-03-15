using LanternFishSimulator.Part2;
using NUnit.Framework;
using System;
using System.Linq;

namespace LanternfishSimulator.Part2.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(18, 26)]
        public void GetNumberOfFishEachDay_ShouldReturnPopulation(int days, int result)
        {
            Simulator simulator = new Simulator(new long[] { 3, 4, 3, 1, 2 });
            long[] fishes = simulator.GetNumberOfFishEachDay(days);
            Assert.AreEqual(result, fishes.Sum());
        }
    }
}