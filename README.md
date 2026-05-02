# UnitRegistry

**April 2026**

UnitRegistry is a lightweight, domain-agnostic .NET library for managing physical **units**, **dimensions**, **unit conversion semantics**, and **numeric formatting policy** in engineering software.

It is designed as a **layered, foundational library** that cleanly separates:
- **What values mean** (unit semantics)
- **How values are displayed** (numeric formatting and presentation)

This separation allows UnitRegistry to serve as a long-lived dependency for engineering applications without introducing UI coupling or product-specific assumptions.

---

## Design Goals

UnitRegistry is designed to:

- Treat **units and dimensions as first-class semantic concepts**
- Provide **deterministic, mathematically correct unit conversions**
- Support **explicit identity models** instead of enums or strings
- Allow **extensibility** for custom units, dimensions, and domains
- Cleanly separate **semantics** from **presentation policy**
- Remain **low-level, reusable, and UI-agnostic**

The library explicitly avoids mixing semantic meaning with formatting or application workflow logic.

---

## Architecture Overview

UnitRegistry is composed of two primary layers with a strict dependency direction:

```
UnitRegistry.Core        (unit semantics)
        ↑
UnitRegistry.Formatting  (presentation policy)
```

Higher-level applications and libraries build on these layers as needed.

---

## UnitRegistry.Core

`UnitRegistry.Core` is responsible for **unit semantics only**.

It provides:

- **Dimensions**
  - Immutable semantic identities (e.g., Length, Time, Pressure)
  - No derived algebra or equations

- **UnitId**
  - Explicit, immutable identity value object
  - Eliminates stringly-typed unit identification

- **Unit**
  - Immutable representation of a unit within a single dimension
  - Conversion defined strictly via canonical base units
  - Conversion path is always: `source → base → target`

- **UnitRegistry**
  - Authoritative container for known units
  - Enforces invariants:
    - Unique `(Dimension, UnitId)` pairs
    - Exactly one base unit per dimension
  - Provides lookup and discovery APIs
  - Ships with a frozen default registry for standard usage

### What Core Does *Not* Provide

- Numeric formatting or presentation policy
- UI or visualization concerns
- Domain-specific workflows
- Storage or persistence concepts
- Parsing of formatted values

`UnitRegistry.Core` is intentionally small, explicit, and semantically strict.

---

## UnitRegistry.Formatting

`UnitRegistry.Formatting` builds **on top of UnitRegistry.Core** and is responsible for **presentation policy only**.

It provides:

- **FormatterId**
  - Explicit identity for formatter configurations
  - Mirrors the `UnitId` identity model

- **NumericFormatter**
  - Object-based numeric formatting policy
  - Depends explicitly on a `UnitRegistry`
  - Formats numeric values expressed in a `Unit` into strings

Supported formatting concerns include:

- Standard .NET numeric format strings
- Precision control
- Culture-aware formatting
- Optional display-unit overrides

### What Formatting Does *Not* Provide

- Unit semantics or conversion rules
- Storage-unit concepts
- Parsing strings back into numeric values
- Auto-scaling or heuristic unit selection
- Dependencies on UI frameworks

All semantic conversion logic remains owned by `Unit` in `UnitRegistry.Core`.

---

## Intended Use Cases

UnitRegistry is well suited for:

- Engineering modeling and simulation software
- Technical desktop and web applications
- Engineering graphing and visualization controls
- Shared infrastructure libraries
- Long-lived domain-specific engineering tools

It is particularly appropriate when **semantic correctness, clarity, and architectural separation** matter more than convenience shortcuts.

---

## Target Framework & Compatibility

- Target framework: **netstandard2.0**
- No platform-specific dependencies
- Compatible with:
  - .NET Framework
  - .NET Core
  - Modern .NET runtimes

The library is safe to consume from UI frameworks, services, and shared libraries.

---

## Design Documentation

Architectural intent, non-goals, and layering decisions are documented under:

```
docs/design/
```

These documents exist to prevent scope creep and preserve long-term design clarity.

---

## Licensing

UnitRegistry is released under the **MIT License**.

Units, dimensions, and conversion mathematics represent real-world facts and established definitions. This library provides an original, independent implementation that expresses those facts in a reusable and open form.

---

## Status

UnitRegistry represents a **foundational semantic and formatting layer**.

Development is intentionally incremental and focused on:
- Correctness
- Explicitness
- API stability
- Long-term maintainability
