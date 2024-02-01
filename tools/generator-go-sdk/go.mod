module github.com/hashicorp/pandora/tools/generator-go-sdk

go 1.21

require (
	github.com/hashicorp/go-azure-helpers v0.64.0
	github.com/hashicorp/pandora/tools/sdk v0.0.0-00010101000000-000000000000
)

require (
	github.com/hashicorp/go-cleanhttp v0.5.2 // indirect
	github.com/hashicorp/go-retryablehttp v0.7.5 // indirect
)

replace github.com/hashicorp/pandora/tools/sdk => ../sdk
