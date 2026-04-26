using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace UnitRegistry.Core.Tests
{
    [TestFixture]
    public sealed class HaestadTranscriptionTests
    {
        [Test]
        public void AllHelperUnitsAreRegisteredInDefaultRegistry()
        {
            var registry = UnitsRegistry.Default;

            foreach (var unit in GetAllHelperUnits())
            {
                Assert.That(registry.GetUnit(unit.Dimension, unit.Id), Is.SameAs(unit));
            }
        }

        [Test]
        public void EveryRegisteredBaseUnitUsesIdentityFactor()
        {
            var registry = UnitsRegistry.Default;

            foreach (var group in GetDimensionUnitGroups())
            {
                var baseUnit = registry.GetBaseUnit(group[0].Dimension);
                Assert.That(baseUnit.ConversionFactor, Is.EqualTo(1.0).Within(1e-12));
            }
        }

        [Test]
        public void PairwiseConversionWithinDimensionMatchesFactorRatio()
        {
            const double value = 7.25;

            foreach (var group in GetDimensionUnitGroups())
            {
                if (group.Count < 2)
                {
                    continue;
                }

                Unit from = group[0];
                Unit to = group[1];

                double expected = value * from.ConversionFactor / to.ConversionFactor;
                double actual = to.FromBaseValue(from.ToBaseValue(value));

                Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
            }
        }

        [Test]
        public void RoundTripConversionIsStableForAllHelperUnits()
        {
            const double original = 123.456789;

            foreach (var unit in GetAllHelperUnits())
            {
                double baseValue = unit.ToBaseValue(original);
                double roundTrip = unit.FromBaseValue(baseValue);
                Assert.That(roundTrip, Is.EqualTo(original).Within(1e-10));
            }
        }

        [Test]
        public void CrossDimensionLookupIsRejected()
        {
            var registry = UnitsRegistry.Default;

            Assert.That(Units.Length.Feet.Dimension, Is.Not.EqualTo(Units.Time.Seconds.Dimension));
            Assert.That(
                () => registry.GetUnit(Dimensions.Time, Units.Length.Feet.Id),
                Throws.TypeOf<KeyNotFoundException>());
        }

        [Test]
        public void UnsupportedUnitsAreNotRegistered()
        {
            var registry = UnitsRegistry.Default;

            Assert.That(registry.TryGetUnit(Dimensions.Temperature, new UnitId("celsius"), out _), Is.False);
            Assert.That(registry.TryGetUnit(Dimensions.Slope, new UnitId("percentSlope"), out _), Is.False);
            Assert.That(registry.TryGetUnit(Dimensions.EmitterCoefficient, new UnitId("gpmPerPSI"), out _), Is.False);
            Assert.That(registry.TryGetUnit(Dimensions.InfiltrationPerUnitDepth, new UnitId("inchesPerHourPerFeetToKexp"), out _), Is.False);
            Assert.That(registry.TryGetUnit(Dimensions.DrainCoefficientUnit, new UnitId("drainCoeffMMPerHour"), out _), Is.False);
            Assert.That(registry.TryGetUnit(Dimensions.WeirCoefficientParameterized, new UnitId("weirCoefficientParameterizedUS"), out _), Is.False);
        }

        private static IReadOnlyList<IReadOnlyList<Unit>> GetDimensionUnitGroups()
        {
            return typeof(Units)
                .GetNestedTypes(BindingFlags.Public)
                .OrderBy(t => t.Name, StringComparer.Ordinal)
                .Select(GetUnitsFromHelperType)
                .Where(group => group.Count > 0)
                .ToArray();
        }

        private static IReadOnlyList<Unit> GetAllHelperUnits()
        {
            return GetDimensionUnitGroups().SelectMany(g => g).ToArray();
        }

        private static IReadOnlyList<Unit> GetUnitsFromHelperType(Type helperType)
        {
            var allField = helperType.GetField("All", BindingFlags.Public | BindingFlags.Static);
            if (allField == null)
            {
                return Array.Empty<Unit>();
            }

            var units = allField.GetValue(null) as Unit[];
            return units ?? Array.Empty<Unit>();
        }
    }
}