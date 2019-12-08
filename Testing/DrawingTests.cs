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
        public void SimplePatternCreation()
        {
            var pattern = new SimpleWeaver.Harness() { StartValue = 1, Pattern = "4" }.GetPattern(10);            
            Assert.IsTrue(pattern.SequenceEqual(new int[] { 1, 5, 9, 13 }));
        }

        [TestMethod]
        public void ComplexPatternCreation()
        {
            var pattern = new SimpleWeaver.Harness() { StartValue = 0, Pattern = "+2-3" }.GetPattern(10);
            Assert.IsTrue(pattern.SequenceEqual(new int[] { 1, 2, 6, 7 }));
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
