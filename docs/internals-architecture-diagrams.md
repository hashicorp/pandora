## Internals: Architecture Diagrams

Pandora is a series of different tools, the following diagram highlights how they all fit together:

```
┌─System Overview────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
│                                                                                                                            │
│  ┌─Data Sources (Repositories)──────────────┐   ┌─Configs───────────────────────────────────────────────────────────────┐  │
│  │                                          │   │ ┌────────────────────────────────┐ ┌────────────────────────────────┐ │  │
│  │  ┌────────────────────────────────────┐  │   │ │  Resource Manager (Services)   │ │   Microsoft Graph (Services)   │ │  │
│  │  │     Azure/azure-rest-api-specs     │  │   │ └────────────────────────────────┘ └────────────────────────────────┘ │  │
│  │  └────────────────────────────────────┘  │   │ ┌────────────────────────────────┐                                    │  │
│  │  ┌────────────────────────────────────┐  │   │ │  Resource Manager (Terraform)  │                                    │  │
│  │  │  microsoftgraph/msgraph-metadata   │  │   │ └────────────────────────────────┘                                    │  │
│  │  └────────────────────────────────────┘  │   │                                                                       │  │
│  │                                          │   │  The list of Services (and API Versions) for Resource Manager is      │  │
│  │  These are updated Daily via Dependabot  │   │  updated by the `version-bumper` tool - which runs once the Submodule │  │
│  │                                          │   │  has been updated.                                                    │  │
│  └──────────────────────────────────────────┘   └───────────────────────────────────────────────────────────────────────┘  │
│                        ▲                                                            ▲                                      │
│                        │                                                            │                                      │
│                        │                     Loads data from                        │                                      │
│                        └────────────────────────────┬───────────────────────────────┘                                      │
│                                                     │                                                                      │
│                                                     │                                                                      │
│                                                     │                                                                      │
│                  ┌──────Importers─────────────────────────────────────────────────────┐                                    │
│                  │     ┌───────────────────────────┐  ┌───────────────────────────┐   │                                    │
│                  │     │  Rest API Specs Importer  │  │ Microsoft Graph Importer  │   │                                    │
│                  │     └───────────────────────────┘  └───────────────────────────┘   │                                    │
│                  │                                                                    │                                    │
│                  │ Each importer loads it's Config and then the associated data for   │                                    │
│                  │ each Service from the Data Source.                                 │                                    │
│                  │                                                                    │                                    │
│                  │ This data is then parsed and transformed as required to give a     │        Publishes                   │
│                  │ consistent set of API Definitions for each Service.                │─────────────────┐                  │
│                  │                                                                    │                 │                  │
│                  │ The Rest API Specs Importer also generates any Terraform Resources │                 ▼                  │
│                  │ that are defined in the associated Config.                         │            .─────────.             │
│                  │                                                                    │         ,─'           '─.          │
│                  │ Finally the processed data is output as API Definitions which the  │        ╱                 ╲         │
│                  │ Data API can then consume (and serve).                             │       ;  API Definitions  :        │
│                  │                                                                    │       :    (C# / JSON)    ;        │
│                  └────────────────────────────────────────────────────────────────────┘        ╲                 ╱         │
│                                                                                                 ╲               ╱          │
│                                                                                                  '─.         ,─'           │
│                                                                                                     `───────'              │
│                  ┌─Data API───────────────────────────────────────────────────────────┐                 ▲                  │
│                  │                  ┌──────────────────────────────┐                  │                 │                  │
│                  │                  │      Data API (V1 / V2)      │                  │                 │                  │
│                  │                  └──────────────────────────────┘                  │  Loads data from│                  │
│                  │                                                                    │─────────────────┘                  │
│                  │ The Data API exposes the API Definitions over a known set of       │                                    │
│                  │ HTTP endpoints.                                                    │                                    │
│                  └────────────────────────────────────────────────────────────────────┘                                    │
│                                                     ▲                                                                      │
│                                                     │                                                                      │
│                                                     │ Retrieves API                                                        │
│                                                     │  Definitions                                                         │
│                                                     │                                                                      │
│                  ┌───────Generators───────────────────────────────────────────────────┐                                    │
│                  │          ┌──────────────────────┐ ┌──────────────────────┐         │                                    │
│                  │          │   Go SDK Generator   │ │ Terraform Generator  │         │                                    │
│                  │          └──────────────────────┘ └──────────────────────┘         │                                    │
│                  │                                                                    │                                    │
│                  │ Each generator retrieves the API Definitions from the Data API and │                                    │
│                  │ then generates either the Go SDK or Terraform Resources as needed. │                                    │
│                  │                                                                    │                                    │
│                  │ The associated unit tests are then run on the updated generated    │                                    │
│                  │ output to ensure that it compiles, before a branch is pushed to    │                                    │
│                  │ the relevant downstream repository.                                │                                    │
│                  └────────────────────────────────────────────────────────────────────┘                                    │
│                                                     │                                                                      │
│                                                     │  Updates                                                             │
│                                                     │                                                                      │
│                                                     ▼                                                                      │
│                 ┌─Outputs──────────────────────────────────────────────────────────────┐                                   │
│                 │  ┌─────────────────────────┐ ┌────────────────────────────────────┐  │                                   │
│                 │  │ hashicorp/go-azure-sdk  │ │hashicorp/terraform-provider-azurerm│  │                                   │
│                 │  └─────────────────────────┘ └────────────────────────────────────┘  │                                   │
│                 │                                                                      │                                   │
│                 │  Automation within each repository will open a Pull Request when a   │                                   │
│                 │  branch is opened.                                                   │                                   │
│                 │                                                                      │                                   │
│                 └──────────────────────────────────────────────────────────────────────┘                                   │
│                                                                                                                            │
└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
```
