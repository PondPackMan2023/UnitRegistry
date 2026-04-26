# Copilot Instructions – UnitRegistry

## Project Overview

UnitRegistry is a foundational, domain-agnostic library for defining physical
dimensions, units, and unit conversion semantics for engineering software.

The goal of this repository is to provide **semantic correctness and extensibility**
without imposing formatting, UI, or application-specific assumptions.

---

## Repository Structure

- `src/`
  - `UnitRegistry.Core`
    - Target framework: **netstandard2.0**
    - Must remain compatible with legacy .NET (e.g., net48)
    - Use only APIs available to netstandard2.0

- `tests/`
  - `UnitRegistry.Core.Tests`
    - Target framework: **net10.0**
    - Uses the latest stable NUnit
    - Tests may use modern .NET features

Do not introduce additional projects unless explicitly requested.

---

## Layering and Scope (Important)

### UnitRegistry.Core
UnitRegistry.Core is intentionally **semantic-only**.

It may include:
- Dimension identity
- Unit identity
- Canonical base units
- Deterministic unit conversion
- Explicit registration and extensibility mechanisms

It must NOT include:
- Numeric formatting
- Display units
- Precision rules
- Localization
- UI or rendering concepts
- Enums for extensible concepts

### Formatting and Display
Formatting concerns (e.g., numeric formatting, precision, symbols, display units)
are intentionally out of scope for Core.

A future layered component (e.g., `UnitRegistry.Formatting`) is expected to build
on top of Core, but is **not implemented yet**.

Design Core so that formatting layers can be added later without refactoring.

---

## Design Principles

- Prefer **explicit identity objects** over enums or switch logic
- Avoid static global registries
- Keep APIs conservative and low-level
- Optimize for correctness, clarity, and long-term stability
- Do not assume closed sets of dimensions or units

Extensibility is a first-class requirement.

---

## Current Implementation Focus

Initial work should focus on:
- Dimension identity
  - Start with **Length** and **Time**
- Data-driven unit definitions (not class-per-unit)
- Canonical base units per dimension
- Correctness-first unit conversion
- Tests that validate identity, equality, and conversion behavior

Derived dimensions, formatting, and higher-level abstractions are intentionally deferred.

---

## Non-Goals (For Now)

- Numeric formatting or presentation policy
- Derived dimensions (velocity, area, pressure, etc.)
- UI or visualization support
- Localization or symbol rendering
- Application- or product-specific behavior

Keep the core implementation boring, predictable, and easy to reason about.