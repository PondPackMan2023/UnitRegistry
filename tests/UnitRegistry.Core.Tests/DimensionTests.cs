using NUnit.Framework;

namespace UnitRegistry.Core.Tests
{
    [TestFixture]
    public sealed class DimensionTests
    {
        [Test]
        public void SameKeyDimensionsAreEqualByValue()
        {
            var left = new Dimension("length");
            var right = new Dimension("length");

            Assert.That(left, Is.EqualTo(right));
            Assert.That(left == right, Is.True);
            Assert.That(left != right, Is.False);
        }

        [Test]
        public void DifferentKeysDimensionsAreNotEqual()
        {
            var left = new Dimension("length");
            var right = new Dimension("time");

            Assert.That(left, Is.Not.EqualTo(right));
            Assert.That(left == right, Is.False);
            Assert.That(left != right, Is.True);
        }

        [Test]
        public void EqualDimensionsProduceSameHashCode()
        {
            var left = new Dimension("length");
            var right = new Dimension("length");

            Assert.That(left.GetHashCode(), Is.EqualTo(right.GetHashCode()));
        }

        [Test]
        public void BuiltInIdentityIsStable()
        {
            var first = Dimensions.Length;
            var second = Dimensions.Length;

            Assert.That(first, Is.SameAs(second));
            Assert.That(first.Key, Is.EqualTo("length"));
        }

        [Test]
        public void LengthIsNotTime()
        {
            Assert.That(Dimensions.Length, Is.Not.EqualTo(Dimensions.Time));
            Assert.That(Dimensions.Length == Dimensions.Time, Is.False);
            Assert.That(Dimensions.Length != Dimensions.Time, Is.True);
        }

        [Test]
        public void NullOrWhitespaceKeyThrows()
        {
            Assert.That(() => new Dimension(null), Throws.ArgumentException);
            Assert.That(() => new Dimension(string.Empty), Throws.ArgumentException);
            Assert.That(() => new Dimension("   "), Throws.ArgumentException);
        }
    }
}
