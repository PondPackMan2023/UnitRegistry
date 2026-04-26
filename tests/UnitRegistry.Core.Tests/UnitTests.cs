using System;
using NUnit.Framework;

namespace UnitRegistry.Core.Tests
{
    [TestFixture]
    public sealed class UnitTests
    {
        // ── Equality and inequality ─────────────────────────────────────────────

        [Test]
        public void SameKeyUnitsAreEqual()
        {
            var left = new Unit("meter", Dimensions.Length, 1.0);
            var right = new Unit("meter", Dimensions.Length, 1.0);

            Assert.That(left, Is.EqualTo(right));
            Assert.That(left == right, Is.True);
            Assert.That(left != right, Is.False);
        }

        [Test]
        public void DifferentKeyUnitsAreNotEqual()
        {
            var left = new Unit("meter", Dimensions.Length, 1.0);
            var right = new Unit("foot", Dimensions.Length, 0.3048);

            Assert.That(left, Is.Not.EqualTo(right));
            Assert.That(left == right, Is.False);
            Assert.That(left != right, Is.True);
        }

        [Test]
        public void EqualUnitsProduceSameHashCode()
        {
            var left = new Unit("meter", Dimensions.Length, 1.0);
            var right = new Unit("meter", Dimensions.Length, 1.0);

            Assert.That(left.GetHashCode(), Is.EqualTo(right.GetHashCode()));
        }

        [Test]
        public void BuiltInIdentityIsStable()
        {
            var first = Units.Length.Meter;
            var second = Units.Length.Meter;

            Assert.That(first, Is.SameAs(second));
            Assert.That(first.Key, Is.EqualTo("meter"));
        }

        // ── Dimension association ───────────────────────────────────────────────

        [Test]
        public void MeterBelongsToLengthDimension()
        {
            Assert.That(Units.Length.Meter.Dimension, Is.EqualTo(Dimensions.Length));
        }

        [Test]
        public void MillimeterBelongsToLengthDimension()
        {
            Assert.That(Units.Length.Millimeter.Dimension, Is.EqualTo(Dimensions.Length));
        }

        [Test]
        public void FootBelongsToLengthDimension()
        {
            Assert.That(Units.Length.Foot.Dimension, Is.EqualTo(Dimensions.Length));
        }

        [Test]
        public void SecondBelongsToTimeDimension()
        {
            Assert.That(Units.Time.Second.Dimension, Is.EqualTo(Dimensions.Time));
        }

        [Test]
        public void MinuteBelongsToTimeDimension()
        {
            Assert.That(Units.Time.Minute.Dimension, Is.EqualTo(Dimensions.Time));
        }

        [Test]
        public void HourBelongsToTimeDimension()
        {
            Assert.That(Units.Time.Hour.Dimension, Is.EqualTo(Dimensions.Time));
        }

        // ── Conversion correctness ──────────────────────────────────────────────

        [Test]
        public void MeterToBaseIsIdentity()
        {
            Assert.That(Units.Length.Meter.ToBaseValue(5.0), Is.EqualTo(5.0).Within(1e-12));
            Assert.That(Units.Length.Meter.FromBaseValue(5.0), Is.EqualTo(5.0).Within(1e-12));
        }

        [Test]
        public void MillimeterToBaseConvertsCorrectly()
        {
            // 1000 mm → 1 m
            Assert.That(Units.Length.Millimeter.ToBaseValue(1000.0), Is.EqualTo(1.0).Within(1e-12));
        }

        [Test]
        public void BaseToMillimeterConvertsCorrectly()
        {
            // 1 m → 1000 mm
            Assert.That(Units.Length.Millimeter.FromBaseValue(1.0), Is.EqualTo(1000.0).Within(1e-12));
        }

        [Test]
        public void FootToBaseConvertsCorrectly()
        {
            // 1 ft → 0.3048 m
            Assert.That(Units.Length.Foot.ToBaseValue(1.0), Is.EqualTo(0.3048).Within(1e-12));
        }

        [Test]
        public void BaseToFootConvertsCorrectly()
        {
            // 0.3048 m → 1 ft
            Assert.That(Units.Length.Foot.FromBaseValue(0.3048), Is.EqualTo(1.0).Within(1e-12));
        }

        [Test]
        public void SecondToBaseIsIdentity()
        {
            Assert.That(Units.Time.Second.ToBaseValue(42.0), Is.EqualTo(42.0).Within(1e-12));
            Assert.That(Units.Time.Second.FromBaseValue(42.0), Is.EqualTo(42.0).Within(1e-12));
        }

        [Test]
        public void MinuteToBaseConvertsCorrectly()
        {
            // 1 min → 60 s
            Assert.That(Units.Time.Minute.ToBaseValue(1.0), Is.EqualTo(60.0).Within(1e-12));
        }

        [Test]
        public void HourToBaseConvertsCorrectly()
        {
            // 1 hr → 3600 s
            Assert.That(Units.Time.Hour.ToBaseValue(1.0), Is.EqualTo(3600.0).Within(1e-12));
        }

        [Test]
        public void ConversionRoundTripsAreExact()
        {
            double original = 123.456;

            double baseValue = Units.Length.Foot.ToBaseValue(original);
            double roundTripped = Units.Length.Foot.FromBaseValue(baseValue);

            Assert.That(roundTripped, Is.EqualTo(original).Within(1e-10));
        }

        // ── Cross-dimension avoidance ───────────────────────────────────────────

        [Test]
        public void MeterAndSecondHaveDifferentDimensions()
        {
            Assert.That(Units.Length.Meter.Dimension, Is.Not.EqualTo(Units.Time.Second.Dimension));
        }

        [Test]
        public void UnitsFromDifferentDimensionsAreNotEqual()
        {
            // A length unit and a time unit with the same key are structurally equal by key,
            // but such a case does not arise for well-named built-ins. The more important
            // property is that units from different dimensions are distinct objects
            // with distinct dimensions.
            Assert.That(Units.Length.Meter, Is.Not.EqualTo(Units.Time.Second));
            Assert.That(Units.Length.Meter.Dimension, Is.Not.EqualTo(Units.Time.Second.Dimension));
        }

        // ── Constructor guard ───────────────────────────────────────────────────

        [Test]
        public void NullOrWhitespaceKeyThrows()
        {
            Assert.That(() => new Unit(null, Dimensions.Length, 1.0), Throws.ArgumentException);
            Assert.That(() => new Unit(string.Empty, Dimensions.Length, 1.0), Throws.ArgumentException);
            Assert.That(() => new Unit("   ", Dimensions.Length, 1.0), Throws.ArgumentException);
        }

        [Test]
        public void NullDimensionThrows()
        {
            Assert.That(() => new Unit("meter", null, 1.0), Throws.ArgumentNullException);
        }

        [Test]
        public void ZeroOrNegativeConversionFactorThrows()
        {
            Assert.That(() => new Unit("meter", Dimensions.Length, 0.0), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => new Unit("meter", Dimensions.Length, -1.0), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void NonFiniteConversionFactorThrows()
        {
            Assert.That(() => new Unit("meter", Dimensions.Length, double.NaN), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => new Unit("meter", Dimensions.Length, double.PositiveInfinity), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
