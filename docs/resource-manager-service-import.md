## Guide: Importing a new Resource Manager Service (or a new API Version for an existing Service)

Importing a new Service (or a new API Version for an existing Service) involves updating the Resource Manager configuration file and then sending a Pull Request.

The Resource Manager configuration file can be found [at `./config/resource-manager.hcl`](https://github.com/hashicorp/pandora/blob/main/config/resource-manager.hcl).

In short, this file contains a list of Services (defined as `service` blocks) and the API Versions they support (and, optionally, any API Versions which should be ignored when the version-bumper runs).

An example Service can be seen below:

```hcl
service "analysisservices" {
  name      = "AnalysisServices"
  available = ["2017-08-01"]
  # Optional
  # ignore = []
}
```

Those properties are:

* The Label (`analysisservices`) - (Required) - The name of the Directory containing the Service within the Swagger `specifications` directory.
* `name` - (Required) - A Normalized Version of the Service Name (generally, TitleCased with no spaces) used to uniquely identify this service.
* `available` - (Required) - A list of API Versions which should be Imported into Pandora's Data Format.
* `ignore` - (Optional) - A list of API Versions which should be Ignored by the `version-bumper` tool (see the main Readme for info) when automatically adding new API Versions for this Service.

As such to import the Service `MSI` with API Version `2018-11-30` ([from this Swagger Definition](https://github.com/Azure/azure-rest-api-specs/tree/main/specification/msi/resource-manager/Microsoft.ManagedIdentity/stable/2018-11-30)) you'd need to add:

```hcl
service "msi" {
  name      = "ManagedServiceIdentity"
  available = ["2018-11-30"]
}
```

Multiple API Versions can be specified if necessary, for example:

```hcl
service "msi" {
  name      = "ManagedServiceIdentity"
  available = ["2018-11-30", "2021-09-30-preview"]
}
```

> **Note:** The Version Bumper tool will auto reformat the Resource Manager configuration file to ensure it's ordered alphabetically (and old -> new for API versions) - you can avoid unnecessary churn by ordering the services alphabetically.

Once the Resource Manager configuration has been updated - please send a Pull Request to this repository.

See ["How does this work?" in the main README](../README.md) for information on what happens when that Pull Request is merged.
