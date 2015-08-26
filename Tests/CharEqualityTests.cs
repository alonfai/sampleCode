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
    [Category("CharEqualityTests")]
    public class CharEqualityTests
    {
        [Test]
        public void CaseSensitiveMethod()
        {
            var equal = CharEquality.IsCharEqual('A', 'a', true);
            Assert.IsFalse(equal);
        }

        [Test]
        public void CaseInsensitiveMethod()
        {
            var equal = CharEquality.IsCharEqual('A', 'a', false);
            Assert.IsTrue(equal);
        }

        [Test]
        public void CaseInsensitiveDefault()
        {
            var equal = CharEquality.IsCharEqual('A', 'a');
            Assert.IsTrue(equal);
        }
    }
}
