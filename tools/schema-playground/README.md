## Tool: Schema Playground

This is an experimental tool which is designed to allow the development of the Schema Generation and associated Mappings.

Ultimately this tool will be integrated into `./tools/importer-rest-api-specs` - but whilst iterating this is simplest as a separate tool.

### How does this work?

This is a **work in progress** however this currently:

1. Loads the Services/API Versions/Resources defined in the Config (`./config/resources`).
2. Loads the Services available from the Data API and identifies Candidate Data Sources and Resources from it.
3. Iterates over those candidates, and if they're defined in the Config - transforms the model into the Schema.

Ultimately this tool will generate both the Terraform Schema and the Mappings for that Schema to/from the models available in the Go SDK - and eventually be integrated into the `./tools/importer-rest-api-specs` tool.
