# Internals: Future changes to the Architecture/Data API

This document covers changes required to the Data API to support the presence of multiple Importers.

> NOTE: This work is dependent on both `importer-msgraph-metadata` and `importer-rest-api-specs` being updated to use Data API v2.

Originally we intended to have a single Importer that support multiple Sources of Data (e.g. Microsoft Graph and Resource
Manager, with Data Plane support possible in the future) - however this has since been implemented as individual importers
for both Microsoft Graph (`importer-msgraph-metadata`) and Resource Manager (`importer-rest-api-specs`) which currently
necessitates duplicating both the models backing the API Definitions (today) and the Terraform Generation logic (in the
future).

This means that the system design currently looks similar to below:

```
┌─Current Implementation────────────────────────────────────────────────────────────────────────────────────────────────┐
│                                                                                                                       │
│                                                                                                                       │
│   ┌─Importers────────────────────────┐                                                                                │
│   │                                  │                   .───────.                                                    │
│   │  ┌────────────────────────────┐  │                ,─'         '─.                                                 │
│   │  │                            │  │               ╱               ╲                                                │
│   │  │  Rest API Specs Importer   │  │              ╱                 ╲                 ┌──────────────────────┐      │
│   │  │                            │  │             ;        API        :                │                      │      │
│   │  └────────────────────────────┘  │             │    Definitions    │                │       Data API       │      │
│   │  ┌────────────────────────────┐  │────────────▶│                   │◀───────────────│       V1 or V2       │      │
│   │  │                            │  │  Publishes  :   (C# or JSON)    ;    Consumes    │                      │      │
│   │  │  Microsoft Graph Importer  │  │              ╲                 ╱                 └──────────────────────┘      │
│   │  │                            │  │               ╲               ╱                                                │
│   │  └────────────────────────────┘  │                ╲             ╱                                                 │
│   │                                  │                 '─.       ,─'                                                  │
│   └──────────────────────────────────┘                    `─────'                                                     │
│                                                                                                                       │
│                                                                                                                       │
└───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
```

Whilst it was possible to coordinate changes to both Importers and the Data API for the API Definitions, given that we
may need to support additional Importers in the future (e.g. Data Plane) and that in order for each Importer to support
Identifying and Building Terraform Resources in the future - it's likely that divergences would emerge over time and that
there's value in having a greater separation of concerns here.

As such there's a number of improvements we can make to the system design which'll make life easier going forwards,
namely having the Data API owning the API Definitions - and splitting out a dedicated tool for identifying and building
the Terraform Data Sources and Resources from the API Definitions.

This approach allows each tool to have a single focus - becoming far simpler and thus easier to reason with - which will
enable reducing the complexity of the `importer-rest-api-specs` tool in particular.

To do this we'll want to make two changes to the current system design:

1. Have the Data API become the sole maintainer of the API Definitions.
2. Split out the Terraform Identification/Builder logic from the `importer-rest-api-specs` tool.

### Step 1: Update the Data API to become the sole maintainer of the API Definitions

To have the Data API become the sole maintainer, we'll need to change how these files are persisted.

At present each Importer writes the API Definitions to a known folder in a known format - instead we'll need to change
this such that each Importer publishes the API Definitions to the Data API (via new API Endpoints) - which then in turn
write the API Definitions to disk as needed.

This necessitates:

1. The Data API needs a new set of endpoints, _presumably_ supporting:
  * `DELETE {serviceType}/services/{serviceName}` - to support deleting an existing Service.
  * `DELETE {serviceType}/services/{serviceName}/{apiVersion}` - to support deleting an existing API Version.
  * `GET {serviceType}/services/{serviceName}` - to support retrieving an existing Service.
  * `GET {serviceType}/services/{serviceName}/{apiVersion}` - to support retrieving an existing API Version.
  * `PUT {serviceType}/services/{serviceName}` - to support creating a new (or replacing an existing) Service.
  * `PUT {serviceType}/services/{serviceName}/{apiVersion}` - to support creating a new (or replacing an existing) API Version within a Service.
2. The SDK for the Data API needs to be updated to support these new endpoints.
3. Updating each Importer to use the new endpoints, rather than writing the files to disk.

This allows the Data API to become the sole maintainer of the API Definitions - making any changes easier going
forwards and means the system design would look similar to below:

```
┌─Future Implementation─────────────────────────────────────────────────────────────────────────────────────────────────┐
│                                                                                                                       │
│                                                                                                                       │
│   ┌─Importers────────────────────────┐                                                                                │
│   │                                  │  Retrieves                                              .───────.              │
│   │  ┌────────────────────────────┐  │   Current   ┌──────────────────────┐                 ,─'         '─.           │
│   │  │                            │  │    State    │                      │                ╱               ╲          │
│   │  │  Rest API Specs Importer   │  │────────────▶│                      │               ╱                 ╲         │
│   │  │                            │  │             │                      │              ;        API        :        │
│   │  └────────────────────────────┘  │             │       Data API       │              │    Definitions    │        │
│   │  ┌────────────────────────────┐  │             │                      │─────────────▶│                   │        │
│   │  │                            │  │             │         (V2)         │  Publishes   :      (JSON)       ;        │
│   │  │  Microsoft Graph Importer  │  │────────────▶│                      │               ╲                 ╱         │
│   │  │                            │  │  Publishes  │                      │                ╲               ╱          │
│   │  └────────────────────────────┘  │             │                      │                 ╲             ╱           │
│   │                                  │             └──────────────────────┘                  '─.       ,─'            │
│   └──────────────────────────────────┘                                                          `─────'               │
│                                                                                                                       │
│                                                                                                                       │
└───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
```

This change is necessary to support Step 2, splitting out the Terraform Resource Builder logic from the
`importer-rest-api-specs` tool - which is necessary to be able to generate Data Sources and Resources for Microsoft
Graph in the future.

Whilst the files used for the API Definitions are in sync, we can gradually migrate from the current setup to publishing
the API Definitions to the Data API.

This means that we'll need to have a Data API instance available in order to run  each Importer, which whilst might
sound not ideal - means that we could extend the Data API to better support local development in the future.
For example, supporting launching the Data API with a feature-flag where the API Definitions are stored in-memory
only - meaning that these don't need to be persisted to disk, speeding up local development - or other changes which
may seem helpful in the future.

In order to run this in automation, we'll need to add a couple of new modes to the `wrapper-automation` tool, to support
launching the Data API prior to running each Importer, but that should be mostly reusable from the existing logic / a
previous implementation as can be found [in this pull request](https://github.com/hashicorp/pandora/pull/1637).

### Step 2: Split out the Terraform Resource Builder logic from the `importer-rest-api-specs` tool.

Today Terraform Resources are identified and then built-up (that is, the Terraform Schema, Mappings and Tests for that
Terraform Resource) within `importer-rest-api-specs` - which means that in order to support generating Resources (and
Data Sources, in the future) - we would need to duplicate this logic into `importer-msgraph-metadata` and keep this
relatively in-sync - which is a similar problem to the API Definitions.

Rather than doing this we should introduce a separate tool, working name `Terraform Resource Builder` - which focuses
solely on Building Terraform Resources (that is, the Terraform Schema, any Mappings and the Acceptance Tests) based
on the data within the Data API.

This allows each Importer (that is, `importer-rest-api-specs` and `importer-msgraph-metadata`) to remain focused on
Importing the API Definitions - where the API Definitions are then pushed into the Data API - with the Terraform Resource
Builder pulling information from the Data API - and subsequently pushing any changes back to it.

Whilst spreading these tools out does introduce a little more overhead, it makes the process boundaries clearer - since
the inputs and outputs for each tool are more clearly defined. For example, this should make supporting Data Sources in
the future simpler - since we can first add support the Terraform Resource Builder, push that data into the Data API,
then validate the data looks good - and finally work on outputting the Data Sources in `generator-terraform`.

> Note that it could also make sense for this tool to support Identifying new candidate Terraform Resources and Data Sources
in the future - sending a PR which updates the `./config/resources/{serviceName}.hcl` files.

At a high level this looks like:

```
┌─Future Implementation: Step 2─────────────────────────────────────────────────────────────────────────────────────────┐
│                                                                                                                       │
│                                                                                                                       │
│                                                    ┌──────────────────────┐                                           │
│                                                    │  Terraform Resource  │                                           │
│                                                    │       Builder        │                                           │
│                                                    └──────────────────────┘                                           │
│                                                       ▲               │                                               │
│                                                       │Retrieves      │                                               │
│                                                       │ Current       │Publishes                                      │
│                                                       │  State        │                                               │
│   ┌─Importers────────────────────────┐                │               │                                               │
│   │                                  │  Retrieves     ▽               ▼                        .───────.              │
│   │  ┌────────────────────────────┐  │   Current   ┌──────────────────────┐                 ,─'         '─.           │
│   │  │                            │  │    State    │                      │                ╱               ╲          │
│   │  │  Rest API Specs Importer   │  │────────────▶│                      │               ╱                 ╲         │
│   │  │                            │  │             │                      │              ;        API        :        │
│   │  └────────────────────────────┘  │             │       Data API       │              │    Definitions    │        │
│   │  ┌────────────────────────────┐  │             │                      │─────────────▶│                   │        │
│   │  │                            │  │             │         (V2)         │  Read/Write  :      (JSON)       ;        │
│   │  │  Microsoft Graph Importer  │  │────────────▶│                      │               ╲                 ╱         │
│   │  │                            │  │  Publishes  │                      │                ╲               ╱          │
│   │  └────────────────────────────┘  │             │                      │                 ╲             ╱           │
│   │                                  │             └──────────────────────┘                  '─.       ,─'            │
│   └──────────────────────────────────┘                                                          `─────'               │
│                                                                                                                       │
│                                                                                                                       │
└───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
```

### End Result

With these changes all together, this means that the overall System Design will look similar to below:

```
┌─Future Implementation: End Goal───────────────────────────────────────────────────────────────────────────────────────┐
│                                                                                                                       │
│                                                    ┌──────────────────────┐                                           │
│                                                    │  Terraform Resource  │                                           │
│                                                    │       Builder        │                                           │
│                                                    └──────────────────────┘                                           │
│                                                       ▲               │                                               │
│                                                       │Retrieves      │                                               │
│                                                       │ Current       │Publishes                                      │
│                                                       │  State        │                                               │
│   ┌─Importers────────────────────────┐                │               │                                               │
│   │                                  │  Retrieves     ▽               ▼                        .───────.              │
│   │  ┌────────────────────────────┐  │   Current   ┌──────────────────────┐                 ,─'         '─.           │
│   │  │                            │  │    State    │                      │                ╱               ╲          │
│   │  │  Rest API Specs Importer   │  │────────────▶│                      │               ╱                 ╲         │
│   │  │                            │  │             │                      │              ;        API        :        │
│   │  └────────────────────────────┘  │             │       Data API       │              │    Definitions    │        │
│   │  ┌────────────────────────────┐  │             │                      │─────────────▶│                   │        │
│   │  │                            │  │             │         (V2)         │  Read/Write  :      (JSON)       ;        │
│   │  │  Microsoft Graph Importer  │  │────────────▶│                      │               ╲                 ╱         │
│   │  │                            │  │  Publishes  │                      │                ╲               ╱          │
│   │  └────────────────────────────┘  │             │                      │                 ╲             ╱           │
│   │                                  │             └──────────────────────┘                  '─.       ,─'            │
│   └──────────────────────────────────┘                         ▲                                `─────'               │
│                                                                │ Retrieves                                            │
│                                                                │  Current                                             │
│                                                                │   State                                              │
│                                                                │                                                      │
│                                   ┌─Generators──────────────────────────────────────────────┐                         │
│                                   │                                                         │                         │
│                                   │    ┌────────────────────┐  ┌───────────────────────┐    │                         │
│                                   │    │                    │  │                       │    │                         │
│                                   │    │  Go SDK Generator  │  │  Terraform Generator  │    │                         │
│                                   │    │                    │  │                       │    │                         │
│                                   │    └────────────────────┘  └───────────────────────┘    │                         │
│                                   │                                                         │                         │
│                                   └─────────────────────────────────────────────────────────┘                         │
│                                                                                                                       │
└───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
```
