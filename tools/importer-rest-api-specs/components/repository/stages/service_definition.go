// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/repository/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/repository/transforms"
)

var _ Stage = ServiceDefinitionStage{}

type ServiceDefinitionStage struct {
	// ResourceProvider optionally specifies the Azure Resource Provider related to this Service.
	// This will only be set for Azure Resource Manager related Services.
	ResourceProvider *string

	// ServiceName specifies the name of the Service.
	ServiceName string

	// ShouldGenerate specifies whether this Service should be marked as available for generation.
	ShouldGenerate bool

	// TerraformDefinition optionally specifies the Terraform Definition for this Service.
	TerraformDefinition *models.TerraformDefinition
}

func (g ServiceDefinitionStage) Generate(input *helpers.FileSystem) error {
	serviceDefinition, err := transforms.MapServiceDefinitionToRepository(g.ServiceName, g.ResourceProvider, g.TerraformDefinition)
	if err != nil {
		return fmt.Errorf("mapping Service Definition for %q: %+v", g.ServiceName, err)
	}

	path := filepath.Join(g.ServiceName, "ServiceDefinition.json")
	if err := input.Stage(path, *serviceDefinition); err != nil {
		return fmt.Errorf("staging ServiceDefinition to %q: %+v", path, err)
	}

	return nil
}

func (g ServiceDefinitionStage) Name() string {
	return "Service Definition"
}
