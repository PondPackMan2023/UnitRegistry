using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class NumericFormatTests
    {
        [Test]
        public void GeneralReturnsG()
        {
            Assert.That(NumericFormat.General(), Is.EqualTo("G"));
        }

        [Test]
        public void FixedReturnsFWithPrecision()
        {
            Assert.That(NumericFormat.Fixed(2), Is.EqualTo("F2"));
        }

        [Test]
        public void ScientificReturnsEWithPrecision()
        {
            Assert.That(NumericFormat.Scientific(3), Is.EqualTo("E3"));
        }
    }
}