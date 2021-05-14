# Pandora

## Project Structure

- `./data` - contains the Azure API Definitions in the intermediate C# format.
- `./docs` - contains documentation.
- `./sdk` - contains the Generated Go SDK.
- `./tools` - contains the Go SDK Generator, Swagger Importer and various other bits of tooling.
- `./swagger` - git submodule containing the source data for generation (`git submodule init && git submodule update` after first checkout)