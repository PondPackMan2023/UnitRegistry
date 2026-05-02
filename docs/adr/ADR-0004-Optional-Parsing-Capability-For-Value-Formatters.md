# ADR-0004: Optional Parsing Capability for Value Formatters

## Status
Proposed

## Context

UnitRegistry currently defines a formatting abstraction via `IValueFormatter`, introduced in ADR-0003. That interface supports converting strongly-typed values into display strings, but it does not address the inverse operation: interpreting user-entered text back into strongly-typed values.

A concrete need for parsing arises in UI scenarios such as **EngineeringGraphControl options dialogs**, where users specify minimum, maximum, and increment values for axes. In these cases:

- The formatter driving display is already known
- User input must be validated and converted back to the formatter’s value domain
- Different formatter types have different, domain-specific parsing semantics

Existing precedent exists in `NumericFormatter.TryInterpret`, which parses numeric input in a unit- and culture-aware manner. However, extending parsing directly into `IValueFormatter` would conflate responsibilities and force unsupported semantics on formatters that cannot or should not parse.

Additionally, UnitRegistry targets `netstandard2.0`, which does not support nullable reference syntax. Any new APIs must therefore avoid nullable annotations and instead use optional parameters with default `null` values where appropriate.

---

## Decision

### 1. Introduce a Separate Parsing Capability Interface

A new interface is introduced to represent optional parsing support:

```csharp
public interface IValueParser
{
    Type ValueType { get; }

    bool TryParse(
        string text,
        IFormatProvider formatProvider = null,
        out object value);
}
```

Key characteristics:

- Parsing is an **opt-in capability**, not a universal requirement
- Formatting and parsing responsibilities remain explicitly separated
- The interface is non-generic and UI-friendly
- The `IFormatProvider` parameter is optional to maintain compatibility with `netstandard2.0`

---

### 2. Relationship to IValueFormatter

- `IValueFormatter` remains unchanged and formatting-only
- Formatter implementations may implement `IValueParser` when parsing is meaningful and well-defined
- Consumers (such as UI controls) must explicitly check for parsing support

This avoids symmetry-based design and prevents forcing ambiguous or unsupported parsing behavior onto formatters.

---

### 3. Intended Implementations

The following guidance applies:

- **NumericFormatter**
  - Continues to support parsing (existing behavior)
  - May be aligned with `IValueParser` via implementation or adapter

- **DateTimeFormatter**
  - Expected to implement `IValueParser`
  - Parsing uses standard .NET `DateTime` parsing rules
  - Respects the provided `IFormatProvider`
  - No time zone inference or policy-based guessing

- **DurationClockFormatter**
  - May implement `IValueParser` to support clock-style duration input
  - Parsing grammar must be explicit (e.g. `SS`, `MM:SS`, `HH:MM:SS`, `D:HH:MM:SS`)
  - Parsing failures must be explicit (no silent reinterpretation)
  - Produces `TimeSpan` values

No formatter is required to implement parsing unless there is a concrete, supported use case.

---

## Consequences

### Positive

- Enables generic, formatter-driven UI parsing
- Preserves separation of concerns between formatting and parsing
- Avoids premature or speculative parsing requirements
- Supports `netstandard2.0` constraints cleanly
- Aligns with existing NumericFormatter behavior without forcing symmetry

### Negative

- Introduces an additional interface
- Requires consumers to explicitly check for parsing support

These costs are intentional and preferable to implicit or ambiguous parsing semantics.

---

## Summary

Parsing support in UnitRegistry is introduced as an **explicit, optional capability** via `IValueParser`, rather than being embedded into `IValueFormatter`.

This design enables advanced UI scenarios (such as EngineeringGraphControl axis configuration) while preserving architectural clarity, correctness, and long-term extensibility.
