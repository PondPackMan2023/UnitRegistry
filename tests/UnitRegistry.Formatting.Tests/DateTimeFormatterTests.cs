using System;
using System.Globalization;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class DateTimeFormatterTests
    {
        [Test]
        public void ExposesIdAndValueType()
        {
            var id = new FormatterId("date-short");
            var formatter = new DateTimeFormatter(id, "yyyy-MM-dd");

            Assert.That(formatter.Id, Is.EqualTo(id));
            Assert.That(formatter.ValueType, Is.EqualTo(typeof(DateTime)));
        }

        [Test]
        public void FormatUsesConfiguredPattern()
        {
            var formatter = new DateTimeFormatter("date-time", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            var value = new DateTime(2026, 5, 2, 14, 5, 0);

            string result = formatter.Format(value);

            Assert.That(result, Is.EqualTo("2026-05-02 14:05"));
        }

        [Test]
        public void FormatUsesProvidedFormatProviderOverride()
        {
            var formatter = new DateTimeFormatter("month-name", "MMMM", CultureInfo.InvariantCulture);
            var value = new DateTime(2026, 3, 5);

            string result = formatter.Format((object)value, new CultureInfo("de-DE"));

            Assert.That(result, Is.EqualTo("Marz").Or.EqualTo("M\u00E4rz"));
        }

        [Test]
        public void TryParseParsesDateTimeSuccessfully()
        {
            var formatter = new DateTimeFormatter("date-time", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            bool success = formatter.TryParse("2026-05-02 14:05", null, out object value);

            Assert.That(success, Is.True);
            Assert.That(value, Is.TypeOf<DateTime>());
            Assert.That((DateTime)value, Is.EqualTo(new DateTime(2026, 5, 2, 14, 5, 0)));
        }

        [Test]
        public void TryParseRespectsCultureProvider()
        {
            var formatter = new DateTimeFormatter("date", "d", CultureInfo.InvariantCulture);
            var culture = new CultureInfo("de-DE");

            bool success = formatter.TryParse("31.12.2026", culture, out object value);

            Assert.That(success, Is.True);
            Assert.That(value, Is.TypeOf<DateTime>());
            Assert.That(((DateTime)value).Date, Is.EqualTo(new DateTime(2026, 12, 31)));
        }

        [Test]
        public void TryParseReturnsFalseForInvalidInput()
        {
            var formatter = new DateTimeFormatter("date", "d", CultureInfo.InvariantCulture);

            bool success = formatter.TryParse("not-a-date", null, out object value);

            Assert.That(success, Is.False);
            Assert.That(value, Is.Null);
        }
    }
}
