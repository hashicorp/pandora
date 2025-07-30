module github.com/hashicorp/pandora/tools/version-bumper

go 1.24.5

require (
	github.com/hashicorp/hcl/v2 v2.16.2
	github.com/hashicorp/pandora/tools/sdk v0.0.0-00010101000000-000000000000
)

require (
	github.com/agext/levenshtein v1.2.2 // indirect
	github.com/apparentlymart/go-textseg/v13 v13.0.0 // indirect
	github.com/google/go-cmp v0.5.9 // indirect
	github.com/mitchellh/go-wordwrap v1.0.0 // indirect
	github.com/zclconf/go-cty v1.13.1 // indirect
	golang.org/x/text v0.14.0 // indirect
)

replace github.com/hashicorp/pandora/tools/sdk => ../sdk

replace github.com/hashicorp/pandora/tools/data-api-sdk => ../data-api-sdk
