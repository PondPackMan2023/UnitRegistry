using System;
using System.Linq;
using NUnit.Framework;

namespace UnitRegistry.Core.Tests
{
    [TestFixture]
    public sealed class UnitRegistryTests
    {
        [Test]
        public void RegistersValidUnitsSuccessfully()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Length.Meters);
            registry.Register(Units.Length.Millimeters);
            registry.Register(Units.Length.Feet);

            Assert.That(registry.GetBaseUnit(Dimensions.Length), Is.SameAs(Units.Length.Meters));
            Assert.That(registry.GetUnit(Dimensions.Length, new UnitId("millimeters")), Is.SameAs(Units.Length.Millimeters));
        }

        [Test]
        public void RejectsDuplicateDimensionAndUnitKey()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Length.Meters);

            Assert.That(
                () => registry.Register(new Unit(new UnitId("meters"), Dimensions.Length, 2.0)),
                Throws.InvalidOperationException);
        }

        [Test]
        public void AllowsSameUnitKeyInDifferentDimensions()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(new Unit(new UnitId("base"), Dimensions.Length, 1.0));
            registry.RegisterBaseUnit(new Unit(new UnitId("base"), Dimensions.Time, 1.0));

            Assert.That(registry.GetBaseUnit(Dimensions.Length).Dimension, Is.EqualTo(Dimensions.Length));
            Assert.That(registry.GetBaseUnit(Dimensions.Time).Dimension, Is.EqualTo(Dimensions.Time));
        }

        [Test]
        public void RejectsSecondBaseUnitForSameDimension()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Length.Meters);

            Assert.That(() => registry.RegisterBaseUnit(Units.Length.Feet), Throws.InvalidOperationException);
        }

        [Test]
        public void FreezeRequiresBaseUnitForEachRegisteredDimension()
        {
            var registry = new UnitsRegistry();

            registry.Register(Units.Length.Feet);

            Assert.That(() => registry.Freeze(), Throws.InvalidOperationException);
        }

        [Test]
        public void LooksUpUnitsByDimensionAndKey()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Time.Hours);
            registry.Register(Units.Time.Minutes);
            registry.Register(Units.Time.Seconds);

            Assert.That(registry.TryGetUnit(Dimensions.Time, new UnitId("minutes"), out var unit), Is.True);
            Assert.That(unit, Is.SameAs(Units.Time.Minutes));
            Assert.That(registry.GetUnit(Dimensions.Time, new UnitId("seconds")), Is.SameAs(Units.Time.Seconds));
        }

        [Test]
        public void DuplicateUnitIdIsRejectedPerDimension()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(new Unit(new UnitId("base"), Dimensions.Length, 1.0));

            Assert.That(
                () => registry.Register(new Unit(new UnitId("base"), Dimensions.Length, 2.0)),
                Throws.InvalidOperationException);
        }

        [Test]
        public void EnumeratesUnitsForDimension()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Length.Meters);
            registry.Register(Units.Length.Millimeters);
            registry.Register(Units.Length.Feet);

            var units = registry.GetUnits(Dimensions.Length).ToArray();

            Assert.That(units, Has.Length.EqualTo(3));
            Assert.That(units, Has.Member(Units.Length.Meters));
            Assert.That(units, Has.Member(Units.Length.Millimeters));
            Assert.That(units, Has.Member(Units.Length.Feet));
        }

        [Test]
        public void DefaultRegistryIsPrePopulated()
        {
            var registry = UnitsRegistry.Default;

            Assert.That(registry.GetBaseUnit(Dimensions.Length), Is.SameAs(Units.Length.Meters));
            Assert.That(registry.GetBaseUnit(Dimensions.Time), Is.SameAs(Units.Time.Hours));
            Assert.That(registry.GetUnit(Dimensions.Length, Units.Length.Feet.Id), Is.SameAs(Units.Length.Feet));
            Assert.That(registry.GetUnit(Dimensions.Time, Units.Time.Hours.Id), Is.SameAs(Units.Time.Hours));
        }

        [Test]
        public void DefaultRegistryRejectsMutationAfterInitialization()
        {
            Assert.That(
                () => UnitsRegistry.Default.Register(new Unit(new UnitId("yard"), Dimensions.Length, 0.9144)),
                Throws.InvalidOperationException);
        }

        [Test]
        public void FrozenCustomRegistryRejectsMutation()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Length.Meters);
            registry.Freeze();

            Assert.That(
                () => registry.Register(new Unit(new UnitId("yard"), Dimensions.Length, 0.9144)),
                Throws.InvalidOperationException);
        }

        [Test]
        public void RegistrationRejectsNullUnit()
        {
            var registry = new UnitsRegistry();

            Assert.That(() => registry.Register(null), Throws.ArgumentNullException);
            Assert.That(() => registry.RegisterBaseUnit(null), Throws.ArgumentNullException);
        }
    }
}