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
    [Category("Main")]
    public class MainTests
    {
        private IInput input;

        [SetUp]
        protected void SetUp()
        {
            input = Substitute.For<IInput>();
        }

        [Test]
        public void NullInput()
        {
            int[] matches;
            var result = Main.Run(null, out matches, false);
            Assert.False(result);
        }

        [Test]
        public void EmptyInput()
        {
            int[] matches;
            input.Text.Returns("");
            input.SubText.Returns("");
            input.IsValid.Returns(false);
            var result = Main.Run(input, out matches, false);
            Assert.False(result);
        }

        [Test]
        public void ValidInput()
        {
            int[] matches;
            input.Text.Returns("HelLo Alan");
            input.SubText.Returns("l");
            input.IsValid.Returns(true);
            var result = Main.Run(input, out matches, false);
            Assert.True(result);
            CollectionAssert.IsNotEmpty(matches);
            CollectionAssert.AreEqual(new int[] { 3, 4, 8 }, matches);
        }

        [Test]
        public void NotValidInput()
        {
            int[] matches;
            input.Text.Returns("Col");
            input.SubText.Returns("Cola");
            input.IsValid.Returns(false);
            var result = Main.Run(input, out matches, false);
            Assert.False(result);
            CollectionAssert.IsEmpty(matches);
        }
    }
}
