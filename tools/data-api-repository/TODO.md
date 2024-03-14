## To Do

This file tracks the changes needed to enable refactoring to use `data-api-repository`.

### Note

For the sake of brevity, the task list below assumes that:

* `Repository Models` means the structs and constants defined within `github.com/hashicorp/pandora/tools/data-api-repository/models`.
* `Legacy Repository Models` means the structs and constants defined within `github.com/hashicorp/pandora/tools/data-api/internal/repositories`.
* `Legacy DataAPIModels` means the structs and constants defined within `github.com/hashicorp/pandora/tools/sdk/dataapimodels`.
* `SDK Models` means the structs and constants defined within `github.com/hashicorp/pandora/tools/data-api-sdk/v1/models`.

### Changes needed

In order to migrate over to these types, we need to:

1. Update `./tools/data-api` to use the `Repository Models` in place of the `Legacy Repository Models` and `Legacy DataAPIModels` in both:
  * The Repository (`./tools/data-api/internal/repositories`) where the API Definitions are loaded from disk.
  * The Transforms (`./tools/data-api/internal/endpoints/v1/transforms`) used to map the `Legacy Repository Models` onto the `SDK Models` (which will become mapping the `Repository Models` onto the `SDK Models`).
  * At the end of this stage, the `SDK Models` should be returned from the Repository - with the `Repository Models` used by the Repository to store the API Definitions on disk.
2. Remove the `Legacy DataAPIModels`, since these should no longer be used.
3. Working through the `Repository Models` to ensure the names match those [defined in the refactoring issue](https://github.com/hashicorp/pandora/issues/3754) - and updating `./tools/data-api` and `./tools/data-api-repository` as needed, including (but not limited to):
  * Renaming `OptionObjectDefinition` to be `OperationOptionObjectDefinition`
  * Renaming `ObjectDefinition` to be `SDKObjectDefinition`.
4. Migrating the Transforms (`./tools/data-api/internal/endpoints/v1/transforms`) into the Data API Repository (`./tools/data-api-repository/transforms`) and refactoring `./tools/data-api` as needed.
5. Minor: adding a dedicated `README.md` to this directory and the `./tools/data-api-repository/models` directory summarizing the purpose of these packages.

Once this is completed, we can look into:

1. Refactoring the Discovery and Load logic to account for the new Repository types/structure.
2. Updating `importer-msgraph-metadata` to write out files using the new Repository/structs.
