using System;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Represents the stable identity of a numeric formatter.
    /// </summary>
    public sealed class FormatterId : IEquatable<FormatterId>
    {
        /// <summary>
        /// Gets the normalized identity value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormatterId"/> class.
        /// </summary>
        /// <param name="value">Stable identity value for the formatter.</param>
        public FormatterId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            string normalizedValue = value.Trim();
            if (normalizedValue.Length == 0)
            {
                throw new ArgumentException("Formatter identifier must not be empty or whitespace.", nameof(value));
            }

            Value = normalizedValue;
        }

        public bool Equals(FormatterId other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Value, other.Value, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as FormatterId);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }

        public override string ToString()
        {
            return Value;
        }

        public static bool operator ==(FormatterId left, FormatterId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FormatterId left, FormatterId right)
        {
            return !Equals(left, right);
        }
    }
}
