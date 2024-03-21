// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundDataFactory28122{}

// TODO swagger PR link - this be added when the issue has been opened
type workaroundDataFactory28122 struct{}

func (workaroundDataFactory28122) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "DataFactory" && apiDefinition.ApiVersion == "2018-06-01"
}

func (workaroundDataFactory28122) Name() string {
	return "DataFactory / 28122"
}

func (workaroundDataFactory28122) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["Credentials"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource Credentials")
	}

	// add the new discriminated parent type
	managedIdentityCredential, ok := resource.Models["ManagedIdentityCredential"]
	if !ok {
		return nil, fmt.Errorf("couldn't find model ManagedIdentityCredential")
	}

	managedIdentityCredential.DiscriminatedValue = pointer.To("ManagedIdentity")
	managedIdentityCredential.FieldNameContainingDiscriminatedValue = pointer.To("Type")
	managedIdentityCredential.ParentTypeName = pointer.To("Credential")

	if _, ok := resource.Models["ManagedIdentityTypeProperties"]; !ok {
		return nil, fmt.Errorf("couldn't find model ManagedIdentityTypeProperties")
	}

	managedIdentityCredential.Fields["TypeProperties"] = models.SDKField{
		ContainsDiscriminatedValue: false,
		JsonName:                   "typeProperties",
		ObjectDefinition: models.SDKObjectDefinition{
			Type:          models.ReferenceSDKObjectDefinitionType,
			ReferenceName: pointer.To("ManagedIdentityTypeProperties"),
		},
		Required: true,
	}

	resource.Models["ManagedIdentityCredential"] = managedIdentityCredential

	// remove the following models
	modelNames := []string{
		"UserAssignedManagedIdentityCredential",
		"SystemAssignedManagedIdentityCredential",
	}
	for _, modelName := range modelNames {
		if _, ok := resource.Models[modelName]; !ok {
			return nil, fmt.Errorf("couldn't find model %q", modelName)
		}
		delete(resource.Models, modelName)
	}

	apiDefinition.Resources["Credentials"] = resource
	return &apiDefinition, nil
}
