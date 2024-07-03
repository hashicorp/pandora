## `./internal/components/discovery`

This package is used to discover the available API Definitions for a given Service/API Version combination.

The API Definitions within [the `Azure/azure-rest-api-specs` repository](https://github.com/Azure/azure-rest-api-specs) are structured in multiple ways - and as such this structure identifies the files for a given Service/API Version combination and then surfaces the absolute paths to them.

Most API Definitions are structured under: `/specification/{serviceName}/resource-manager/{ResourceProvider}/(stable|preview)/{apiVersion}`.

Example: `/specification/addons/resource-manager/Microsoft.Addons/preview/2017-05-15-preview`

These are either hand maintained, generated via some means, or (for more recent API Versions) generated from the TypeSpec housed within `/specification/{serviceName}/{ResourceProvider}` (e.g. `/specification/containerservice/Fleet.Management`).

> At this point in time we don't compile the TypeSpec definitions to ensure the OpenAPI Definitions are up-to-date - but that's _probably_ something to consider doing in the future.

Whilst most of the API Definitions use the patterns defined above, there are two other scenarios to mention:

---

Firstly, some Services which contain a larger Resource Provider can be split up into smaller chunks, which [Microsoft calls a `Service Group`](https://github.com/Azure/azure-rest-api-specs/blob/abad0096677005817d2c19df2364663e5583c8fc/documentation/directory-structure.md#about-legacy-deprecated-directory-structure-for-services-and-service-groups) - this is now **LEGACY** and **DEPRECATED** - however we still need to parse API Versions using this.

From our side we merge the different Service Groups together into a single Service / APIVersion - since this makes sense for our use-case - _arguably_ we could merge these together by generating a new Service named `Service{ServiceGroup}` - but this has been fine for now.

These are housed using the structure `/specification/{serviceName}/resource-manager/{resourceProvider}/{serviceGroup}/(preview|stable)/{apiVersion}` (e.g. `/specification/mediaservices/resource-manager/Microsoft.Media/Accounts/stable/2023-01-01`).

---

Finally, some Services contain information from multiple Resource Providers, so these need to be similarly flattened into a single set of data.

This can be combined with a Service Group, which uses the structure `./specification/compute/resource-manager/{ResourceProvider}/(Grouping)/(stable|preview)/{apiVersion}` (e.g. `./specification/compute/resource-manager/Microsoft.Compute/CloudserviceRP/stable/2022-09-04`).

