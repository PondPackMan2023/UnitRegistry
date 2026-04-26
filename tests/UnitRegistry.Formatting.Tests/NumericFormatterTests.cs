using System;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class NumericFormatterTests
    {
        [Test]
        public void FormatterOwnsBothIdAndRegistry()
        {
            var id = new NumericFormatterId("default");
            var registry = UnitRegistry.Default;

            var formatter = new NumericFormatter(id, registry);

            Assert.That(formatter.Id, Is.EqualTo(id));
            Assert.That(formatter.UnitRegistry, Is.SameAs(registry));
        }

        [Test]
        public void FormatterCanConstructFromString()
        {
            var registry = UnitRegistry.Default;

            var formatter = new NumericFormatter("default", registry);

            Assert.That(formatter.Id, Is.EqualTo(new NumericFormatterId("default")));
            Assert.That(formatter.UnitRegistry, Is.SameAs(registry));
        }

        [Test]
        public void FormatterIdentityIsDiscoverable()
        {
            var id = new NumericFormatterId("compact");
            var formatter = new NumericFormatter(id, UnitRegistry.Default);

            Assert.That(formatter.Id.Value, Is.EqualTo("compact"));
        }

        [Test]
        public void NullIdThrows()
        {
            Assert.That(
                () => new NumericFormatter((NumericFormatterId)null, UnitRegistry.Default),
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
                () => new NumericFormatter((string)null, UnitRegistry.Default),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ToStringReturnsFormatterId()
        {
            var formatter = new NumericFormatter("default", UnitRegistry.Default);

            Assert.That(formatter.ToString(), Is.EqualTo("default"));
        }
    }
}
