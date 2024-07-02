## `./internal/components/terraform/identification`

This package is used to Identify any Terraform Resources based on the configuration files within `./config/resources`.

It takes a Service and the set of known configuration files, and tries to identify and build-up the initial Resource representation based on it.

Assuming the following configuration file as an example:

```hcl
service "DevCenter" {
  terraform_package = "devcenter"

  api "2023-04-01" {
    package "DevCenters" {
      definition "dev_center" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devCenters/{devCenterName}"
        display_name = "Dev Center"
        website_subcategory = "Dev Center"
        description = "Manages a Dev Center"
      }
    }
  }
}
```

We iterate over the Resources defined within the configuration files, and assuming the Resource is for the current Service, we load information for the APIVersion/APIResource.

Based on that, we then try and determine how this Resource could be built, by looking at the Operations which work on the Resource ID, ultimately we're looking for:

1. A `GET` method which can be used for the `Read` functionality within Terraform.
2. A `DELETE` method which can be used for the `Delete` functionality within Terraform.
3. A `POST` or a `PUT` method which takes a Request Object which can be used for the `Create` functionality within Terraform.
4. (Optionally) A `PATCH` method which takes a Request Object which can be used for the `Update` functionality within Terraform.
5. (Optionally, should a `PATCH` method not exist) Determining whether we can reuse the `Create` function for the Update functionality too.

> **Note:** Resources are only generated when a `Create`, `Delete` and `Read` method are available.

A "Work-in-Progress" Resource is then built from this, allowing the remaining Stages to process/populate this Resource.
