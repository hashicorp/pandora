# Tool: Terraform Generator

This tool generates a Terraform SDK using the information available in the Data API.

Essentially this tool retrieves a list of Resource Manager Services from the Data API, determines which should be generated - and then iterates over each (Generation) Stage to output the files as needed.

For example, when generating the service `Load Test` the following files will be updated:

```
 $ tree
.
├── ...
├── internal
│   ├── ...
│   ├── clients
│   │   ├── ...
│   │   ├── client_gen.go
│   │   └── ...
│   ├── ...
│   ├── provider
│   │   ├── ...
│   │   ├── services_gen.go
│   │   └── ...
│   ├── services
│   │   ├── ...
│   │   ├── loadtestservice
│   │   │   ├── client
│   │   │   │   └── client_gen.go
│   │   │   ├── load_test_resource_gen.go
│   │   │   ├── load_test_resource_gen_test.go
│   │   │   ├── registration.go
│   │   │   └── registration_gen.go
│   │   └── ...
└── website
    ├── ...
    └── docs
        ├── ...
        └── r
            ├── load_test.html.markdown
            └── ...
```

To summarize these files::

* `./internal/clients/client_gen.go` defines all of the SDK Clients which should be auto-registered.
* `./internal/provider/services_gen.go` defines all of the Service Registrations which should be auto-registered.
* `./internal/services/{serviceName}/client/client_gen.go` - builds up the SDK Client associated with this Service.
* `./internal/services/{serviceName}/{resourceName}_resource_gen.go` - contains the generated Terraform Resource.
* `./internal/services/{serviceName}/{resourceName}_resource_gen_test.go` - contains the generated Acceptance Tests for this Terraform Resource.
* `./internal/services/{serviceName}/registration_gen.go` - defines all the generated Terraform Resources which should be auto-registered.
* `./website/docs/r/{resourceName}.html.markdown` - the generated documentation associated with this resource.

Each (Generation) Stage has an associated Templater, meaning that each Stage can be unit tested as required.

## Getting Started

Ensure [the Data API](../../data) is launched and then:

```sh
$ make tools
$ make run
```

By default, the generated code will be output to your desktop (`~/Desktop/generated-tf-dev`), although this can be overwritten using the command-line flags as shown below.

## Options

The `generator-terraform` tool supports a number of command-line arguments:

* `--data-api=http://some-uri:2022` - specifies the URI for the Data API (defaults to `http://localhost:5000`).
* `--output-dir=/some/custom/path` - specifies the directory where the generated Terraform Resources should be output (defaults to `~/Desktop/generated-tf-dev`).
* `--services=Service1,Service2` - generates Terraform Resources for only the specified Services (for expediency) - the Service Names coming from the `name` field [within the Configuration File that defines which Service should be imported](`../../config/resource-manager.hcl`).

The `make` task used above doesn't currently support these arguments, but you can specify these by calling the `generator-terraform` tool on the command line, for example:

```shell
go build . && ./generator-terraform generate --output-dir=/path/to/github.com/hashicorp/terraform-provider-azurerm -services=ManagedIdentity
```
