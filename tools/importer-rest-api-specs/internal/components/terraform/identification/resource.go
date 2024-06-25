// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package identification

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func buildResource(resourceIdName string, resourceMetaData definitions.ResourceDefinition, methods methodsForResource) *sdkModels.TerraformResourceDefinition {
	if methods.createMethod == nil || methods.getMethod == nil || methods.deleteMethod == nil {
		return nil
	}

	return &sdkModels.TerraformResourceDefinition{
		APIResource:  resourceMetaData.APIResource,
		APIVersion:   resourceMetaData.APIVersion,
		CreateMethod: *methods.createMethod,
		DeleteMethod: *methods.deleteMethod,
		Documentation: sdkModels.TerraformDocumentationDefinition{
			Category:    resourceMetaData.WebsiteSubcategory,
			Description: resourceMetaData.Description,
		},
		DisplayName:          resourceMetaData.Name,
		Generate:             true,
		GenerateModel:        true,
		GenerateIDValidation: true,
		GenerateSchema:       true,
		Mappings:             sdkModels.TerraformMappingDefinition{},
		ReadMethod:           *methods.getMethod,
		ResourceIDName:       resourceIdName,
		ResourceLabel:        resourceMetaData.ResourceLabel,
		ResourceName:         strings.ReplaceAll(resourceMetaData.Name, " ", ""),
		SchemaModelName:      "",
		SchemaModels:         nil,
		Tests: sdkModels.TerraformResourceTestsDefinition{
			Generate: true,
		},
		UpdateMethod: methods.updateMethod,
	}
}
