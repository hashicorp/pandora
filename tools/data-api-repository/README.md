## `./tools/data-api-sdk`

This package provides a Repository which can be used to load/store API Definitions on-disk in a consistent manner.

This is currently used in:

* `./tools/data-api` - to load and serve the API Definitions, for use in other tooling.
* `./tools/importer-rest-api-specs` - to remove any existing and then import all-new API Definitions for Azure Resource Manager.

This package isn't intended to be used directly, and other tooling should interact with the Data API instead.
