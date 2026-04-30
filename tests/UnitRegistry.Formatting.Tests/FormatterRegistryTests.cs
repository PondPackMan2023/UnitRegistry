using System;
using NUnit.Framework;

namespace UnitRegistry.Formatting.Tests
{
    [TestFixture]
    public sealed class FormatterRegistryTests
    {
        [Test]
        public void RegisterThrowsOnDuplicateId()
        {
            var registry = new FormatterRegistry();
            var formatterA = new NumericFormatter("default", UnitsRegistry.Default, "label-a", "F2");
            var formatterB = new NumericFormatter("default", UnitsRegistry.Default, "label-b", "E3");

            registry.Register(formatterA);

            Assert.That(() => registry.Register(formatterB), Throws.InvalidOperationException);
        }

        [Test]
        public void GetReturnsNullForUnknownId()
        {
            var registry = new FormatterRegistry();

            NumericFormatter formatter = registry.Get(new NumericFormatterId("missing"));

            Assert.That(formatter, Is.Null);
        }

        [Test]
        public void ChangeFormatThrowsWhenIdIsNotRegistered()
        {
            var registry = new FormatterRegistry();

            Assert.That(
                () => registry.ChangeFormat(new NumericFormatterId("missing"), "F3"),
                Throws.InvalidOperationException);
        }

        [Test]
        public void ChangeFormatReplacesFormatterInstanceAndPreservesImmutableOriginal()
        {
            var registry = new FormatterRegistry();
            var id = new NumericFormatterId("default");
            var original = new NumericFormatter(id, UnitsRegistry.Default, "default label", "F2");

            registry.Register(original);

            NumericFormatter before = registry.Get(id);
            registry.ChangeFormat(id, "E3");
            NumericFormatter after = registry.Get(id);

            Assert.That(after, Is.Not.SameAs(before));
            Assert.That(after.Id, Is.EqualTo(before.Id));
            Assert.That(after.Label, Is.EqualTo(before.Label));
            Assert.That(after.UnitRegistry, Is.SameAs(before.UnitRegistry));
            Assert.That(after.FormatProvider, Is.SameAs(before.FormatProvider));
            Assert.That(after.FormatSpecifier, Is.EqualTo("E3"));

            Assert.That(before.FormatSpecifier, Is.EqualTo("F2"));
        }
    }
}