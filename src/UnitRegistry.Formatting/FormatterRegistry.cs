using System;
using System.Collections.Generic;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Explicit registry for managing numeric formatter instances by identifier.
    /// </summary>
    public sealed class FormatterRegistry
    {
        private readonly Dictionary<NumericFormatterId, NumericFormatter> _formatters =
            new Dictionary<NumericFormatterId, NumericFormatter>();

        /// <summary>
        /// Registers a formatter by its identifier.
        /// </summary>
        /// <param name="formatter">Formatter instance to register.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="formatter"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when a formatter with the same id is already registered.</exception>
        public void Register(NumericFormatter formatter)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            if (_formatters.ContainsKey(formatter.Id))
            {
                throw new InvalidOperationException(
                    "A formatter with the same id is already registered.");
            }

            _formatters.Add(formatter.Id, formatter);
        }

        /// <summary>
        /// Gets a formatter by identifier.
        /// </summary>
        /// <param name="id">Formatter identifier.</param>
        /// <returns>The formatter if found; otherwise null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
        public NumericFormatter Get(NumericFormatterId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            NumericFormatter formatter;
            return _formatters.TryGetValue(id, out formatter)
                ? formatter
                : null;
        }

        /// <summary>
        /// Replaces the format specifier for an existing formatter entry.
        /// </summary>
        /// <param name="id">Formatter identifier.</param>
        /// <param name="formatSpecifier">New numeric format specifier.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the formatter identifier is not registered.</exception>
        public void ChangeFormat(NumericFormatterId id, string formatSpecifier)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            NumericFormatter current;
            if (!_formatters.TryGetValue(id, out current))
            {
                throw new InvalidOperationException(
                    "Cannot change format for an unregistered formatter id.");
            }

            var replacement = new NumericFormatter(
                current.Id,
                current.UnitRegistry,
                current.Label,
                formatSpecifier,
                current.FormatProvider);

            _formatters[id] = replacement;
        }
    }
}