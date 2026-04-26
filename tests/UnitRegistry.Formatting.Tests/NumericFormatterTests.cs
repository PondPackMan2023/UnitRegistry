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

            var formatter = new NumericFormatter(id, registry);

            Assert.That(formatter.Id, Is.EqualTo(id));
            Assert.That(formatter.UnitRegistry, Is.SameAs(registry));
        }

        [Test]
        public void FormatterCanConstructFromString()
        {
            var registry = UnitsRegistry.Default;

            var formatter = new NumericFormatter("default", registry);

            Assert.That(formatter.Id, Is.EqualTo(new NumericFormatterId("default")));
            Assert.That(formatter.UnitRegistry, Is.SameAs(registry));
        }

        [Test]
        public void FormatterIdentityIsDiscoverable()
        {
            var id = new NumericFormatterId("compact");
            var formatter = new NumericFormatter(id, UnitsRegistry.Default);

            Assert.That(formatter.Id.Value, Is.EqualTo("compact"));
        }

        [Test]
        public void NullIdThrows()
        {
            Assert.That(
                () => new NumericFormatter((NumericFormatterId)null, UnitsRegistry.Default),
                Throws.ArgumentNullException);
        }

        [Test]
        public void NullRegistryThrows()
        {
            Assert.That(
                () => new NumericFormatter(new NumericFormatterId("default"), null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void NullStringIdThrows()
        {
            Assert.That(
                () => new NumericFormatter((string)null, UnitsRegistry.Default),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ToStringReturnsFormatterId()
        {
            var formatter = new NumericFormatter("default", UnitsRegistry.Default);

            Assert.That(formatter.ToString(), Is.EqualTo("default"));
        }

        // ── Format specifier and provider ───────────────────────────────────────

        [Test]
        public void DefaultFormatSpecifierIsG()
        {
            var formatter = new NumericFormatter("default", UnitsRegistry.Default);

            Assert.That(formatter.FormatSpecifier, Is.EqualTo("G"));
        }

        [Test]
        public void CustomFormatSpecifierIsRespected()
        {
            var formatter = new NumericFormatter("fixed", UnitsRegistry.Default, "F2");

            Assert.That(formatter.FormatSpecifier, Is.EqualTo("F2"));
        }

        [Test]
        public void NullOrWhitespaceFormatSpecifierThrows()
        {
            Assert.That(
                () => new NumericFormatter("test", UnitsRegistry.Default, null),
                Throws.ArgumentException);
            Assert.That(
                () => new NumericFormatter("test", UnitsRegistry.Default, ""),
                Throws.ArgumentException);
            Assert.That(
                () => new NumericFormatter("test", UnitsRegistry.Default, "   "),
                Throws.ArgumentException);
        }

        [Test]
        public void FormatProviderDefaultsToNull()
        {
            var formatter = new NumericFormatter("default", UnitsRegistry.Default);

            Assert.That(formatter.FormatProvider, Is.Null);
        }

        [Test]
        public void CustomFormatProviderIsStored()
        {
            var culture = new CultureInfo("de-DE");
            var formatter = new NumericFormatter("german", UnitsRegistry.Default, "F2", culture);

            Assert.That(formatter.FormatProvider, Is.SameAs(culture));
        }

        // ── Format with source unit only ────────────────────────────────────────

        [Test]
        public void FormatWithSourceUnitAppliesFormatSpecifier()
        {
            var formatter = new NumericFormatter("fixed", UnitsRegistry.Default, "F2");
            double value = 1.23456;

            string result = formatter.Format(value, Units.Length.Meter);

            Assert.That(result, Is.EqualTo("1.23"));
        }

        [Test]
        public void FormatWithSourceUnitGeneralFormat()
        {
            var formatter = new NumericFormatter("general", UnitsRegistry.Default, "G");
            double value = 123.456;

            string result = formatter.Format(value, Units.Length.Meter);

            Assert.That(result, Is.EqualTo("123.456"));
        }

        [Test]
        public void FormatWithSourceUnitScientific()
        {
            var formatter = new NumericFormatter("scientific", UnitsRegistry.Default, "E2");
            double value = 1234.5;

            string result = formatter.Format(value, Units.Time.Second);

            Assert.That(result, Is.EqualTo("1.23E+003"));
        }

        [Test]
        public void FormatWithSourceUnitNullThrows()
        {
            var formatter = new NumericFormatter("test", UnitsRegistry.Default);

            Assert.That(
                () => formatter.Format(42.0, null),
                Throws.ArgumentNullException);
        }

        // ── Format with display unit conversion ─────────────────────────────────

        [Test]
        public void FormatWithDisplayUnitConvertsCorrectly()
        {
            var formatter = new NumericFormatter("foot", UnitsRegistry.Default, "F4");

            // 1 meter = 3.28084 feet
            string result = formatter.Format(1.0, Units.Length.Meter, Units.Length.Foot);

            Assert.That(result, Is.EqualTo("3.2808"));
        }

        [Test]
        public void FormatWithDisplayUnitRoundTrips()
        {
            var formatter = new NumericFormatter("roundtrip", UnitsRegistry.Default, "F6");

            // Convert to mm and back
            string result = formatter.Format(123.456, Units.Length.Meter, Units.Length.Millimeter);

            // 123.456 m = 123456 mm
            Assert.That(result, Is.EqualTo("123456.000000"));
        }

        [Test]
        public void FormatWithTimeUnitConversion()
        {
            var formatter = new NumericFormatter("hours", UnitsRegistry.Default, "F2");

            // 1 hour = 3600 seconds
            string result = formatter.Format(3600.0, Units.Time.Second, Units.Time.Hour);

            Assert.That(result, Is.EqualTo("1.00"));
        }

        [Test]
        public void FormatWithDisplayUnitNullSourceThrows()
        {
            var formatter = new NumericFormatter("test", UnitsRegistry.Default);

            Assert.That(
                () => formatter.Format(42.0, null, Units.Length.Foot),
                Throws.ArgumentNullException);
        }

        [Test]
        public void FormatWithDisplayUnitNullDisplayThrows()
        {
            var formatter = new NumericFormatter("test", UnitsRegistry.Default);

            Assert.That(
                () => formatter.Format(42.0, Units.Length.Meter, null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void FormatWithCrossDimensionUnitsThrows()
        {
            var formatter = new NumericFormatter("invalid", UnitsRegistry.Default);

            Assert.That(
                () => formatter.Format(42.0, Units.Length.Meter, Units.Time.Second),
                Throws.InvalidOperationException);
        }

        // ── Culture-specific formatting ─────────────────────────────────────────

        [Test]
        public void FormatWithGermanCultureUsesCommaDecimal()
        {
            var germanCulture = new CultureInfo("de-DE");
            var formatter = new NumericFormatter("german", UnitsRegistry.Default, "F2", germanCulture);

            string result = formatter.Format(1.5, Units.Length.Meter);

            // German uses comma as decimal separator
            Assert.That(result, Is.EqualTo("1,50"));
        }

        [Test]
        public void FormatWithInvariantCultureUsesDotDecimal()
        {
            var formatter = new NumericFormatter(
                "invariant",
                UnitsRegistry.Default,
                "F2",
                CultureInfo.InvariantCulture);

            string result = formatter.Format(1.5, Units.Length.Meter);

            Assert.That(result, Is.EqualTo("1.50"));
        }
    }
}
