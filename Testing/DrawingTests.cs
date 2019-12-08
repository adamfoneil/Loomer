using System;
using System.Linq;
using Loomer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class DrawingTests
    {
        [TestMethod]
        public void PatternCreation()
        {
            var pattern = SimpleWeaver.CreatePattern(new SimpleWeaver.Harness(1, 4), 10);
            Assert.IsTrue(pattern.SequenceEqual(new int[] { 1, 5, 9, 13 }));
        }

        [TestMethod]
        public void HarnessLetters()
        {
            var letters = SimpleWeaver.HarnessLetters;
            // I took first 10 because I didn't want to type them all
            Assert.IsTrue(letters.Take(10).SequenceEqual(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" }));
        }
    }
}
