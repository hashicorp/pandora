# Microsoft Graph API Specs Importer

The Microsoft Graph API specs are in OpenAPI3 format. The data we parse is automatically generated from the original API Metadata which are in OData XML format. This translation to OpenAPI3 format is performed by a [.NET tool](https://github.com/microsoft/OpenAPI.NET.OData) published by Microsoft.

You can read more about Microsoft Graph Metadata at https://learn.microsoft.com/en-us/graph/traverse-the-graph

The metadata can be downloaded directly from the service at one of the following URLs:
- https://graph.microsoft.com/v1.0/$metadata
- https://graph.microsoft.com/beta/$metadata

Both the metadata and OpenAPI3 specs are published on GitHub at [microsoftgraph/msgraph-metadata](https://github.com/microsoftgraph/msgraph-metadata); this is where we currently source this data as it's versioned and fits in with our git submodule approach.

## API Versions

MS Graph has two distinct API versions, which are the same across all services. These are `v1.0` and `beta`. You may also sometimes see references to a `v2.0` API, this appears to be internal and/or never released to the public, but it does leak through in some API responses.

Each API version comprises many services, which are exposed via a unified frontend and can be found at various URL subtrees. All the services for each API version are described in a single metadata / OpenAPI3 file per version.

When importing from these API versions, we normalize them to `stable` and `beta` as this makes for easier handling when the Go SDK is built.

New features and services are _supposed_ to go into the `beta` API, with a period of public preview, before being added to the `v1.0` API. The latter is not supposed to receive breaking changes, however in practice this is clearly impossible and so it regularly receives breaking changes.

Additionally, whilst Microsoft disclaims use of the `beta` API in production and recommends all customers use the `v1.0` API, there are lots of services that have yet to make it out of beta/preview, and the Portal uses the beta API literally everywhere.

## Adding New Services

To assist when adding new services, the importer has a `list-tags` subcommand which is intended to be run locally and which outputs a list of tags and subtags for each API version. Whilst subtags are not supported by the importer, this lets you see at a glance which tags are available and these are translated directly into Services.

The importer reads from the `config/microsoft-graph.hcl` configuration file (from the root of the Pandora repository). Similarly to Resource Manager, this is where to configure services/tags for importing. Some tags are only supported in one API version, and others have different features in each API version.

## The Importer

We use the `github.com/getkin/kin-openapi` module to read the OpenAPI3 specs, and implement our own parser in the `components/parser` package. This shares many of the same paradigms as the `importer-rest-api-specs` tool, but adjusted for the different OpenAPI specification and the way in which OData objects are expressed in the translated spec.

This tool has its own internal types for representing things like Services, Resources, Resource IDs, Models etc, these are all defined in the `components/parser` package. The core parsing logic of populating these types happens within that package, whilst the "business logic" of determining what to import and how to import it happens in the `internal/pipeline` package.

One notable feature of Microsoft Graph compared to Resource Manager is that data types (models) are shared across the entire API. For example, the `users` service would make use of `directoryObject`, `group`, `servicePrincipal` and other models. Furthermore, internally within MS Graph most objects have some inheritance, forming a tree of models with behavior much like class inheritance. We intentionally don't express this when importing, and have elected to flatten all ancestor fields in a family tree.

This global namespace of models leads to some excessive duplication if we define those models on a per-resource or per-service basis, so we consolidate them into a single namespace we refer to as "common types". In the generated SDK, this is output as separate packages called `common-types/stable` and `common-types/beta`, doing so greatly reduces the SDK footprint by an order of magnitude.

### How the internal types map to data API types

After importing and processing the API specs using the internal types in `components/parser`, they are then translated to the Data API native types to be persisted in the Data API. There are some things to be aware of in this translation:

* The internal types for Resources have a `Category` and a `Name` - the `Category` maps to the resource name in the data API and the `Name` is used to build operation names. The reason for this approach is that each "resource" in the data API contains multiple Graph resources and/or representations of resources, so the importer organises these internally as "categories" to facilitate grouping of resources prior to translation.
* All models and constants described in the API spec are considered to be "common types", the only models which are local to a resource are those that represent complex request objects.
* Resource IDs are all considered to be resource-local - even though they are intentionally fully-namespaced and are all parsed out together prior to parsing out the resources, so they could in theory _could_ be pooled together as "common resource IDs". However, this would require refactoring of the SDK generator, and at this time (unlike with models), there is no significant overhead to duplicating these.

## About OData

[OData](https://www.odata.org/) is a data representation & navigation specification published by Microsoft and Oracle with low industry adoption. It is largely built for .NET and this is the only widely used language with proper support for it. Golang has no library support that we've found which is why we have [built this ourselves](https://github.com/hashicorp/go-azure-sdk/tree/main/sdk/odata) (whilst trying to keep it simple and generic).

Whilst Resource Manager makes use of some OData primitives, it has been embraced in Microsoft Graph and is the primary means of navigating the API and expressing relationships between resource/objects.

However, it is worth pointing out that MS Graph has made notably noncompliant revisions to their OData implementation. Particularly around the use of OData IDs which are _supposed_ to be fully qualified URIs, for example:

```
https://graph.microsoft.com/v1.0/directoryObjects/00000000-0000-0000-0000-000000000000
```

However, these are increasingly received as part of API responses in other formats, like:

```
directoryObjects('00000000-0000-0000-0000-000000000000')
```

The base layer SDK nor the dataplane SDKs generated by Pandora are currently able to parse these or infer the related URLs, it is up to the implementor (e.g. Terraform providers) to do so.
