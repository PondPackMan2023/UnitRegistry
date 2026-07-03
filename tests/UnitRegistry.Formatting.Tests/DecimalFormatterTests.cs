using System;
using System.Globalization;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class DecimalFormatterTests
    {
        [Test]
        public void ExposesIdAndValueType()
        {
            var id = new FormatterId("decimal-fixed");
            var formatter = new DecimalFormatter(id, "F2", CultureInfo.InvariantCulture);

            Assert.That(formatter.Id, Is.EqualTo(id));
            Assert.That(formatter.ValueType, Is.EqualTo(typeof(decimal)));
        }

        [Test]
        public void FormatUsesConfiguredPattern()
        {
            var formatter = new DecimalFormatter("decimal-fixed", "F2", CultureInfo.InvariantCulture);

            var result = formatter.Format(1234.5m);

            Assert.That(result, Is.EqualTo("1234.50"));
        }

        [Test]
        public void FormatUsesProvidedFormatProviderOverride()
        {
            var formatter = new DecimalFormatter("decimal-fixed", "N2", CultureInfo.InvariantCulture);

            var result = formatter.Format((object)1234.5m, new CultureInfo("de-DE"));

            Assert.That(result, Is.EqualTo("1.234,50"));
        }

        [Test]
        public void ObjectFormatThrowsForNonDecimalInput()
        {
            var formatter = new DecimalFormatter("decimal-fixed", "F2", CultureInfo.InvariantCulture);

            Assert.That(
                () => formatter.Format((object)1234.5d, CultureInfo.InvariantCulture),
                Throws.ArgumentException);
        }
    }
}
