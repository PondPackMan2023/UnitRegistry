# UnitRegistry – Design Overview

## Purpose

`UnitRegistry` is a proposed open‑source, engineering‑oriented unit management library intended to provide a **generic, extensible, and legally unencumbered** foundation for working with physical units, dimensions, and numeric formatting in software systems.

The primary motivation is to decouple **unit semantics** from:
- domain‑specific products,
- UI or rendering frameworks,
- proprietary infrastructure,

while preserving the rigor and predictability required by engineering software.

This repository intentionally focuses on *what units are* and *how they relate*, not on visualization, equations, or application logic.

---

## Scope and Intent

`UnitRegistry` is intentionally **small, explicit, and semantic**.

It is designed to answer questions such as:
- *What unit does this value represent?*
- *How does this unit convert to a canonical base unit?*
- *How should this unit be identified and displayed?*
- *How can new units be introduced safely and predictably?*

It is **not** designed to:
- perform physics or dimensional algebra,
- evaluate formulas,
- provide charting or UI components,
- make domain‑specific assumptions.

---

## Core Concepts

### Dimensions

A **Dimension** represents the physical nature of a quantity.

Examples:
- Length
- Time
- Pressure
- Velocity
- Area

Dimensions are:
- semantic identifiers,
- stable and identity‑based,
- free of numeric values or units.

---

### Units

A **Unit** represents a specific measurement unit within a single Dimension.

Examples:
- Meter, Foot, Millimeter (Length)
- Second, Minute, Hour (Time)
- Pascal, psi (Pressure)

Units define:
- a unique identity,
- a conversion relationship to a canonical base unit,
- display metadata (name, abbreviation, symbol),
- no UI or formatting policy.

Units do **not**:
- own values,
- perform calculations beyond conversion,
- encode business rules.

---

### Unit Registry

The **Unit Registry** is the central abstraction of the library.

Its role is to:
- manage known units,
- provide lookup by identity or key,
- allow controlled registration of new units,
- remain deterministic and replaceable.

Registries are expected to be:
- immutable after construction, or
- explicitly versioned when extended.

Global static state is intentionally avoided.

---

### Numeric Formatting (Out of Core Scope, By Design)

While `UnitRegistry` supports units and dimensions, it does **not** dictate numeric formatting.

However, it is designed to work naturally with an external `NumericFormatter` concept that:
- combines a numeric value and a display unit,
- controls precision and presentation,
- remains identity‑stable and mutable,
- participates in semantic change notification.

This separation ensures that:
- units remain factual and generic,
- formatting remains flexible and application‑specific.

---

## Extensibility

`UnitRegistry` is designed to be extended without modification of core code.

Extension scenarios include:
- introducing new domains (e.g., acoustics, energy, chemistry),
- adding custom units within existing dimensions,
- replacing the entire registry with a domain‑specific variant.

Extensibility is achieved by:
- explicit registration APIs,
- stable dimension and unit identities,
- avoidance of enums or compile‑time tables.

---

## Naming and Packaging

- **Git repository:** `UnitRegistry`
- **Primary assembly:** `UnitRegistry.Core.dll`
- **Primary namespace:** `UnitRegistry`

The library name emphasizes **management and identity**, not computation.

---

## Licensing

`UnitRegistry` is intended to be released under the **MIT License**.

Rationale:
- units and conversion mathematics are facts of reality and mathematics,
- no proprietary algorithms are required,
- the library benefits from wide reuse and adaptation,
- permissive licensing aligns with engineering ecosystem needs.

---

## Legal Position (Explicitly Stated)

This library:
- defines no proprietary units,
- encodes no trade secrets,
- copies no implementation from existing systems.

Units, dimensions, and conversions are:
- real‑world knowledge,
- mathematically defined,
- not subject to copyright or patent.

All implementations are original and independently designed.

---

## Intended Use Cases

- Engineering visualization systems
- Charting and plotting controls
- Simulation and modeling software
- Technical desktop applications
- Domain‑specific engineering tools

`UnitRegistry` is explicitly **not** intended as:
- a scientific computation engine,
- a replacement for symbolic math systems,
- a UI toolkit.

---

## Design Philosophy

The guiding principles of `UnitRegistry` are:

- **Correctness over convenience**
- **Semantics before presentation**
- **Explicit over implicit**
- **Stable identity**
- **Extensibility without fragility**
- **Minimalism by intent**

---

## Status

This document represents a **design intent**.

Implementation timing, API shape, and publishing are intentionally left open to allow careful consideration and incremental development.

The mere existence of this document establishes a conceptual boundary and architectural direction.