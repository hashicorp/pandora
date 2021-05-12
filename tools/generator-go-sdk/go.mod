module github.com/hashicorp/pandora/tools/generator-go-sdk

go 1.16

require (
	github.com/Azure/go-autorest/autorest v0.11.18 // indirect
	github.com/hashicorp/pandora/tools/sdk v0.0.0-00010101000000-000000000000
)

replace github.com/hashicorp/pandora/tools/sdk => ../sdk
