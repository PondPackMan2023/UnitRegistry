using System;

namespace UnitRegistry
{
    /// <summary>
    /// Represents the physical nature of a quantity (for example, Length or Time).
    /// </summary>
    public sealed class Dimension : IEquatable<Dimension>
    {
        /// <summary>
        /// Gets the stable identity key for this dimension.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dimension"/> class.
        /// </summary>
        /// <param name="key">Stable identity key for the dimension.</param>
        public Dimension(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Dimension key must not be null, empty, or whitespace.", nameof(key));
            }

            Key = key;
        }

        public bool Equals(Dimension other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Key, other.Key, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Dimension);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Key);
        }

        public override string ToString()
        {
            return Key;
        }

        public static bool operator ==(Dimension left, Dimension right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Dimension left, Dimension right)
        {
            return !Equals(left, right);
        }
    }
}
