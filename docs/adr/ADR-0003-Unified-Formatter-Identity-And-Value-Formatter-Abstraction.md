# ADR-0003: Unified Formatter Identity and Value Formatter Abstraction

## Status
Accepted

## Context

UnitRegistry originally defined **NumericFormatter** and a formatter identity type to support formatting of numeric quantities with units. As the system evolves, additional formatting scenarios are required:

- Formatting of absolute calendar values (`DateTime`, `DateTimeOffset`)
- Formatting of duration-like values using clock-style representations (e.g. `HH:mm:ss`)

Early designs in related products (e.g. OpenRoads / OpenFlows) achieved this by inheriting date/time formatters from numeric formatters. That approach introduced semantic ambiguity and unnecessary coupling.

Because UnitRegistry is still early in its lifecycle, this ADR captures a cleaner abstraction that preserves simplicity (K.I.S.) while enabling future extensibility.

---

## Decision

### 1. Rename the formatter identity type to `FormatterId`

The original formatter identity name was historically numeric-specific, but semantically represents **formatting intent**, not numeric-only behavior. Renaming it to `FormatterId` clarifies its role and allows it to unify all formatter types.

- `FormatterId` uniquely identifies *how* a value is formatted
- It is independent of the underlying value type

This rename is explicitly allowed due to UnitRegistry's early stage.

---

### 2. Introduce a Common Formatter Interface

A single, non-generic interface is introduced:

```csharp
public interface IValueFormatter
{
    FormatterId FormatterId { get; }
    Type ValueType { get; }
    string Format(object value, IFormatProvider? formatProvider = null);
}
```

Design goals:
- Express *capability*, not implementation
- Avoid inheritance and generics
- Support polymorphic consumption
- Keep formatter implementations immutable

---

### 3. Formatter Types

Each formatter implements `IValueFormatter` directly and declares its value domain explicitly.

#### NumericFormatter

- Formats `double`
- Continues to handle units and numeric format rules
- Remains immutable and numeric-only

#### DateTimeFormatter

- Formats `DateTime` (and optionally `DateTimeOffset`)
- Supports calendar-based formats such as:
  - Short Time
  - Long Time
  - Short Date
  - Short Date & Time
  - Universal Sortable Date & Time

#### DurationClockFormatter

- Formats `TimeSpan`
- Used for clock-style elapsed formatting (e.g. `HH:mm:ss`)
- No calendar semantics

---

### 4. Formatter Registry

The existing `FormatterRegistry`:

- Remains numeric-only
- Continues to store and manage `NumericFormatter` instances
- Is **not** generalized to store all `IValueFormatter` implementations

Commonality is provided by the interface, not by shared storage.

---

## Consequences

### Positive

- Clear semantic boundaries between numeric, date/time, and duration formatting
- Avoids inheritance-based design debt
- Minimal surface area and cognitive overhead
- Aligns with UnitRegistry design principles
- Enables future formatter types without rework

### Negative

- Requires renaming an existing public identifier to `FormatterId`
- Call sites must select appropriate formatter types explicitly

---

## Summary

Formatter identity and formatter behavior are now cleanly separated:

- `FormatterId` identifies *formatting intent*
- Formatter implementations define *value semantics*
- `IValueFormatter` provides uniform consumption without coupling

This approach preserves K.I.S. while avoiding the architectural compromises seen in legacy systems.
