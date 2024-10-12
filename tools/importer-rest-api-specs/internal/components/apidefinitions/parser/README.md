TODO:

## A note on terminology

This package intentionally uses a combination of terminology to reflect the differing API Definitions available within `Azure/azure-rest-api-specs`.

* `Swagger` is used to refer to the API Definitions defined using Swagger 2.x (at the time of writing, the majority of the API Definitions).
* `OpenAPI` is used to refer to the API Definitions defined using OpenAPI 3.x (at the time of writing, few exist).
* `TypeSpec` is used to refer to the API Definitions written using [TypeSpec](https://github.com/Microsoft/typespec) which are typically compiled to Swagger 2.x or OpenAPI 3.x - and the majority of the Azure Resource Manager related items are based upon [the `Azure/typespec-azure` package](https://github.com/Azure/typespec-azure). 

Where possible we use the terminology `API Definition` since these are implementation details - but this more specific terminology will be used where necessary.

TODO also mention Supplemental Data