// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var _ Stage = TerraformMappingsDefinitionStage{}

type TerraformMappingsDefinitionStage struct {
	// ResourceDetails specifies the Terraform Resource Definition.
	ResourceDetails models.TerraformResourceDefinition

	// ServiceName specifies the name of the Service.
	ServiceName string
}

func (g TerraformMappingsDefinitionStage) Generate(input *helpers.FileSystem) error {
	mapped, err := transforms.MapTerraformSchemaMappingsToRepository(g.ResourceDetails.Mappings)
	if err != nil {
		return fmt.Errorf("building Mappings for the Terraform Resource %q: %+v", g.ResourceDetails.ResourceName, err)
	}

	path := filepath.Join(g.ServiceName, "Terraform", fmt.Sprintf("%s-Resource-Mappings.json", g.ResourceDetails.ResourceName))
	logging.Log.Trace(fmt.Sprintf("Staging Terraform Mappings to %q", path))
	if err := input.Stage(path, *mapped); err != nil {
		return fmt.Errorf("staging Terraform Mappings to %q: %+v", path, err)
	}

	return nil
}

func (g TerraformMappingsDefinitionStage) Name() string {
	return "Terraform Mappings Definition"
}
