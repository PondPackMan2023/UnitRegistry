using System;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class NumericFormatterIdTests
    {
        [Test]
        public void SameValueFormatterIdsAreEqual()
        {
            var left = new NumericFormatterId("default");
            var right = new NumericFormatterId("default");

            Assert.That(left, Is.EqualTo(right));
            Assert.That(left == right, Is.True);
            Assert.That(left != right, Is.False);
        }

        [Test]
        public void DifferentValuesAreNotEqual()
        {
            Assert.That(new NumericFormatterId("default"), Is.Not.EqualTo(new NumericFormatterId("compact")));
        }

        [Test]
        public void EqualFormatterIdsProduceSameHashCode()
        {
            var left = new NumericFormatterId("default");
            var right = new NumericFormatterId("default");

            Assert.That(left.GetHashCode(), Is.EqualTo(right.GetHashCode()));
        }

        [Test]
        public void ConstructorTrimsValue()
        {
            Assert.That(new NumericFormatterId(" default ").Value, Is.EqualTo("default"));
        }

        [Test]
        public void NullOrWhitespaceValueThrows()
        {
            Assert.That(() => new NumericFormatterId(null), Throws.ArgumentNullException);
            Assert.That(() => new NumericFormatterId(string.Empty), Throws.ArgumentException);
            Assert.That(() => new NumericFormatterId("   "), Throws.ArgumentException);
        }

        [Test]
        public void ToStringReturnsValue()
        {
            Assert.That(new NumericFormatterId("default").ToString(), Is.EqualTo("default"));
        }
    }
}
