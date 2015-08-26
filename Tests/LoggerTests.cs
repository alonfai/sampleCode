using KMP;
using KMP.Shared;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    [Category("Logger")]
    public class LoggerTests
    {
        [SetUp]
        public void SetUp()
        {
            Logger.Init();
        }

        [Test]
        public void PushMessage()
        {
            Logger.Push("Test Message");
            var messages = Logger.Get();
            Assert.NotNull(messages);
            Assert.That(messages.Count == 1);
        }

        [Test]
        public void GetMessages()
        {
            var messages = Logger.Get();
            Assert.NotNull(messages);
            CollectionAssert.IsEmpty(messages);

            Logger.Push("Test Message 1");
            Logger.Push("Test Message 2");
            Logger.Push("Test Message 3");
            messages = Logger.Get();

            Assert.That(messages.Count == 3);
        }

        [Test]
        public void FlushEmptyLog()
        {
            Logger.Flush();
            var messages = Logger.Get();
            Assert.NotNull(messages);
            CollectionAssert.IsEmpty(messages);
        }

        [Test]
        public void FlushCollectionOfMessage()
        {
            Logger.Push("Test Message 1");
            Logger.Push("Test Message 2");
            Logger.Push("Test Message 3");
            var messages = Logger.Flush();
            Assert.NotNull(messages);
            CollectionAssert.IsNotEmpty(messages);
            Assert.That(messages.Count == 3);
        }
    }
}
