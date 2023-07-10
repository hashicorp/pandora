## PoC: Data API v2

This directory contains a proof-of-concept of a v2 of the Data API, which:

1. Is written in Golang and parses the API Definitions from HCL files
2. The API Models are reused between the SDK Client and the Data API
3. Becomes the source of truth for this information, rather than requiring Importers update these files

In order for this to ship, we'd:

1. Need to consolidate the `Generator` services used by the Importers.

This approach would allow:

1. XXX
