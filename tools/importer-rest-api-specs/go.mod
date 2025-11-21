module github.com/hashicorp/pandora/tools/importer-rest-api-specs

go 1.24.5

require (
	github.com/davecgh/go-spew v1.1.1
	github.com/gertd/go-pluralize v0.2.1
	github.com/go-git/go-git/v5 v5.13.0
	github.com/go-openapi/analysis v0.20.1
	github.com/go-openapi/loads v0.20.2
	github.com/go-openapi/spec v0.20.3
	github.com/hashicorp/go-azure-helpers v0.69.0
	github.com/hashicorp/go-hclog v1.6.3
	github.com/hashicorp/hcl/v2 v2.16.2
	github.com/hashicorp/pandora/tools/data-api-repository v0.0.0-00010101000000-000000000000
	github.com/hashicorp/pandora/tools/data-api-sdk v0.0.0-00010101000000-000000000000
	github.com/hashicorp/pandora/tools/sdk v0.0.0-00010101000000-000000000000
	github.com/mitchellh/cli v1.1.4
	github.com/zclconf/go-cty v1.13.1
	golang.org/x/text v0.31.0
)

require (
	dario.cat/mergo v1.0.0 // indirect
	github.com/Masterminds/goutils v1.1.1 // indirect
	github.com/Masterminds/semver/v3 v3.1.1 // indirect
	github.com/Masterminds/sprig/v3 v3.2.0 // indirect
	github.com/Microsoft/go-winio v0.6.1 // indirect
	github.com/ProtonMail/go-crypto v1.1.3 // indirect
	github.com/agext/levenshtein v1.2.2 // indirect
	github.com/apparentlymart/go-textseg/v13 v13.0.0 // indirect
	github.com/armon/go-radix v0.0.0-20180808171621-7fddfc383310 // indirect
	github.com/asaskevich/govalidator v0.0.0-20200907205600-7a23bdc65eef // indirect
	github.com/bgentry/speakeasy v0.1.0 // indirect
	github.com/cloudflare/circl v1.3.7 // indirect
	github.com/cyphar/filepath-securejoin v0.2.5 // indirect
	github.com/emirpasic/gods v1.18.1 // indirect
	github.com/fatih/color v1.16.0 // indirect
	github.com/go-git/gcfg v1.5.1-0.20230307220236-3a3c6141e376 // indirect
	github.com/go-git/go-billy/v5 v5.6.0 // indirect
	github.com/go-openapi/errors v0.19.9 // indirect
	github.com/go-openapi/jsonpointer v0.21.0 // indirect
	github.com/go-openapi/jsonreference v0.21.0 // indirect
	github.com/go-openapi/strfmt v0.20.0 // indirect
	github.com/go-openapi/swag v0.23.0 // indirect
	github.com/golang/groupcache v0.0.0-20210331224755-41bb18bfe9da // indirect
	github.com/google/go-cmp v0.6.0 // indirect
	github.com/google/uuid v1.1.2 // indirect
	github.com/hashicorp/errwrap v1.1.0 // indirect
	github.com/hashicorp/go-multierror v1.1.1 // indirect
	github.com/huandu/xstrings v1.3.2 // indirect
	github.com/imdario/mergo v0.3.12 // indirect
	github.com/jbenet/go-context v0.0.0-20150711004518-d14ea06fba99 // indirect
	github.com/josharian/intern v1.0.0 // indirect
	github.com/kevinburke/ssh_config v1.2.0 // indirect
	github.com/mailru/easyjson v0.7.7 // indirect
	github.com/mattn/go-colorable v0.1.13 // indirect
	github.com/mattn/go-isatty v0.0.20 // indirect
	github.com/mitchellh/copystructure v1.2.0 // indirect
	github.com/mitchellh/go-wordwrap v1.0.0 // indirect
	github.com/mitchellh/mapstructure v1.5.0 // indirect
	github.com/mitchellh/reflectwalk v1.0.2 // indirect
	github.com/pjbgf/sha1cd v0.3.0 // indirect
	github.com/posener/complete v1.1.1 // indirect
	github.com/sergi/go-diff v1.3.2-0.20230802210424-5b0b94c5c0d3 // indirect
	github.com/shopspring/decimal v1.2.0 // indirect
	github.com/skeema/knownhosts v1.3.0 // indirect
	github.com/spf13/cast v1.3.1 // indirect
	github.com/xanzy/ssh-agent v0.3.3 // indirect
	go.mongodb.org/mongo-driver v1.10.3 // indirect
	golang.org/x/crypto v0.45.0 // indirect
	golang.org/x/mod v0.29.0 // indirect
	golang.org/x/net v0.47.0 // indirect
	golang.org/x/sync v0.18.0 // indirect
	golang.org/x/sys v0.38.0 // indirect
	golang.org/x/tools v0.38.0 // indirect
	gopkg.in/warnings.v0 v0.1.2 // indirect
	gopkg.in/yaml.v3 v3.0.1 // indirect
)

replace github.com/hashicorp/pandora/tools/data-api-repository => ../data-api-repository

replace github.com/hashicorp/pandora/tools/data-api-sdk => ../data-api-sdk

replace github.com/hashicorp/pandora/tools/sdk => ../sdk

replace github.com/go-openapi/analysis v0.20.1 => github.com/jackofallops/analysis v0.20.2-0.20210705135157-888aa8dbc8e5

replace github.com/go-openapi/jsonreference v0.19.5 => github.com/stephybun/jsonreference v0.21.1-0.20241001092726-f8a8f352cb85

replace github.com/go-openapi/jsonreference v0.21.0 => github.com/stephybun/jsonreference v0.21.1-0.20241001092726-f8a8f352cb85

replace github.com/go-openapi/spec v0.20.3 => github.com/stephybun/spec v0.21.1-0.20241001093718-b6a387937386
