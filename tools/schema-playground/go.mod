module github.com/hashicorp/pandora/tools/schema-playground

go 1.18

require (
	github.com/hashicorp/pandora/tools/importer-rest-api-specs v0.0.0-00010101000000-000000000000
	github.com/hashicorp/pandora/tools/sdk v0.0.0-00010101000000-000000000000
)

require (
	github.com/agext/levenshtein v1.2.1 // indirect
	github.com/apparentlymart/go-textseg/v13 v13.0.0 // indirect
	github.com/fatih/color v1.13.0 // indirect
	github.com/google/go-cmp v0.5.2 // indirect
	github.com/hashicorp/go-hclog v1.2.1 // indirect
	github.com/hashicorp/hcl/v2 v2.10.1 // indirect
	github.com/mattn/go-colorable v0.1.12 // indirect
	github.com/mattn/go-isatty v0.0.14 // indirect
	github.com/mitchellh/go-wordwrap v0.0.0-20150314170334-ad45545899c7 // indirect
	github.com/zclconf/go-cty v1.8.0 // indirect
	golang.org/x/sys v0.0.0-20220503163025-988cb79eb6c6 // indirect
	golang.org/x/text v0.3.5 // indirect
)

replace github.com/hashicorp/pandora/tools/importer-rest-api-specs => ../importer-rest-api-specs

replace github.com/hashicorp/pandora/tools/sdk => ../sdk
