module github.com/hashicorp/pandora/tools/data-api

go 1.24.5

require (
	github.com/go-chi/chi/v5 v5.2.2
	github.com/go-chi/render v1.0.2
	github.com/hashicorp/go-azure-helpers v0.66.2
	github.com/hashicorp/go-hclog v1.6.3
	github.com/hashicorp/pandora/tools/data-api-repository v0.0.0-00010101000000-000000000000
	github.com/hashicorp/pandora/tools/data-api-sdk v0.0.0-00010101000000-000000000000
	github.com/mitchellh/cli v1.1.5
)

require (
	github.com/Masterminds/goutils v1.1.1 // indirect
	github.com/Masterminds/semver/v3 v3.1.1 // indirect
	github.com/Masterminds/sprig/v3 v3.2.1 // indirect
	github.com/ajg/form v1.5.1 // indirect
	github.com/armon/go-radix v0.0.0-20180808171621-7fddfc383310 // indirect
	github.com/bgentry/speakeasy v0.1.0 // indirect
	github.com/fatih/color v1.16.0 // indirect
	github.com/google/uuid v1.1.2 // indirect
	github.com/hashicorp/errwrap v1.1.0 // indirect
	github.com/hashicorp/go-cleanhttp v0.5.2 // indirect
	github.com/hashicorp/go-multierror v1.1.1 // indirect
	github.com/hashicorp/go-retryablehttp v0.7.8 // indirect
	github.com/huandu/xstrings v1.3.2 // indirect
	github.com/imdario/mergo v0.3.11 // indirect
	github.com/mattn/go-colorable v0.1.13 // indirect
	github.com/mattn/go-isatty v0.0.20 // indirect
	github.com/mitchellh/copystructure v1.2.0 // indirect
	github.com/mitchellh/reflectwalk v1.0.2 // indirect
	github.com/posener/complete v1.1.1 // indirect
	github.com/shopspring/decimal v1.2.0 // indirect
	github.com/spf13/cast v1.3.1 // indirect
	golang.org/x/crypto v0.45.0 // indirect
	golang.org/x/sys v0.38.0 // indirect
)

replace github.com/hashicorp/pandora/tools/sdk => ../sdk

replace github.com/hashicorp/pandora/tools/data-api-repository => ../data-api-repository

replace github.com/hashicorp/pandora/tools/data-api-sdk => ../data-api-sdk
