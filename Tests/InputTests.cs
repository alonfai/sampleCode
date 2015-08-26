using NUnit.Framework;
using KMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMP.Shared;

namespace Tests
{
    [TestFixture]
    [Category("InputTests")]
    public class InputTests
    {
        [Test]
        public void EmptyText()
        {
            var input = new Input("", "hello");
            Assert.IsFalse(input.IsValid);
            Assert.Contains(Errors.EmptyText, input.ErrorList);
        }

        [Test]
        public void NullText()
        {
            var input = new Input(null, "hello");
            Assert.IsFalse(input.IsValid);
            Assert.Contains(Errors.EmptyText, input.ErrorList);
        }

        [Test]
        public void SubTextIsSpaces()
        {
            var input = new Input("Hello", " ");
            Assert.IsTrue(input.IsValid);
            CollectionAssert.IsEmpty(input.ErrorList);
        }

        [Test]
        public void TextIsSpacesOnly()
        {
            var input = new Input("  ", "h");
            Assert.IsTrue(input.IsValid);
            CollectionAssert.IsEmpty(input.ErrorList);
        }

        [Test]
        public void TextAndSubTextEmptySpaces()
        {
            var input = new Input("   ", " ");
            Assert.IsTrue(input.IsValid);
            CollectionAssert.IsEmpty(input.ErrorList);
        }

        [Test]
        public void EmptySubText()
        {
            var input = new Input("cocacola coca", "");
            Assert.IsFalse(input.IsValid);
            Assert.Contains(Errors.EmptySubText, input.ErrorList);
        }

        [Test]
        public void NullSubText()
        {
            var input = new Input("cocacola coca", null);
            Assert.IsFalse(input.IsValid);
            Assert.Contains(Errors.EmptySubText, input.ErrorList);
        }

        [Test]
        public void TextAndSubTextSameSize()
        {
            var input = new Input("Hello", "helLo");
            Assert.IsTrue(input.IsValid);
            CollectionAssert.IsEmpty(input.ErrorList);
        }

        [Test]
        public void SubTextLongerThanText_Failure()
        {
            var input = new Input("coca", "cocacola");
            Assert.IsFalse(input.IsValid);
            Assert.Contains(Errors.SubTextLongerThanText, input.ErrorList);
        }

        [Test]
        public void SubTextShorterThanText_Success()
        {
            var input = new Input("cocacola", "coc");
            Assert.IsTrue(input.IsValid);
            Assert.IsEmpty(input.ErrorList);
        }
    }
}
