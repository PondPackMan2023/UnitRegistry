# ADR-0001: Establish UnitRegistry as the Foundational Unit and Formatting Library

## Status

Accepted

## Date

2026-04-25

## Context

Engineering applications require a consistent, extensible, and semantically correct way to represent:

- Physical dimensions (e.g., Length, Time)
- Units within those dimensions (e.g., meter, second)
- Unit conversion rules
- Numeric formatting for presentation (precision, culture, display units)

Historically, these concerns were intertwined with UI code and product-specific behavior (e.g., OpenFlows), resulting in:

- Stringly-typed identities
- Enum-based limitations
- Duplication of conversion logic
- Formatting rules leaking into semantic layers
- Difficulty reusing unit and formatting logic across applications

A new approach is required that:

- Separates semantics from presentation
- Avoids product-specific coupling
- Supports long-lived evolution
- Can serve as a stable dependency for higher-level consumers (e.g., engineering graph controls)

## Decision

We establish **UnitRegistry** as a multi-layered foundational library composed of:

1. **UnitRegistry.Core**
2. **UnitRegistry.Formatting**

with clearly defined responsibilities, identity models, and dependency direction.

### 1. UnitRegistry.Core

UnitRegistry.Core is responsible for **unit semantics only**.

It defines:

- **Dimension**
  - Immutable semantic identity (e.g., Length, Time)
  - No behavior beyond identity and equality
  - No enums; extensible by design

- **UnitId**
  - Explicit, immutable identity value object
  - Eliminates string-based unit identity
  - Normalized, value-based equality

- **Unit**
  - Immutable representation of a unit within a single Dimension
  - Conversion defined strictly via canonical base units
  - No formatting or presentation logic
  - Conversion path is always: unit → base → unit

- **UnitRegistry**
  - Authoritative container for Units
  - Enforces invariants:
    - Unique (Dimension, UnitId)
    - Exactly one base unit per Dimension
  - Provides lookup and discovery APIs
  - Exposes a frozen `UnitRegistry.Default` for standard usage
  - Allows explicit, mutable registries for advanced scenarios

UnitRegistry.Core is intentionally free of:

- Numeric formatting
- UI or visualization concerns
- Storage or persistence concepts
- Derived dimensional algebra

### 2. UnitRegistry.Formatting

UnitRegistry.Formatting builds on UnitRegistry.Core and is responsible for **presentation policy only**.

It defines:

- **NumericFormatterId**
  - Explicit identity for formatter configurations
  - Mirrors the UnitId identity pattern
  - Eliminates stringly-typed formatter selection

- **NumericFormatter**
  - Object-based formatting policy
  - Owns a NumericFormatterId
  - Depends explicitly on a UnitRegistry
  - Formats numeric values expressed in a Unit into strings
  - Supports:
    - Numeric format specifiers
    - Precision via standard .NET formatting
    - Culture-aware formatting
    - Optional display-unit overrides

NumericFormatter explicitly does NOT:

- Perform unit semantics or define conversion rules
- Own storage-unit concepts
- Parse string input back into numeric values
- Perform auto-scaling or heuristic unit selection
- Depend on UI frameworks

All conversion logic remains delegated to Unit.

## Rationale

This design intentionally separates **what values mean** from **how they are displayed**.

Key principles driving this decision:

- **Explicit identity over primitives**  
  Introduce UnitId and NumericFormatterId to eliminate error-prone string usage and improve API discoverability.

- **Single responsibility per layer**  
  Semantics (Core) and presentation (Formatting) evolve independently.

- **Extensibility without closed sets**  
  Avoid enums and global registries that restrict domain growth.

- **Visibility of invariants**  
  Canonical base-unit conversion is always explicit and enforced.

- **Consumer-driven validation**  
  Higher-level consumers (e.g., EngineeringGraphControl) can exercise the APIs without driving semantic compromises.

## Consequences

### Positive

- Clear layering and dependency direction
- Reusable unit and formatting logic across products
- Strong invariants enforced centrally
- Safer, more discoverable APIs
- Easier migration away from legacy formatting approaches

### Trade-offs

- Slightly more explicit code at call sites (e.g., visible base conversions)
- Deferred convenience abstractions until real usage pressure exists
- Formatting features such as parsing and auto-scaling intentionally postponed

These trade-offs are accepted to preserve long-term design clarity.

## Follow-up

- NumericFormatter parsing support may be introduced in a future ADR if needed.
- EngineeringGraphControl will consume UnitRegistry as a proving ground for ergonomics.
- Once APIs stabilize, UnitRegistry will be distributed as a NuGet package rather than consumed via source integration.

---

**This ADR intentionally documents the foundational posture of UnitRegistry and will serve as a reference point for all future architectural decisions involving units and formatting.**