## Tool: Data API v2

This directory contains v2 of the Data API, which:

1. Is written in Golang and parses the API Definitions from flat files, the format of which is still to be decided
2. The API Models are reused between the SDK Client and the Data API
3. Becomes the source of truth for this information, rather than requiring Importers to update these files

To launch the Data API run the following commands:

```
$ go build . && ./data-api serve
```
