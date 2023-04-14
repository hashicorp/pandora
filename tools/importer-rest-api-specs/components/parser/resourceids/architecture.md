This file defines the high-level process for Resource ID parsing, see the high-level architecture diagram in the root of this tool for more information.

```
┌─Resource ID Parsing────────────────────────────────────────────────────────────────┐
│                                                                                    │
│   ┌─────────────────────────────────────────────┐                                  │
│   │       Get full list of Operation URIs       │                                  │
│   │                 (aka paths)                 │                                  │
│   └─────────────────────────────────────────────┘                                  │
│                          │                                                         │
│                          ▼                                                         │
│   ┌─────────────────────────────────────────────┐                                  │
│   │ Extract a list of all Resource IDs from the │                                  │
│   │           list of Operation URIs            │─┐                                │
│   └─────────────────────────────────────────────┘ │                                │
│                                                   ▼                                │
│                    ┌─────────────────────────────────────────────────────────────┐ │
│                    │Parsing the Operation URI into either:                       │ │
│                    │1. A Resource ID (with no UriSuffix) - e.g. `/{resourceId}   │ │
│                    │2. A Resource ID and a UriSuffix - e.g. `/{resourceId}/start`│ │
│                    │3. A UriSuffix (with no Resource ID) - e.g. `/start`         │ │
│                    │                                                             │ │
│                    └─────────────────────────────────────────────────────────────┘ │
│                                                   │                                │
│                                                   ▼                                │
│                    ┌─────────────────────────────────────────────────────────────┐ │
│                    │              Normalising Resource ID Segments               │ │
│                    │                 (e.g. ensuring camelCase'd)                 │ │
│                    └─────────────────────────────────────────────────────────────┘ │
│                                                   │                                │
│                                                   │                                │
│   ┌─────────────────────────────────────────────┐ │                                │
│   │ Condense down to a list of unique Resource  │ │                                │
│   │                     IDs                     │◀┘                                │
│   └─────────────────────────────────────────────┘                                  │
│                          │                                                         │
│                          ▼                                                         │
│   ┌─────────────────────────────────────────────┐                                  │
│   │ Identity and switch out Common Resource IDs │                                  │
│   │     (which come from go-azure-helpers)      │                                  │
│   └─────────────────────────────────────────────┘                                  │
│                          │                                                         │
│                          ▼                                                         │
│   ┌─────────────────────────────────────────────┐                                  │
│   │Determine the resource name that the resource│                                  │
│   │  ID corresponds to based on the available   │                                  │
│   │                  segments                   │                                  │
│   └─────────────────────────────────────────────┘                                  │
│                          │                                                         │
│                          ▼                                                         │
│   ┌─────────────────────────────────────────────┐                                  │
│   │Determine the resource name that the resource│                                  │
│   │  ID corresponds to based on the available   │                                  │
│   │                  segments                   │                                  │
│   └─────────────────────────────────────────────┘                                  │
│                          │                                                         │
│                          ▼                                                         │
│   ┌─────────────────────────────────────────────┐                                  │
│   │ Map the parsed and normalised resource IDs  │                                  │
│   │ back to the original list of Operation URIs │                                  │
│   │                                             │                                  │
│   └─────────────────────────────────────────────┘                                  │
│                                                                                    │
└────────────────────────────────────────────────────────────────────────────────────┘
```