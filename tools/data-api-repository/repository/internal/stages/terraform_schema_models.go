// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/transforms"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Stage = TerraformSchemaModelsStage{}

type TerraformSchemaModelsStage struct {
	// ResourceDetails specifies the Terraform Resource Definition.
	ResourceDetails sdkModels.TerraformResourceDefinition
}

func (g TerraformSchemaModelsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Processing Terraform Schema Models..")
	for schemaModelName, schemaModel := range g.ResourceDetails.SchemaModels {
		logger.Trace(fmt.Sprintf("Processing Terraform Schema Model %q", schemaModelName))
		mapped, err := transforms.MapTerraformSchemaModelToRepository(schemaModelName, schemaModel)
		if err != nil {
			return fmt.Errorf("mapping Terraform Schema Model %q: %+v", schemaModelName, err)
		}

		fileName := fmt.Sprintf("%s-Resource-Schema-%s.json", g.ResourceDetails.ResourceName, strings.TrimPrefix(schemaModelName, g.ResourceDetails.SchemaModelName))
		if schemaModelName == g.ResourceDetails.SchemaModelName {
			// Special-case the Resources Model so that it's easier to find the Resource's Schema quickly
			fileName = fmt.Sprintf("%s-Resource-Schema.json", g.ResourceDetails.ResourceName)
		}
		path := filepath.Join("Terraform", fileName)
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Terraform Schema Model %q at %q: %+v", schemaModelName, path, err)
		}
		logger.Trace("Processed Schema Model %q.", schemaModelName)
	}

	return nil
}

func (g TerraformSchemaModelsStage) Name() string {
	return "Terraform Schema Models"
}
