# UnitRegistry

2026-April

UnitRegistry is a lightweight, domain-agnostic library for managing physical units, dimensions, and unit conversion semantics in engineering software.

It provides a small, explicit foundation for working with physical quantities—such as length, time, pressure, and flow—without imposing application-specific assumptions, UI concerns, or numeric formatting policy.

---

## Design Goals

UnitRegistry is designed to:

- Treat **units and dimensions as first-class semantic concepts**
- Provide **deterministic, mathematically correct unit conversions**
- Support **extensibility** for custom units and engineering domains
- Remain **low-level and reusable** across long-lived engineering codebases
- Avoid unnecessary coupling to UI, rendering, or application logic

The library intentionally focuses on *what units are* and *how they relate*, not on how they are displayed or visualized.

---

## What UnitRegistry Provides

- Definitions for physical **dimensions** (e.g., Length, Time, Pressure)
- Definitions for **units** within a single dimension
- Conversion rules to and from canonical base units
- A **registry abstraction** for discovering and extending known units

---

## What UnitRegistry Does Not Provide

- UI or visualization components
- Domain-specific assumptions or workflows
- Numeric formatting or presentation logic
- Physical equations or dimensional algebra
- Product- or application-level behavior

These concerns are intentionally left to higher-level libraries and applications.

---

## Intended Use Cases

UnitRegistry is well suited for:

- Engineering visualization and charting systems
- Simulation and modeling software
- Technical desktop applications
- Shared infrastructure libraries
- Domain-specific engineering tools

It is particularly appropriate where **semantic correctness, clarity, and long-term stability** are more important than convenience shortcuts.

---

## Architecture

- Target framework: **netstandard2.0**
- No platform-specific dependencies
- Compatible with .NET Framework, .NET Core, and modern .NET runtimes
- No global static state requirements

The library is designed to integrate naturally with higher-level constructs such as numeric formatters, presentation models, and visualization systems without depending on them directly.

---

## Extensibility

UnitRegistry supports extension through explicit registration mechanisms, allowing consumers to:

- Introduce new dimensions
- Add custom units
- Replace or compose registries for domain-specific use cases

Extensibility is explicit and deterministic by design.

---

## Licensing

UnitRegistry is released under the **MIT License**.

Units, dimensions, and conversion mathematics represent real-world facts and established definitions. This library provides an original, independent implementation that expresses those facts in a reusable and open form.

---

## Status

This repository represents a foundational semantic layer.  
Development is intentionally incremental and focused on correctness, clarity, and long-term maintainability.
