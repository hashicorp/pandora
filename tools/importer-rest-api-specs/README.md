## Tool: `importer-rest-api-specs`

This tool imports data from the `Azure/azure-rest-api-specs` repository (accessible in the Git Submodule located at `./swagger`)
into the Data format used by the Data API.

For most use-cases you'll want to run `make import` which will parse and process the Swagger Data into the Definitions used by the Data API.

However the binary supports a couple of other commands:

```
 $ ./importer-rest-api-specs
Usage: importer-rest-api-specs [--version] [--help] <command> [<args>]

Available commands are:
    import      Parses and Processes the Data from the './swagger' submodule
    segments    Outputs a list of Segments used in the Resource IDs
    validate    Validates that the data within the './swagger' submodule can be parsed
```
