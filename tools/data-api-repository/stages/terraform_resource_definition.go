// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/transforms"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Stage = TerraformResourceDefinitionStage{}

type TerraformResourceDefinitionStage struct {
	// ResourceDetails specifies the Terraform Resource Definition.
	ResourceDetails models.TerraformResourceDefinition

	// ResourceLabel specifies the Label for this Terraform Resource without the Provider Prefix.
	// Example: `container_service` rather than `azurerm_container_service`.
	ResourceLabel string

	// ServiceName specifies the name of the Service.
	ServiceName string
}

func (g TerraformResourceDefinitionStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Trace("Mapping Terraform Resource Definition..")
	mapped, err := transforms.MapTerraformResourceDefinitionToRepository(g.ResourceLabel, g.ResourceDetails)
	if err != nil {
		return fmt.Errorf("building Terraform Resource Definition: %+v", err)
	}

	path := filepath.Join(g.ServiceName, "Terraform", fmt.Sprintf("%s-Resource.json", g.ResourceDetails.ResourceName))
	logger.Trace(fmt.Sprintf("Staging Terraform Resource Definition at %q", path))
	if err := input.Stage(path, mapped); err != nil {
		return fmt.Errorf("staging Terraform Resource Definition at %q: %+v", path, err)
	}

	return nil
}

func (g TerraformResourceDefinitionStage) Name() string {
	return "Terraform Resource Definition"
}
