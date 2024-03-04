// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

var _ generatorStage = generateTerraformMappingsDefinitionStage{}

type generateTerraformMappingsDefinitionStage struct {
	// serviceName specifies the name of the Service.
	serviceName string

	// resourceDetails specifies the Terraform Resource Definition.
	resourceDetails models.TerraformResourceDefinition
}

func (g generateTerraformMappingsDefinitionStage) generate(input *helpers.FileSystem) error {
	mapped, err := transforms.MapTerraformSchemaMappingsToRepository(g.resourceDetails.Mappings)
	if err != nil {
		return fmt.Errorf("building Mappings for the Terraform Resource %q: %+v", g.resourceDetails.ResourceName, err)
	}

	path := filepath.Join(g.serviceName, "Terraform", fmt.Sprintf("%s-Resource-Mappings.json", g.resourceDetails.ResourceName))
	logging.Log.Trace(fmt.Sprintf("Staging Terraform Mappings to %q", path))
	if err := input.Stage(path, *mapped); err != nil {
		return fmt.Errorf("staging Terraform Mappings to %q: %+v", path, err)
	}

	return nil
}

func (g generateTerraformMappingsDefinitionStage) name() string {
	return "Terraform Mappings Definition"
}
