using System;
using System.Globalization;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class NumericFormatterTests
    {
        // ── Constructor and identity ────────────────────────────────────────────

        [Test]
        public void FormatterOwnsBothIdAndRegistry()
        {
            var id = new NumericFormatterId("default");
            var registry = UnitsRegistry.Default;

            var formatter = new NumericFormatter(id, registry, "default label");

            Assert.That(formatter.Id, Is.EqualTo(id));
            Assert.That(formatter.UnitRegistry, Is.SameAs(registry));
            Assert.That(formatter.Label, Is.EqualTo("default label"));
        }

        [Test]
        public void FormatterCanConstructFromString()
        {
            var registry = UnitsRegistry.Default;

            var formatter = new NumericFormatter("default", registry, "label");

            Assert.That(formatter.Id, Is.EqualTo(new NumericFormatterId("default")));
            Assert.That(formatter.UnitRegistry, Is.SameAs(registry));
        }

        [Test]
        public void FormatterIdentityIsDiscoverable()
        {
            var id = new NumericFormatterId("compact");
            var formatter = new NumericFormatter(id, UnitsRegistry.Default, "label");

            Assert.That(formatter.Id.Value, Is.EqualTo("compact"));
        }

        [Test]
        public void NullIdThrows()
        {
            Assert.That(
                () => new NumericFormatter((NumericFormatterId)null, UnitsRegistry.Default, "label"),
                Throws.ArgumentNullException);
        }

        [Test]
        public void NullRegistryThrows()
        {
            Assert.That(
                () => new NumericFormatter(new NumericFormatterId("default"), null, "label"),
                Throws.ArgumentNullException);
        }

        [Test]
        public void NullStringIdThrows()
        {
            Assert.That(
                () => new NumericFormatter((string)null, UnitsRegistry.Default, "label"),
                Throws.ArgumentNullException);
        }

        [Test]
        public void NullLabelThrows()
        {
            Assert.That(
                () => new NumericFormatter("default", UnitsRegistry.Default, null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void EmptyLabelThrows()
        {
            Assert.That(
                () => new NumericFormatter("default", UnitsRegistry.Default, ""),
                Throws.ArgumentException);
        }

        [Test]
        public void SingleSpaceLabelIsAllowed()
        {
            var formatter = new NumericFormatter("default", UnitsRegistry.Default, " ");

            Assert.That(formatter.Label, Is.EqualTo(" "));
        }

        [Test]
        public void ToStringReturnsFormatterId()
        {
            var formatter = new NumericFormatter("default", UnitsRegistry.Default, "label");

            Assert.That(formatter.ToString(), Is.EqualTo("label"));
        }

        // ── Format specifier and provider ───────────────────────────────────────

        [Test]
        public void DefaultFormatSpecifierIsG()
        {
            var formatter = new NumericFormatter("default", UnitsRegistry.Default, "label");

            Assert.That(formatter.FormatSpecifier, Is.EqualTo("G"));
        }

        [Test]
        public void CustomFormatSpecifierIsRespected()
        {
            var formatter = new NumericFormatter("fixed", UnitsRegistry.Default, "label", "F2");

            Assert.That(formatter.FormatSpecifier, Is.EqualTo("F2"));
        }

        [Test]
        public void NullOrWhitespaceFormatSpecifierThrows()
        {
            Assert.That(
                () => new NumericFormatter("test", UnitsRegistry.Default, "label", null),
                Throws.ArgumentException);
            Assert.That(
                () => new NumericFormatter("test", UnitsRegistry.Default, "label", ""),
                Throws.ArgumentException);
            Assert.That(
                () => new NumericFormatter("test", UnitsRegistry.Default, "label", "   "),
                Throws.ArgumentException);
        }

        [Test]
        public void FormatProviderDefaultsToNull()
        {
            var formatter = new NumericFormatter("default", UnitsRegistry.Default, "label");

            Assert.That(formatter.FormatProvider, Is.Null);
        }

        [Test]
        public void CustomFormatProviderIsStored()
        {
            var culture = new CultureInfo("de-DE");
            var formatter = new NumericFormatter("german", UnitsRegistry.Default, "label", "F2", culture);

            Assert.That(formatter.FormatProvider, Is.SameAs(culture));
        }

        // ── Format with source unit only ────────────────────────────────────────

        [Test]
        public void FormatAppliesFormatSpecifier()
        {
            var formatter = new NumericFormatter("fixed", UnitsRegistry.Default, "label", "F2");
            double value = 1.23456;

            string result = formatter.Format(value);

            Assert.That(result, Is.EqualTo("1.23"));
        }

        [Test]
        public void FormatGeneralFormat()
        {
            var formatter = new NumericFormatter("general", UnitsRegistry.Default, "label", "G");
            double value = 123.456;

            string result = formatter.Format(value);

            Assert.That(result, Is.EqualTo("123.456"));
        }

        [Test]
        public void FormatScientific()
        {
            var formatter = new NumericFormatter("scientific", UnitsRegistry.Default, "label", "E2");
            double value = 1234.5;

            string result = formatter.Format(value);

            Assert.That(result, Is.EqualTo("1.23E+003"));
        }



        // ── Format with display unit conversion ─────────────────────────────────

        [Test]
        public void FormatWithDisplayUnitConvertsCorrectly()
        {
            var formatter = new NumericFormatter("foot", UnitsRegistry.Default, "label", "F4");

            // 1 meter = 3.28084 feet
            string result = formatter.Format(1.0, Units.Length.Meter, Units.Length.Foot);

            Assert.That(result, Is.EqualTo("3.2808"));
        }

        [Test]
        public void FormatWithDisplayUnitRoundTrips()
        {
            var formatter = new NumericFormatter("roundtrip", UnitsRegistry.Default, "label", "F6");

            // Convert to mm and back
            string result = formatter.Format(123.456, Units.Length.Meter, Units.Length.Millimeter);

            // 123.456 m = 123456 mm
            Assert.That(result, Is.EqualTo("123456.000000"));
        }

        [Test]
        public void FormatWithTimeUnitConversion()
        {
            var formatter = new NumericFormatter("hours", UnitsRegistry.Default, "label", "F2");

            // 1 hour = 3600 seconds
            string result = formatter.Format(3600.0, Units.Time.Second, Units.Time.Hour);

            Assert.That(result, Is.EqualTo("1.00"));
        }

        [Test]
        public void FormatWithDisplayUnitNullSourceThrows()
        {
            var formatter = new NumericFormatter("test", UnitsRegistry.Default, "label");

            Assert.That(
                () => formatter.Format(42.0, null, Units.Length.Foot),
                Throws.ArgumentNullException);
        }

        [Test]
        public void FormatWithDisplayUnitNullDisplayThrows()
        {
            var formatter = new NumericFormatter("test", UnitsRegistry.Default, "label");

            Assert.That(
                () => formatter.Format(42.0, Units.Length.Meter, null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void FormatWithCrossDimensionUnitsThrows()
        {
            var formatter = new NumericFormatter("invalid", UnitsRegistry.Default, "label");

            Assert.That(
                () => formatter.Format(42.0, Units.Length.Meter, Units.Time.Second),
                Throws.InvalidOperationException);
        }

        // ── Culture-specific formatting ─────────────────────────────────────────

        [Test]
        public void FormatWithGermanCultureUsesCommaDecimal()
        {
            var germanCulture = new CultureInfo("de-DE");
            var formatter = new NumericFormatter("german", UnitsRegistry.Default, "label", "F2", germanCulture);

            string result = formatter.Format(1.5);

            // German uses comma as decimal separator
            Assert.That(result, Is.EqualTo("1,50"));
        }

        [Test]
        public void FormatWithInvariantCultureUsesDotDecimal()
        {
            var formatter = new NumericFormatter("invariant", UnitsRegistry.Default, "label", "F2", CultureInfo.InvariantCulture);

            string result = formatter.Format(1.5);

            Assert.That(result, Is.EqualTo("1.50"));
        }

        // ── Interpretation symmetry and failure behavior ───────────────────────

        [Test]
        public void TryInterpretRoundTripsFormattedValue()
        {
            var formatter = new NumericFormatter("roundtrip", UnitsRegistry.Default, "label", "G17", CultureInfo.InvariantCulture);
            double original = 12345.678901234567;

            string text = formatter.Format(original);
            bool success = formatter.TryInterpret(text, out double interpreted);

            Assert.That(success, Is.True);
            Assert.That(interpreted, Is.EqualTo(original));
        }

        [Test]
        public void TryInterpretWithGermanCultureRoundTripsFormattedValue()
        {
            var formatter = new NumericFormatter("german", UnitsRegistry.Default, "label", "F2", new CultureInfo("de-DE"));
            double original = 1234.5;

            string text = formatter.Format(original);
            bool success = formatter.TryInterpret(text, out double interpreted);

            Assert.That(text, Is.EqualTo("1234,50"));
            Assert.That(success, Is.True);
            Assert.That(interpreted, Is.EqualTo(original).Within(1e-12));
        }

        [Test]
        public void TryInterpretReturnsFalseForInvalidInput()
        {
            var formatter = new NumericFormatter("invalid", UnitsRegistry.Default, "label", "G", CultureInfo.InvariantCulture);

            bool success = formatter.TryInterpret("not-a-number", out double interpreted);

            Assert.That(success, Is.False);
            Assert.That(interpreted, Is.EqualTo(0d));
        }

        [Test]
        public void TryInterpretReturnsFalseForNullInput()
        {
            var formatter = new NumericFormatter("invalid", UnitsRegistry.Default, "label", "G", CultureInfo.InvariantCulture);

            bool success = formatter.TryInterpret(null, out double interpreted);

            Assert.That(success, Is.False);
            Assert.That(interpreted, Is.EqualTo(0d));
        }

        [Test]
        public void TryInterpretIsCultureSensitiveForSameText()
        {
            var invariantFormatter = new NumericFormatter("invariant", UnitsRegistry.Default, "label", "F2", CultureInfo.InvariantCulture);
            var germanFormatter = new NumericFormatter("german", UnitsRegistry.Default, "label", "F2", new CultureInfo("de-DE"));

            bool invariantSuccess = invariantFormatter.TryInterpret("1,50", out double invariantValue);
            bool germanSuccess = germanFormatter.TryInterpret("1,50", out double germanValue);

            Assert.That(invariantSuccess, Is.True);
            Assert.That(germanSuccess, Is.True);
            Assert.That(invariantValue, Is.EqualTo(150d));
            Assert.That(germanValue, Is.EqualTo(1.5d).Within(1e-12));
        }
    }
}
