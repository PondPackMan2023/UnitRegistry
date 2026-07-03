using System;
using System.Globalization;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class CurrencyFormatterTests
    {
        [Test]
        public void ExposesIdAndValueType()
        {
            var id = new FormatterId("currency-standard");
            var formatter = new CurrencyFormatter(id, "C2", CultureInfo.GetCultureInfo("en-US"));

            Assert.That(formatter.Id, Is.EqualTo(id));
            Assert.That(formatter.ValueType, Is.EqualTo(typeof(decimal)));
        }

        [Test]
        public void FormatUsesConfiguredCultureAndPattern()
        {
            var formatter = new CurrencyFormatter("currency-standard", "C2", CultureInfo.GetCultureInfo("en-US"));

            var result = formatter.Format(1234.5m);

            Assert.That(result, Is.EqualTo("$1,234.50"));
        }

        [Test]
        public void FormatAllowsFormatProviderOverride()
        {
            var formatter = new CurrencyFormatter("currency-standard", "C2", CultureInfo.GetCultureInfo("en-US"));

            var result = formatter.Format((object)1234.5m, CultureInfo.GetCultureInfo("de-DE"));

            Assert.That(result, Is.EqualTo("1.234,50 €"));
        }

        [Test]
        public void ObjectFormatThrowsForNonDecimalInput()
        {
            var formatter = new CurrencyFormatter("currency-standard", "C2", CultureInfo.GetCultureInfo("en-US"));

            Assert.That(
                () => formatter.Format((object)1234.5d, CultureInfo.InvariantCulture),
                Throws.ArgumentException);
        }
    }
}
