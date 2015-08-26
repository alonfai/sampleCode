using NSubstitute;
using NUnit.Framework;
using KMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMP.Interfaces;

namespace Tests
{
    [TestFixture]
    [Category("AlgorithmTests")]
    public class AlgorithmTests
    {
        private IOverlapCalculator prefixCalculator;
        private IInput input;

        [SetUp]
        protected void SetUp()
        {
            prefixCalculator = Substitute.For<IOverlapCalculator>();
            input = Substitute.For<IInput>();
            prefixCalculator.IsCaseSensitive.Returns(false);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullableInput()
        {
            var algo = new Algorithm(null, prefixCalculator);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidInput()
        {
            input.Text.Returns("ca");
            input.SubText.Returns("coc");
            input.IsValid.Returns(false);
            prefixCalculator.Pattern.Returns("coc");

            var algo = new Algorithm(input, prefixCalculator);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullablePrefixCalculator()
        {
            input.Text.Returns("cocacola");
            input.SubText.Returns("coc");
            input.IsValid.Returns(true);

            var algo = new Algorithm(input, null);
        }

        [Test]
        public void ComputeNoMatches()
        {
            input.Text.Returns("cozcola");
            input.SubText.Returns("coc");
            input.IsValid.Returns(true);
            prefixCalculator.Pattern.Returns("coc");
            prefixCalculator.Compute().Returns(new int[] { 0, 0, 1 });

            var algo = new Algorithm(input, prefixCalculator);
            var matches = algo.FindMatches();
            CollectionAssert.IsEmpty(matches);
            Assert.That(matches.Length == 0);
            CollectionAssert.AreEqual(new int[] { }, matches);
        }

        [Test]
        public void ComputeMatchesCaseInsensitive()
        {
            input.Text.Returns("Polly put the kettle on, polly put the kettle on, pOLLy put the kettle on we'll all have tea");
            input.SubText.Returns("polly");
            input.IsValid.Returns(true);
            prefixCalculator.Compute().Returns(new int[] { 0, 0, 1, 0, 0 });
            prefixCalculator.Pattern.Returns("polly");

            var algo = new Algorithm(input, prefixCalculator, false);
            var matches = algo.FindMatches();
            CollectionAssert.IsNotEmpty(matches);
            Assert.That(matches.Length == 3);
            CollectionAssert.AreEqual(new int[] { 1, 26, 51 }, matches);
        }

        [Test]
        public void ComputeMatchesCaseSensitive()
        {
            input.Text.Returns("Coca coca is the best drink in the world");
            input.SubText.Returns("Coc");
            input.IsValid.Returns(true);
            prefixCalculator.Pattern.Returns("Coc");
            prefixCalculator.Compute().Returns(new int[] { 0, 0, 0 });

            var algo = new Algorithm(input, prefixCalculator, true);
            var matches = algo.FindMatches();
            CollectionAssert.IsNotEmpty(matches);
            Assert.That(matches.Length == 1);
            CollectionAssert.AreEqual(new int[] { 1 }, matches);
        }

        [Test]
        public void ComputeEmptySpaces()
        {
            input.Text.Returns("Coca cola is the best drink in the world");
            input.SubText.Returns(" ");
            input.IsValid.Returns(true);
            prefixCalculator.Pattern.Returns(" ");
            prefixCalculator.Compute().Returns(new int[] { 0 });

            var algo = new Algorithm(input, prefixCalculator);
            var matches = algo.FindMatches();
            CollectionAssert.IsNotEmpty(matches);
            Assert.That(matches.Length == 8);
            CollectionAssert.AreEqual(new int[] {5, 10, 13, 17,22 ,28, 31, 35 }, matches);
        }
    }
}
