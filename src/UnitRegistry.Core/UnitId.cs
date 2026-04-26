using System;

namespace UnitRegistry
{
    /// <summary>
    /// Represents the stable identity of a unit.
    /// </summary>
    public sealed class UnitId : IEquatable<UnitId>
    {
        /// <summary>
        /// Gets the normalized identity value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitId"/> class.
        /// </summary>
        /// <param name="value">Stable identity value for the unit.</param>
        public UnitId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            string normalizedValue = value.Trim();
            if (normalizedValue.Length == 0)
            {
                throw new ArgumentException("Unit identifier must not be empty or whitespace.", nameof(value));
            }

            Value = normalizedValue;
        }

        public bool Equals(UnitId other)
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
            return Equals(obj as UnitId);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }

        public override string ToString()
        {
            return Value;
        }

        public static bool operator ==(UnitId left, UnitId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnitId left, UnitId right)
        {
            return !Equals(left, right);
        }
    }
}