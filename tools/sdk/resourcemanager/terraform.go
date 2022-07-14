package resourcemanager

import (
	"encoding/json"
	"fmt"
)

type TerraformClient struct {
	Client
}

func (c TerraformClient) Get(input ServiceVersionDetails) (*TerraformDetails, error) {
	endpoint := fmt.Sprintf("%s%s", c.endpoint, input.TerraformUri)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response TerraformDetails
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response, nil
}

type TerraformDetails struct {
	// DataSources is a key (Resource Label) value (TerraformDataSourceDetails) pair of
	// metadata about the Terraform Data Sources which should be generated.
	DataSources map[string]TerraformDataSourceDetails `json:"dataSources"`

	// Resources is a key (Resource Label) value (TerraformResourceDetails) pair of
	// metadata about the Terraform Resources which should be generated.
	Resources map[string]TerraformResourceDetails `json:"resources"`
}

type TerraformDataSourceDetails struct {
	// TODO: populate this
}

type TerraformResourceDetails struct {
	// DisplayName is the human-readable/marketing name for this Resource,
	// for example `Resource Group` or `Virtual Machine`.
	DisplayName string `json:"displayName"`

	// Generate specifies if this Resource should be generated.
	Generate bool `json:"generate"`

	// GenerateDelete controls whether the Delete function should be generated
	// for this Resource.
	GenerateDelete bool `json:"generateDelete"`

	// GenerateSchema controls whether the Schema should be generated for this
	// Resource.
	GenerateSchema bool `json:"generateSchema"`

	// GenerateIdValidation controls whether the ID Validation function should be generated
	// for this Resource.
	GenerateIdValidation bool `json:"generateIdValidation"`

	// Resource specifies the Resource within this API Version within the Service where
	// the details for this Resource can be found.
	Resource string `json:"resource"`

	// ResourceIdName specifies the name of the Resource ID type used for this Resource.
	ResourceIdName string `json:"resourceIdName"`

	// ResourceName specifies the name of this Resource (which can be used as a Go Type Name).
	ResourceName string `json:"resourceName"`
}
