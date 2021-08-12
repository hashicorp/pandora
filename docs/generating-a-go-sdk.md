# Guide: Generating a Go SDK from Swagger Data

## Note

This project **is a work-in-progress** - whilst the individual components work end-to-end - at this point these are (intentionally) not automatically integrated and there are several manual steps involved.

In addition, at the current time only Resource Manager service are supported - although we plan to support Microsoft Graph and the Resource Manager Data Plane API's in the future.

This will change in the future, as the workflows are confirmed over time - but this is sufficient for now.

If you've found a new bug or something that didn't generate as expected - please open an issue so we can track/diagnose it.

## Step 1: Importing Swagger Data into Pandora's Data Format

Swagger files which should be imported into Pandora's Data Format are currently hand-defined in [`./tools/importer-rest-api-specs/data.go`](https://github.com/hashicorp/pandora/blob/main/tools/importer-rest-api-specs/data.go#L12-L13).

This example shows a new mapping for a Resource Manager Service:

```go
		ResourceManagerInput{
			ServiceName:      "EventHub",
			ApiVersion:       "2021-01-01-preview",
			SwaggerDirectory: swaggerDirectory + "/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2021-01-01-preview",
			SwaggerFiles: []string{
				"AuthorizationRules.json",
				"CheckNameAvailability.json",
				"consumergroups.json",
				"disasterRecoveryConfigs.json",
				"eventhubs.json",
				"namespaces-preview.json",
				"networkrulessets-preview.json",
				"operations.json",
			},
		}.ToRunInput(),
```

Those fields are:

* `ApiVersion` - the version of this API (e.g. `2020-01-01` or `2020-01-01-preview`).
* `ServiceName` - the name of this Service, e.g. EventHub, Resources etc.
* `SwaggerDirectory` - the path to the directory containing the Swagger files for this service within the Git Submodule (which contains the Swagger data).
* `SwaggerFiles` - a list of Swagger files within this directory which should be parsed.
	* Note: these are intentionally not automatically discovered (yet) to be able to selectively exclude files as necessary (although this functionality exists within the codebase).

Once the new mapping exists, build and run the `./tools/importer-rest-api-specs` project:

```sh
$ cd ./tools/importer-rest-api-specs
$ make tools
$ make build
$ make import
```

This will parse the Swagger files, transform them as necessary and eventually output `*.cs` files into the `./data` folder.

Each Service and API version gets output to it's own directory, for example:

```
 $ tree data -d
data
├── Pandora.Definitions.ResourceManager
│   ├── AnalysisServices
│   │   └── v2017_08_01
│   │       ├── AnalysisServices
│   │       └── Servers
│   ├── AppConfiguration
│   │   └── v2020_06_01
│   │       ├── ConfigurationStores
│   │       ├── PrivateEndpointConnections
│   │       └── PrivateLinkResources
│   ├── EventHub
│   │   ├── v2017_04_01
│   │   │   ├── AuthorizationRulesDisasterRecoveryConfigs
│   │   │   ├── AuthorizationRulesEventHubs
│   │   │   ├── AuthorizationRulesNamespaces
│   │   │   ├── CheckNameAvailabilityDisasterRecoveryConfigs
│   │   │   ├── CheckNameAvailabilityNamespaces
│   │   │   ├── ConsumerGroups
│   │   │   ├── DisasterRecoveryConfigs
│   │   │   ├── EventHubs
│   │   │   ├── MessagingPlan
│   │   │   ├── Namespaces
│   │   │   ├── NetworkRuleSets
│   │   │   └── Regions
```

### Notes

* The Service Definition and API Version Definition are automatically discovered through reflection, as such simply including these files in the `Pandora.Data.ResourceManager` project ensures they get discovered.
* API's within API Version Definitions (which are generated) are _not_ automatically discovered but _could_ be in the future.
* The `importer-rest-api-specs` generator now outputs the Service Definition and API Version Definition as Partial Classes, meaning that the Generated can be re-created as needed whilst the Hand-Written components remain. This makes it possible to enable/disable generation of an API Version - or an entire Service - as necessary.
* When the Swagger submodule is updated we run a unit test which validates all existing Swaggers we use for generation can still be imported.

## Step 2: Launching the Data API

The Pandora API makes use of Reflection to automatically discover Service Definitions and the API Version Definitions and API Definitions contained within it.

This data goes through a transformation layer, which for each Service determines:

* The API Versions available
* The HTTP Operations, Schema (including Constants, Models and Resource ID's) for each API Version

The API can be built/run using:

```sh
$ cd data/
$ dotnet build ./Pandora.sln
$ dotnet ./Pandora.Api/bin/Debug/net5.0/Pandora.Api.dll
```

This launches the API on:

- http://localhost:5000
- https://localhost:5001 (using a self-signed certificate)

The main endpoint for the API at this time returns the Resource Manager Data: `/v1/resource-manager/services` which returns a list of Resource Manager Services.

We can validate the API's parsed correctly by checking the following URI's return a 200:

* `/v1/resource-manager/services/{name}/{version}`
* `/v1/resource-manager/services/{name}/{version}/{resource}/operations`
* `/v1/resource-manager/services/{name}/{version}/{resource}/schema`

Alternatively running a code generator will do this for you (since it hits the endpoints to load the data, using an SDK available in `./tools/sdk` and retrieving the next URI to call from the API response).

Assuming that no changes are required to get this to compile, you should be able to proceed to Step 3 - if there's compilation issues this indicates an error in Step 1 (importing/parsing the Swagger data) - please open an issue with more information this can be fixed.

### Note

At the current time the only way to process a Service Definition or API Version Definition through this Translation layer is to launch the API and hit the relevant URI (or run a code generator) - and at this time the errors returned are a little ambiguous (so you may need a debugger to isolate the specific field). This is a known issue tracked in https://github.com/hashicorp/pandora/issues/48 which will be fixed in the future - and likely a Unit Test will be introduced for each API Version Definition to verify that it maps correctly.

Also any Nullability warnings which show up within the Data project can be safely ignored - this is a (generally sensible) flag which we need to disable in the `Pandora.Definitions.ResourceManager` project since we use nullable types to indicate Optional fields within the data, where this isn't applicable.

## Step 3: Generating a Go SDK

The Go SDK Generator pulls all of the data from the Data API - so that needs to be running prior to doing so - and then generates a Go SDK for all of the Services/API Versions which have the "generate" flag set to true (which is the default).

The conditional flags for generating a Service and/or API Version are located within the Data (e.g. the Service Definition / API Version Definition) - so need to be updated in the API (and rebuilt/relaunched as necessary).

The Go SDK Generator can be generated by running:

```sh
$ cd ./tools/generator-go-sdk
$ go build . && ./generator-go-sdk
```

At the current time this outputs the Go SDK to a folder on your desktop (`~/Desktop/generated-sdk-dev`) - although this will change in the future. This folder can be safely deleted and regenerated as necessary.

This folder should match (for example):

```
$ tree -d
.
├── appconfiguration
│   ├── 2019-10-01
│   │   └── configurationstore
│   └── 2020-06-01
│       ├── configurationstores
│       ├── privateendpointconnections
│       └── privatelinkresources
├── eventhub
│   ├── 2017-04-01
│   │   ├── authorizationrulesdisasterrecoveryconfigs
│   │   ├── authorizationruleseventhubs
│   │   ├── authorizationrulesnamespaces
│   │   ├── checknameavailabilitydisasterrecoveryconfigs
│   │   ├── consumergroups
│   │   ├── disasterrecoveryconfigs
│   │   ├── eventhubs
│   │   ├── messagingplan
│   │   ├── namespaces
│   │   └── networkrulesets
...
```

## Step 4: Embedding this SDK within the Terraform Provider

As the current time we're embedding the generated Go SDK's within the Provider to enable us to diff this.

Prior to going any further, please send a PR with the changes highlighted above to the Pandora repository (and have that merged) so that this repository is up to date. For the moment, ensuring the PR titles start with `Data: ` would be helpful to be able to differentiate these from the other projects.

Longer term this SDK _may_ live in it's own repository, we're not sure - for now copying/embedding this SDK is sufficient.

The Generated SDK's get copied from:

```
~/Desktop/generated-sdk-dev/{service}/{version}/{resources}
```

to the following path within the provider:

```
./azurerm/internal/services/eventhub/sdk/{version}/{resources}
```

See [an example here](https://github.com/hashicorp/terraform-provider-azurerm/blob/8b8b5710bb4576e58fdeceda1dbad811d8eb9ef8/internal/services/analysisservices/sdk).

Notably when using a Pandora SDK we don't need to generate the Resource ID Parsers within the AzureRM Provider, since these are instead located within the SDK. At this time we don't generate Terraform Validation functions within the Pandora SDK, [which is tracked in this issue](https://github.com/hashicorp/pandora/issues/103) (either to generate these, or to write a generic validation function taking an ID Parsing function).

In the interim it's worth updating the existing (generated) validation function to use the ID Parser within the generated SDK - and removing the ID Generator from `resourceids.go` within the Service Package.

### Notes

The SDK Generated by Pandora is based on, but differs from the Azure SDK for Go - where the Azure SDK will output a single SDK (for example `network`) for a given API version, which contains all of the Resources - Pandora SDK's split these into separate packages.

This means Pandora SDK's will, by design, have more small SDK's (where the Azure SDK would output a single large SDK) - which allows us to both avoid naming conflicts in Constants between Resources and makes diffing (and gradual upgrades) easier, amongst other things.
