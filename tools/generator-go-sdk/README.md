# Tool: Go SDK Generator

This tool generates a Go SDK using the information available in the Data API.

Essentially this tool retrieves a list of Resource Manager Services from the Data API, determines which should be generated - and then iterates over each (Generation) Stage to output the files as needed - into a folder structure by Service and then API version:

```
$ tree resource-manager
├── aad
│   ├── 2020-01-01
│   │   ├── client.go
│   │   ├── domainservices
│   │   │   ├── README.md
│   │   │   ├── client.go
│   │   │   ├── ...
│   │   │   ├── id_domainservice.go
│   │   │   ├── id_domainservice_test.go
│   │   │   ├── method_create_autorest.go
│   │   │   ├── ...
│   │   │   ├── method_update_autorest.go
│   │   │   ├── model_containeraccount.go
│   │   │   ├── ...
│   │   │   ├── predicates.go
│   │   │   └── version.go
│   │   └── ...
│   ├── 2021-03-01
│   │   ├── client.go
│   │   ├── domainservices
│   │   │   ├── README.md
│   │   │   └── ...
│   │   └── ...
│   └── 2021-05-01
│   │   ├── client.go
│   │   ├── domainservices
│   │   │   ├── README.md
│   │   │   └── ...
│   │   └── ...
├── appconfiguration
│   └── 2020-06-01
│       ├── configurationstores
│       │   ├── client.go
│       │   ├── ...
```

Each (Generation) Stage has an associated Templater, meaning that each Stage can be unit tested as required.

## Getting Started

Ensure [the Data API](../../data) is launched and then:

```sh
$ make tools
$ make run
```

By default, the generated Go SDK will be output to your desktop (`~/Desktop/generated-sdk-dev`), although this can be overwritten using the command-line flags as shown below.

## Options

The `generator-go-sdk` tool supports a number of command-line arguments:

* `--data-api=http://some-uri:2022` - specifies the URI for the Data API (defaults to `http://localhost:5000`).
* `--output-dir=/some/custom/path` - specifies the directory where the Go SDK should be generated (defaults to `~/Desktop/generated-sdk-dev`).
* `--services=Service1,Service2` - generates the Go SDK for only the specified Services for expediency - the Service Names coming from the `name` field [within the Configuration File that defines which Service should be imported](`../../config/resource-manager.hcl`).

The `make` task used above doesn't currently support these arguments, but you can specify these by calling the `generator-go-sdk` tool on the command line, for example:

```shell
$ go build . && ./generator-go-sdk -output-dir=/some/path/to/github.com/hashicorp/go-azure-sdk -services=ContainerService
```