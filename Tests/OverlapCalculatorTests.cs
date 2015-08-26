using NUnit.Framework;
using KMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    [Category("OverlapCalculatorTests")]
    public class OverlapCalculatorTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyPattern()
        {
            var calculator = new OverlapCalculator("");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullablePattern()
        {
            var calculator = new OverlapCalculator(null);
        }

        [Test]
        public void ComputeNoMatchingOverlaps()
        {
            var calculator = new OverlapCalculator("abdeft", true);
            var result = calculator.Compute();
            var expected = new int[] { 0, 0, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void ComputeMatchedOverlaps()
        {
            var calculator = new OverlapCalculator("ATTATACA", true);
            var result = calculator.Compute();
            var expected = new int[] { 0, 0, 0, 1, 2, 1, 0, 1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void ComputeWithUpperAndLowerCase()
        {
            var calculator = new OverlapCalculator("cocaCoLa", false);
            var result = calculator.Compute();
            var expected = new int[] { 0, 0, 1, 0, 1, 2, 0, 0 };
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
