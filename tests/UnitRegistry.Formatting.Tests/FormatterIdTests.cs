using System;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class FormatterIdTests
    {
        [Test]
        public void SameValueFormatterIdsAreEqual()
        {
            var left = new FormatterId("default");
            var right = new FormatterId("default");

            Assert.That(left, Is.EqualTo(right));
            Assert.That(left == right, Is.True);
            Assert.That(left != right, Is.False);
        }

        [Test]
        public void DifferentValuesAreNotEqual()
        {
            Assert.That(new FormatterId("default"), Is.Not.EqualTo(new FormatterId("compact")));
        }

        [Test]
        public void EqualFormatterIdsProduceSameHashCode()
        {
            var left = new FormatterId("default");
            var right = new FormatterId("default");

            Assert.That(left.GetHashCode(), Is.EqualTo(right.GetHashCode()));
        }

        [Test]
        public void ConstructorTrimsValue()
        {
            Assert.That(new FormatterId(" default ").Value, Is.EqualTo("default"));
        }

        [Test]
        public void NullOrWhitespaceValueThrows()
        {
            Assert.That(() => new FormatterId(null), Throws.ArgumentNullException);
            Assert.That(() => new FormatterId(string.Empty), Throws.ArgumentException);
            Assert.That(() => new FormatterId("   "), Throws.ArgumentException);
        }

        [Test]
        public void ToStringReturnsValue()
        {
            Assert.That(new FormatterId("default").ToString(), Is.EqualTo("default"));
        }
    }
}
