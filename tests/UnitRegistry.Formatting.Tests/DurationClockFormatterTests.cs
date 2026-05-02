using System;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class DurationClockFormatterTests
    {
        [Test]
        public void ExposesIdAndValueType()
        {
            var id = new FormatterId("duration-clock");
            var formatter = new DurationClockFormatter(id);

            Assert.That(formatter.Id, Is.EqualTo(id));
            Assert.That(formatter.ValueType, Is.EqualTo(typeof(TimeSpan)));
        }

        [Test]
        public void FormatsClockStyleDuration()
        {
            var formatter = new DurationClockFormatter("duration-clock");
            var value = new TimeSpan(1, 2, 3);

            string result = formatter.Format(value);

            Assert.That(result, Is.EqualTo("01:02:03"));
        }

        [Test]
        public void FormatsDurationWithHoursBeyondTwentyFour()
        {
            var formatter = new DurationClockFormatter("duration-clock");
            var value = new TimeSpan(1, 3, 15, 0);

            string result = formatter.Format((object)value);

            Assert.That(result, Is.EqualTo("27:15:00"));
        }
    }
}
