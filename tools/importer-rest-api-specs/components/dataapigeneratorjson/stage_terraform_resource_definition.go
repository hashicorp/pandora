// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

var _ generatorStage = generateTerraformResourceDefinitionStage{}

type generateTerraformResourceDefinitionStage struct {
	// serviceName specifies the name of the Service.
	serviceName string

	// resourceDetails specifies the Terraform Resource Definition.
	resourceDetails models.TerraformResourceDefinition

	// resourceLabel specifies the Label for this Terraform Resource without the Provider Prefix.
	// Example: `container_service` rather than `azurerm_container_service`.
	resourceLabel string
}

func (g generateTerraformResourceDefinitionStage) generate(input *fileSystem) error {
	logging.Log.Trace("Mapping Terraform Resource Definition..")
	mapped, err := transforms.MapTerraformResourceDefinitionToRepository(g.resourceLabel, g.resourceDetails)
	if err != nil {
		return fmt.Errorf("building Terraform Resource Definition: %+v", err)
	}

	path := filepath.Join(g.serviceName, "Terraform", fmt.Sprintf("%s-Resource.json", g.resourceDetails.ResourceName))
	logging.Log.Trace(fmt.Sprintf("Staging Terraform Resource Definition at %q", path))
	if err := input.stage(path, mapped); err != nil {
		return fmt.Errorf("staging Terraform Resource Definition at %q: %+v", path, err)
	}

	return nil
}

func (g generateTerraformResourceDefinitionStage) name() string {
	return "Terraform Resource Definition"
}
