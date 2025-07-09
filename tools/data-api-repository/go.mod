module github.com/hashicorp/pandora/tools/data-api-repository

require (
	github.com/hashicorp/go-azure-helpers v0.66.2
	github.com/hashicorp/go-hclog v1.6.3
	github.com/hashicorp/pandora/tools/data-api-sdk v0.0.0-00010101000000-000000000000
)

require (
	github.com/fatih/color v1.16.0 // indirect
	github.com/mattn/go-colorable v0.1.13 // indirect
	github.com/mattn/go-isatty v0.0.20 // indirect
	golang.org/x/sys v0.33.0 // indirect
)

replace github.com/hashicorp/pandora/tools/data-api-sdk => ../data-api-sdk

go 1.23.10
