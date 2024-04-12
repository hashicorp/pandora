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

var _ Stage = TerraformMappingsDefinitionStage{}

type TerraformMappingsDefinitionStage struct {
	// ResourceDetails specifies the Terraform Resource Definition.
	ResourceDetails models.TerraformResourceDefinition

	// ServiceName specifies the name of the Service.
	ServiceName string
}

func (g TerraformMappingsDefinitionStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	mapped, err := transforms.MapTerraformSchemaMappingsToRepository(g.ResourceDetails.Mappings)
	if err != nil {
		return fmt.Errorf("building Mappings for the Terraform Resource %q: %+v", g.ResourceDetails.ResourceName, err)
	}

	path := filepath.Join(g.ServiceName, "Terraform", fmt.Sprintf("%s-Resource-Mappings.json", g.ResourceDetails.ResourceName))
	logger.Trace(fmt.Sprintf("Staging Terraform Mappings to %q", path))
	if err := input.Stage(path, *mapped); err != nil {
		return fmt.Errorf("staging Terraform Mappings to %q: %+v", path, err)
	}

	return nil
}

func (g TerraformMappingsDefinitionStage) Name() string {
	return "Terraform Mappings Definition"
}
