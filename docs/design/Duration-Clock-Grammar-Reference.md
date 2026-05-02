# Duration Clock Grammar Reference

## Purpose

This document defines the **explicit, supported grammar** for parsing clock-style duration values in UnitRegistry, as implemented by `DurationClockFormatter` when parsing support is enabled.

This document is **reference-only** and contains **no code**. It is intended to support consistent implementation, testing, and UI documentation.

---

## Value Domain

- Parsed values represent **durations**, not dates
- All successful parses produce a `TimeSpan` value
- No calendar semantics are applied

---

## Supported Grammar

Clock-style durations use **colon-separated numeric tokens** interpreted positionally from right to left.

The following forms are supported:

| Input Form | Interpretation |
|-----------|----------------|
| `SS` | Seconds |
| `MM:SS` | Minutes, Seconds |
| `HH:MM:SS` | Hours, Minutes, Seconds |
| `D:HH:MM:SS` | Days, Hours, Minutes, Seconds |

### Examples

- `45` → 45 seconds
- `2:30` → 2 minutes, 30 seconds
- `01:15:00` → 1 hour, 15 minutes
- `1:02:03:04` → 1 day, 2 hours, 3 minutes, 4 seconds

---

## Parsing Rules

- Tokens are parsed **positionally**, not by magnitude
- Numeric parsing is culture-aware via `IFormatProvider`
- Fractional values are not supported
- Negative values are not supported
- Leading and trailing whitespace is ignored

---

## Failure Conditions

Parsing must fail if:

- The token count is zero or greater than four
- Any token is non-numeric
- Any token is negative
- The format is ambiguous or incomplete

Parsing failures must be **explicit** (no silent reinterpretation or fallback).

---

## Design Notes

This grammar intentionally avoids:

- Guessing unit intent
- Abbreviated or free-form input
- Date/time representations

By keeping the grammar explicit and well-defined, duration parsing remains predictable, testable, and safe for use in UI scenarios.
