// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
)

var _ generatorStage = generateServiceDefinitionStage{}

type generateServiceDefinitionStage struct {
	// serviceName specifies the name of the Service.
	serviceName string

	// resourceProvider optionally specifies the Azure Resource Provider related to this Service.
	// This will only be set for Azure Resource Manager related Services.
	resourceProvider *string

	// shouldGenerate specifies whether this Service should be marked as available for generation.
	shouldGenerate bool

	// terraformDefinition optionally specifies the Terraform Definition for this Service.
	terraformDefinition *models.TerraformDefinition
}

func (g generateServiceDefinitionStage) generate(input *fileSystem, logger hclog.Logger) error {
	serviceDefinition, err := transforms.MapServiceDefinitionToRepository(g.serviceName, g.resourceProvider, g.terraformDefinition)
	if err != nil {
		return fmt.Errorf("mapping Service Definition for %q: %+v", g.serviceName, err)
	}

	path := filepath.Join(g.serviceName, "ServiceDefinition.json")
	if err := input.stage(path, *serviceDefinition); err != nil {
		return fmt.Errorf("staging ServiceDefinition to %q: %+v", path, err)
	}

	return nil
}

func (g generateServiceDefinitionStage) name() string {
	return "Service Definition"
}
