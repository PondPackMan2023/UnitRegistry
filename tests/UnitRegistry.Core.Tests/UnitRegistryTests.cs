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

            registry.RegisterBaseUnit(Units.Length.Meter);
            registry.Register(Units.Length.Millimeter);
            registry.Register(Units.Length.Foot);

            Assert.That(registry.GetBaseUnit(Dimensions.Length), Is.SameAs(Units.Length.Meter));
            Assert.That(registry.GetUnit(Dimensions.Length, new UnitId("millimeter")), Is.SameAs(Units.Length.Millimeter));
        }

        [Test]
        public void RejectsDuplicateDimensionAndUnitKey()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Length.Meter);

            Assert.That(
                () => registry.Register(new Unit(new UnitId("meter"), Dimensions.Length, 2.0)),
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

            registry.RegisterBaseUnit(Units.Length.Meter);

            Assert.That(() => registry.RegisterBaseUnit(Units.Length.Foot), Throws.InvalidOperationException);
        }

        [Test]
        public void FreezeRequiresBaseUnitForEachRegisteredDimension()
        {
            var registry = new UnitsRegistry();

            registry.Register(Units.Length.Foot);

            Assert.That(() => registry.Freeze(), Throws.InvalidOperationException);
        }

        [Test]
        public void LooksUpUnitsByDimensionAndKey()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Time.Second);
            registry.Register(Units.Time.Minute);

            Assert.That(registry.TryGetUnit(Dimensions.Time, new UnitId("minute"), out var unit), Is.True);
            Assert.That(unit, Is.SameAs(Units.Time.Minute));
            Assert.That(registry.GetUnit(Dimensions.Time, new UnitId("second")), Is.SameAs(Units.Time.Second));
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

            registry.RegisterBaseUnit(Units.Length.Meter);
            registry.Register(Units.Length.Millimeter);
            registry.Register(Units.Length.Foot);

            var units = registry.GetUnits(Dimensions.Length).ToArray();

            Assert.That(units, Has.Length.EqualTo(3));
            Assert.That(units, Has.Member(Units.Length.Meter));
            Assert.That(units, Has.Member(Units.Length.Millimeter));
            Assert.That(units, Has.Member(Units.Length.Foot));
        }

        [Test]
        public void DefaultRegistryIsPrePopulated()
        {
            var registry = UnitsRegistry.Default;

            Assert.That(registry.GetBaseUnit(Dimensions.Length), Is.SameAs(Units.Length.Meter));
            Assert.That(registry.GetBaseUnit(Dimensions.Time), Is.SameAs(Units.Time.Second));
            Assert.That(registry.GetUnit(Dimensions.Length, Units.Length.Foot.Id), Is.SameAs(Units.Length.Foot));
            Assert.That(registry.GetUnit(Dimensions.Time, Units.Time.Hour.Id), Is.SameAs(Units.Time.Hour));
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

            registry.RegisterBaseUnit(Units.Length.Meter);
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