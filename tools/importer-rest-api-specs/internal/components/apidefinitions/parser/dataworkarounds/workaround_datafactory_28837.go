// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundDataFactory28837{}

// workaroundDataFactory28837 converts the ServicePrincipalCredentialTypeProperties.ServicePrincipalId and Tenant values to strings as they are exposed directly as such in the azurerm_data_factory_credential_service_principal resource
// the issue number referred to here is on hashicorp/terraform-provider-azurerm rather than the api-specs as this is a limitation on Go / our implementation of the resources.
type workaroundDataFactory28837 struct {
}

func (workaroundDataFactory28837) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "DataFactory" && apiVersion.APIVersion == "2018-06-01"
}

func (workaroundDataFactory28837) Name() string {
	return "DataFactory / 28837"
}

func (workaroundDataFactory28837) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Credentials"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Credentials` but didn't get one")
	}

	// Exposed directly, so the following values are strings to avoid casting to / from `interface{}`
	model, ok := resource.Models["ServicePrincipalCredentialTypeProperties"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model `ServicePrincipalCredentialTypeProperties`")
	}

	field, ok := model.Fields["ServicePrincipalId"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Field `ServicePrincipalId`")
	}

	field.ObjectDefinition.Type = sdkModels.StringSDKObjectDefinitionType

	model.Fields["ServicePrincipalId"] = field

	field, ok = model.Fields["Tenant"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Field `Tenant`")
	}

	field.ObjectDefinition.Type = sdkModels.StringSDKObjectDefinitionType

	model.Fields["Tenant"] = field

	resource.Models["ServicePrincipalCredentialTypeProperties"] = model

	model, ok = resource.Models["AzureKeyVaultSecretReference"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model `AzureKeyVaultSecretReference`")
	}

	field, ok = model.Fields["SecretName"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Field `SecretName`")
	}

	field.ObjectDefinition.Type = sdkModels.StringSDKObjectDefinitionType

	model.Fields["SecretName"] = field

	field, ok = model.Fields["SecretVersion"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Field `SecretVersion`")
	}

	field.ObjectDefinition.Type = sdkModels.StringSDKObjectDefinitionType

	model.Fields["SecretVersion"] = field

	resource.Models["AzureKeyVaultSecretReference"] = model

	input.Resources["Credentials"] = resource

	return &input, nil
}
