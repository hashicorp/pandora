# Tool: Go SDK Generator

This tool generates a Go SDK using the information available in the Data API.

Essentially this tool retrieves a list of Resource Manager Services from the Data API, determines which should be generated - and then iterates over each (Generation) Stage to output the files as needed - into a folder structure by Service and then API version:

```
$ tree
.
├── analysisservices
│   └── 2017-08-01
│       ├── analysisservices
│       │   ├── client.go
│       │   ├── constants.go
│       │   ├── method_serverslistskusfornew_autorest.go
│       │   ├── model_resourcesku.go
│       │   ├── ...
│       │   └── version.go
│       └── servers
│           ├── client.go
│           ├── constants.go
│           ├── id_server.go
│           ├── id_server_test.go
│           ├── method_create_autorest.go
│           ├── method_delete_autorest.go
│           ├── ...
│           ├── model_analysisservicesserver.go
│           ├── ...
│           └── version.go
├── appconfiguration
│   └── 2020-06-01
│       ├── configurationstores
│       │   ├── client.go
│       │   ├── ...
```

Each (Generation) Stage has an associated Templater, meaning that each Stage can be unit tested as required.

## Getting Started

Ensure [the Data API](../../data) is launched and then:

```sh
$ make tools
$ make run
```

The generated SDK will be output to your desktop (for now) - although note this'll change in the future.