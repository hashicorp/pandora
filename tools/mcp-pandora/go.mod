module github.com/hashicorp/pandora/tools/mcp-pandora

go 1.26.3

replace github.com/hashicorp/pandora/tools/data-api-repository => ../data-api-repository

replace github.com/hashicorp/pandora/tools/data-api-sdk => ../data-api-sdk

replace github.com/hashicorp/pandora/tools/generator-agent-docs => ../generator-agent-docs

require (
	github.com/hashicorp/go-hclog v1.6.3
	github.com/hashicorp/pandora/tools/data-api-sdk v0.0.0-00010101000000-000000000000
	github.com/hashicorp/pandora/tools/generator-agent-docs v0.0.0-00010101000000-000000000000
	github.com/hexops/gotextdiff v1.0.3
	github.com/metoro-io/mcp-golang v0.16.1
)

require (
	github.com/bahlo/generic-list-go v0.2.0 // indirect
	github.com/buger/jsonparser v1.1.2 // indirect
	github.com/fatih/color v1.18.0 // indirect
	github.com/hashicorp/go-azure-helpers v0.76.2 // indirect
	github.com/hashicorp/pandora/tools/data-api-repository v0.0.0-00010101000000-000000000000 // indirect
	github.com/invopop/jsonschema v0.12.0 // indirect
	github.com/mailru/easyjson v0.7.7 // indirect
	github.com/mattn/go-colorable v0.1.14 // indirect
	github.com/mattn/go-isatty v0.0.20 // indirect
	github.com/pkg/errors v0.9.1 // indirect
	github.com/tidwall/gjson v1.18.0 // indirect
	github.com/tidwall/match v1.1.1 // indirect
	github.com/tidwall/pretty v1.2.1 // indirect
	github.com/tidwall/sjson v1.2.5 // indirect
	github.com/wk8/go-ordered-map/v2 v2.1.8 // indirect
	golang.org/x/sys v0.40.0 // indirect
	gopkg.in/yaml.v3 v3.0.1 // indirect
)
