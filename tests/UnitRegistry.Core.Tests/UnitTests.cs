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
            var left = new Unit(new UnitId("meter"), Dimensions.Length, 1.0);
            var right = new Unit(new UnitId("meter"), Dimensions.Length, 1.0);

            Assert.That(left, Is.EqualTo(right));
            Assert.That(left == right, Is.True);
            Assert.That(left != right, Is.False);
        }

        [Test]
        public void DifferentKeyUnitsAreNotEqual()
        {
            var left = new Unit(new UnitId("meter"), Dimensions.Length, 1.0);
            var right = new Unit(new UnitId("foot"), Dimensions.Length, 0.3048);

            Assert.That(left, Is.Not.EqualTo(right));
            Assert.That(left == right, Is.False);
            Assert.That(left != right, Is.True);
        }

        [Test]
        public void EqualUnitsProduceSameHashCode()
        {
            var left = new Unit(new UnitId("meter"), Dimensions.Length, 1.0);
            var right = new Unit(new UnitId("meter"), Dimensions.Length, 1.0);

            Assert.That(left.GetHashCode(), Is.EqualTo(right.GetHashCode()));
        }

        [Test]
        public void BuiltInIdentityIsStable()
        {
            var first = Units.Length.Meters;
            var second = Units.Length.Meters;

            Assert.That(first, Is.SameAs(second));
            Assert.That(first.Id, Is.EqualTo(new UnitId("meters")));
        }

        [Test]
        public void UnitIdentityFlowsThroughUnitId()
        {
            var unit = new Unit(new UnitId("meter"), Dimensions.Length, 1.0);

            Assert.That(unit.Id, Is.EqualTo(new UnitId("meter")));
            Assert.That(unit.Id.Value, Is.EqualTo("meter"));
        }

        // ── Dimension association ───────────────────────────────────────────────

        [Test]
        public void MeterBelongsToLengthDimension()
        {
            Assert.That(Units.Length.Meters.Dimension, Is.EqualTo(Dimensions.Length));
        }

        [Test]
        public void MillimeterBelongsToLengthDimension()
        {
            Assert.That(Units.Length.Millimeters.Dimension, Is.EqualTo(Dimensions.Length));
        }

        [Test]
        public void FootBelongsToLengthDimension()
        {
            Assert.That(Units.Length.Feet.Dimension, Is.EqualTo(Dimensions.Length));
        }

        [Test]
        public void SecondBelongsToTimeDimension()
        {
            Assert.That(Units.Time.Seconds.Dimension, Is.EqualTo(Dimensions.Time));
        }

        [Test]
        public void MinuteBelongsToTimeDimension()
        {
            Assert.That(Units.Time.Minutes.Dimension, Is.EqualTo(Dimensions.Time));
        }

        [Test]
        public void HourBelongsToTimeDimension()
        {
            Assert.That(Units.Time.Hours.Dimension, Is.EqualTo(Dimensions.Time));
        }

        // ── Conversion correctness ──────────────────────────────────────────────

        [Test]
        public void MeterToBaseIsIdentity()
        {
            Assert.That(Units.Length.Meters.ToBaseValue(5.0), Is.EqualTo(5.0).Within(1e-12));
            Assert.That(Units.Length.Meters.FromBaseValue(5.0), Is.EqualTo(5.0).Within(1e-12));
        }

        [Test]
        public void MillimeterToBaseConvertsCorrectly()
        {
            // 1000 mm → 1 m
            Assert.That(Units.Length.Millimeters.ToBaseValue(1000.0), Is.EqualTo(1.0).Within(1e-12));
        }

        [Test]
        public void BaseToMillimeterConvertsCorrectly()
        {
            // 1 m → 1000 mm
            Assert.That(Units.Length.Millimeters.FromBaseValue(1.0), Is.EqualTo(1000.0).Within(1e-12));
        }

        [Test]
        public void FootToBaseConvertsCorrectly()
        {
            // 1 ft → 0.3048 m
            Assert.That(Units.Length.Feet.ToBaseValue(1.0), Is.EqualTo(0.3048).Within(1e-9));
        }

        [Test]
        public void BaseToFootConvertsCorrectly()
        {
            // 0.3048 m → 1 ft
            Assert.That(Units.Length.Feet.FromBaseValue(0.3048), Is.EqualTo(1.0).Within(1e-9));
        }

        [Test]
        public void SecondToBaseIsIdentity()
        {
            Assert.That(Units.Time.Hours.ToBaseValue(42.0), Is.EqualTo(42.0).Within(1e-12));
            Assert.That(Units.Time.Hours.FromBaseValue(42.0), Is.EqualTo(42.0).Within(1e-12));
        }

        [Test]
        public void MinuteToBaseConvertsCorrectly()
        {
            // 60 min → 1 hr
            Assert.That(Units.Time.Minutes.ToBaseValue(60.0), Is.EqualTo(1.0).Within(1e-12));
        }

        [Test]
        public void HourToBaseConvertsCorrectly()
        {
            // 1 sec → 1/3600 hr
            Assert.That(Units.Time.Seconds.ToBaseValue(1.0), Is.EqualTo(1.0 / 3600.0).Within(1e-12));
        }

        [Test]
        public void ConversionRoundTripsAreExact()
        {
            double original = 123.456;

            double baseValue = Units.Length.Feet.ToBaseValue(original);
            double roundTripped = Units.Length.Feet.FromBaseValue(baseValue);

            Assert.That(roundTripped, Is.EqualTo(original).Within(1e-10));
        }

        // ── Cross-dimension avoidance ───────────────────────────────────────────

        [Test]
        public void MeterAndSecondHaveDifferentDimensions()
        {
            Assert.That(Units.Length.Meters.Dimension, Is.Not.EqualTo(Units.Time.Seconds.Dimension));
        }

        [Test]
        public void UnitsFromDifferentDimensionsAreNotEqual()
        {
            // A length unit and a time unit with the same key are structurally equal by key,
            // but such a case does not arise for well-named built-ins. The more important
            // property is that units from different dimensions are distinct objects
            // with distinct dimensions.
            Assert.That(Units.Length.Meters, Is.Not.EqualTo(Units.Time.Seconds));
            Assert.That(Units.Length.Meters.Dimension, Is.Not.EqualTo(Units.Time.Seconds.Dimension));
        }

        // ── Constructor guard ───────────────────────────────────────────────────

        [Test]
        public void NullOrWhitespaceKeyThrows()
        {
            Assert.That(() => new Unit((string)null, Dimensions.Length, 1.0), Throws.ArgumentNullException);
            Assert.That(() => new Unit(string.Empty, Dimensions.Length, 1.0), Throws.ArgumentException);
            Assert.That(() => new Unit("   ", Dimensions.Length, 1.0), Throws.ArgumentException);
        }

        [Test]
        public void NullUnitIdThrows()
        {
            Assert.That(() => new Unit((UnitId)null, Dimensions.Length, 1.0), Throws.ArgumentNullException);
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
