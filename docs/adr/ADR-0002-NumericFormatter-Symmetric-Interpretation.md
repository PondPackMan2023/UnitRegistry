
# ADR-0002 – NumericFormatter Symmetric Interpretation

## Status
Accepted

## Context
ADR-0001 established `NumericFormatter` as a formatting-only abstraction within UnitRegistry, intentionally excluding parsing and interpretation. This decision emphasized separation between numeric presentation policy and UI or editing workflows.

Subsequent integration with the Engineering Graph Controls revealed a practical limitation of a format-only abstraction: numeric values formatted for display must sometimes be edited by users and then interpreted back into numeric form. Without a symmetric interpretation capability, downstream consumers were forced to bypass formatter semantics and rely on ad-hoc parsing (e.g., `double.TryParse`), leading to potential loss of precision, culture inconsistencies, and violation of formatter-defined invariants.

ADR-0001 explicitly anticipated the possibility of extending NumericFormatter in the future if real consumers demonstrated a need for additional capabilities. The Engineering Graph Options dialog provided such a concrete use case.

## Decision
`NumericFormatter` is extended with an optional, additive API that supports **symmetric numeric interpretation** of fully-formed numeric strings formatted according to the formatter’s rules.

This interpretation capability:
- Accepts complete numeric strings only.
- Interprets values using the formatter’s configured `FormatProvider`.
- Returns success/failure without throwing for expected invalid input.
- Preserves numeric round-trip integrity for values produced by the same `NumericFormatter` instance.

This change is additive and does not alter existing formatting behavior.

## Explicit Non-Goals
This decision deliberately does **not** introduce any of the following:
- Partial-input or keystroke-level validation semantics.
- UI or framework dependencies (WinForms, WPF, web, etc.).
- Editing workflow management or error presentation.
- Auto-scaling, heuristic "nice number" logic, or unit selection.
- Replacement of consumer-side validation or workflow control.

## Rationale
Numeric formatting in UnitRegistry is already authoritative for:
- Axis label generation
- Tick label generation
- Layout decisions influenced by formatted string length
- Snapshot identity and change tracking

Without a symmetric interpretation mechanism, consumers cannot safely perform numeric round-trips without duplicating formatter policy or violating its invariants. Providing a narrowly scoped interpretation API within NumericFormatter preserves architectural integrity while avoiding policy duplication and UI leakage.

This decision fulfills the future-extension allowance described in ADR-0001 and reflects lessons learned from real downstream usage.

## Consequences
### Positive
- Enables lossless numeric round-trips for formatter-produced values.
- Centralizes numeric representation semantics in a single authority.
- Eliminates ad-hoc parsing logic in downstream consumers.
- Unblocks correct implementation of numeric editing workflows.

### Negative / Trade-offs
- Slightly expands the responsibility surface of NumericFormatter.
- Requires careful documentation to avoid misuse as a general UI parser.

These trade-offs are considered acceptable given the strict scope limitations and clear non-goals defined above.

## Relationship to ADR-0001
This ADR extends ADR-0001 without invalidating it. All principles established in ADR-0001 remain in effect; this decision adds a narrowly scoped, experience-driven capability that complements the original design.

---

*End of ADR-0002.*
