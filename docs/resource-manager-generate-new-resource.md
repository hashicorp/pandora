## Guide: Generating a new (Resource Manager) Resource

The AzureRM Provider is made up of Services which contain Data Sources and Resources.

### Prerequisites and Known Limitations

As [covered in the overview](README.md), Pandora imports data from the Azure API Definitions into Pandora's API Definition format and normalizes data as it passes through.

At this point in time we support generating Terraform Resources (with some known limitations) once the Service and API version have been imported into Pandora - [see this document for how to do that](resource-manager-service-import.md) which also includes generating the associated Go SDK into [`hashicorp/go-azure-sdk`](https://github.com/hashicorp/go-azure-sdk).

The Terraform Resources which should be imported are [defined within this repository](../config/resources) and the Data Format used to describe these [can be found in this file](../config/resources/README.md).

Some resources cannot, unfortunately, be generated. Reasons include, but are not necessarily limited to:

* Data fidelity - Some API specs simply do not contain enough information to accurately determine how a resource is intended to be used.
* Resource Complexity - Some resources make use of polymorphic properties, called discriminators, these are not (currently) supported.
* Data Errors - Some API Specifications contain errors or breaches of compatibility with the ARM specification. These can typically be addressed by submitting fixes back to the source at https://github.com/Azure/azure-rest-api-specs/issues
