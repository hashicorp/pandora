module github.com/hashicorp/pandora/tools/generator-go-sdk

go 1.20

require (
	github.com/hashicorp/go-azure-helpers v0.55.0
	github.com/hashicorp/pandora/tools/sdk v0.0.0-00010101000000-000000000000
)

replace github.com/hashicorp/pandora/tools/sdk => ../sdk
