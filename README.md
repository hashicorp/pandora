# Pandora

## Project Structure

- `./data` - contains the Azure API Definitions in the intermediate C# format.
- `./docs` - contains documentation.
- `./swagger` - git submodule containing the source data for generation (`git submodule init && git submodule update` after first checkout)
- `./tools` - contains the Go SDK Generator, Swagger Importer and various other bits of tooling.
