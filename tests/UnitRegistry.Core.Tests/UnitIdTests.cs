using System;
using NUnit.Framework;

namespace UnitRegistry.Core.Tests
{
    [TestFixture]
    public sealed class UnitIdTests
    {
        [Test]
        public void SameValueUnitIdsAreEqual()
        {
            var left = new UnitId("meter");
            var right = new UnitId("meter");

            Assert.That(left, Is.EqualTo(right));
            Assert.That(left == right, Is.True);
            Assert.That(left != right, Is.False);
        }

        [Test]
        public void DifferentValuesAreNotEqual()
        {
            Assert.That(new UnitId("meter"), Is.Not.EqualTo(new UnitId("foot")));
        }

        [Test]
        public void EqualUnitIdsProduceSameHashCode()
        {
            var left = new UnitId("meter");
            var right = new UnitId("meter");

            Assert.That(left.GetHashCode(), Is.EqualTo(right.GetHashCode()));
        }

        [Test]
        public void ConstructorTrimsValue()
        {
            Assert.That(new UnitId(" meter ").Value, Is.EqualTo("meter"));
        }

        [Test]
        public void NullOrWhitespaceValueThrows()
        {
            Assert.That(() => new UnitId(null), Throws.ArgumentNullException);
            Assert.That(() => new UnitId(string.Empty), Throws.ArgumentException);
            Assert.That(() => new UnitId("   "), Throws.ArgumentException);
        }
    }
}