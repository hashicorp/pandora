package dataworkarounds

import (
	"errors"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundWeb14529{}

// Adds the undocumented `tags` field to the PATCH Certificate model given the `tags` field in the PUT model is ignored
type workaroundWeb14529 struct{}

func (w workaroundWeb14529) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Web" && apiVersion.APIVersion == "2023-12-01"
}

func (w workaroundWeb14529) Name() string {
	return "Web / 14529"
}

func (w workaroundWeb14529) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Certificates"]
	if !ok {
		return nil, errors.New("expected a resource named `Certificates`")
	}

	model, ok := resource.Models["CertificatePatchResource"]
	if !ok {
		return nil, errors.New("expected a model named `CertificatePatchResource`")
	}

	if _, ok := model.Fields["Tags"]; ok {
		return nil, errors.New("expected model `CertificatePatchResource` to not contain a `Tags` field, this workaround should be removed")
	}

	model.Fields["Tags"] = sdkModels.SDKField{
		JsonName: "tags",
		ObjectDefinition: sdkModels.SDKObjectDefinition{
			Type: "Tags",
		},
		Optional: true,
	}
	resource.Models["CertificatePatchResource"] = model
	input.Resources["Certificates"] = resource

	return &input, nil
}
