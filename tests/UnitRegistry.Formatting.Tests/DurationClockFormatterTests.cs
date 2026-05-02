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

        [Test]
        public void TryParseParsesSupportedClockForms()
        {
            var formatter = new DurationClockFormatter("duration-clock");

            bool secondsOk = formatter.TryParse("45", null, out object secondsValue);
            bool minuteSecondOk = formatter.TryParse("2:30", null, out object minuteSecondValue);
            bool hourMinuteSecondOk = formatter.TryParse("01:15:00", null, out object hourMinuteSecondValue);
            bool dayHourMinuteSecondOk = formatter.TryParse("1:02:03:04", null, out object dayHourMinuteSecondValue);

            Assert.That(secondsOk, Is.True);
            Assert.That(secondsValue, Is.EqualTo((object)TimeSpan.FromSeconds(45)));

            Assert.That(minuteSecondOk, Is.True);
            Assert.That(minuteSecondValue, Is.EqualTo((object)new TimeSpan(0, 2, 30)));

            Assert.That(hourMinuteSecondOk, Is.True);
            Assert.That(hourMinuteSecondValue, Is.EqualTo((object)new TimeSpan(1, 15, 0)));

            Assert.That(dayHourMinuteSecondOk, Is.True);
            Assert.That(dayHourMinuteSecondValue, Is.EqualTo((object)new TimeSpan(1, 2, 3, 4)));
        }

        [Test]
        public void TryParseReturnsFalseForInvalidClockText()
        {
            var formatter = new DurationClockFormatter("duration-clock");

            bool nonNumeric = formatter.TryParse("aa:bb", null, out object nonNumericValue);
            bool tooManyTokens = formatter.TryParse("1:2:3:4:5", null, out object tooManyTokensValue);
            bool negative = formatter.TryParse("-1:10", null, out object negativeValue);
            bool outOfRangeSeconds = formatter.TryParse("1:70", null, out object outOfRangeSecondsValue);
            bool outOfRangeDayHour = formatter.TryParse("1:24:00:00", null, out object outOfRangeDayHourValue);
            bool incomplete = formatter.TryParse("1:", null, out object incompleteValue);

            Assert.That(nonNumeric, Is.False);
            Assert.That(nonNumericValue, Is.Null);

            Assert.That(tooManyTokens, Is.False);
            Assert.That(tooManyTokensValue, Is.Null);

            Assert.That(negative, Is.False);
            Assert.That(negativeValue, Is.Null);

            Assert.That(outOfRangeSeconds, Is.False);
            Assert.That(outOfRangeSecondsValue, Is.Null);

            Assert.That(outOfRangeDayHour, Is.False);
            Assert.That(outOfRangeDayHourValue, Is.Null);

            Assert.That(incomplete, Is.False);
            Assert.That(incompleteValue, Is.Null);
        }
    }
}
