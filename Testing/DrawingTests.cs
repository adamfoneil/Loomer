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
            var pattern = SimpleWeaver.CreatePattern(new SimpleWeaver.PatternRule(1, 4), 10);
            Assert.IsTrue(pattern.SequenceEqual(new int[] { 1, 5, 9, 13 }));
        }
    }
}
