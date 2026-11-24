module github.com/hashicorp/pandora/tools/data-api-repository

go 1.26.11

require (
	github.com/hashicorp/go-azure-helpers v0.82.0
	github.com/hashicorp/go-hclog v1.6.3
	github.com/hashicorp/pandora/tools/data-api-sdk v0.0.0-00010101000000-000000000000
)

require (
	github.com/fatih/color v1.19.0 // indirect
	github.com/mattn/go-colorable v0.1.16 // indirect
	github.com/mattn/go-isatty v0.0.24 // indirect
	golang.org/x/sys v0.50.0 // indirect
)

replace github.com/hashicorp/pandora/tools/data-api-sdk => ../data-api-sdk
