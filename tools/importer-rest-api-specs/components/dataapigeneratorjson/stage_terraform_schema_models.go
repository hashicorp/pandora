// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

var _ generatorStage = generateTerraformSchemaModelsStage{}

type generateTerraformSchemaModelsStage struct {
	// serviceName specifies the name of the Service.
	serviceName string

	// resourceDetails specifies the Terraform Resource Definition.
	resourceDetails models.TerraformResourceDefinition
}

func (g generateTerraformSchemaModelsStage) generate(input *helpers.FileSystem) error {
	logging.Log.Debug("Processing Terraform Schema Models..")
	for schemaModelName, schemaModel := range g.resourceDetails.SchemaModels {
		logging.Log.Trace(fmt.Sprintf("Processing Terraform Schema Model %q", schemaModelName))
		mapped, err := transforms.MapTerraformSchemaModelToRepository(schemaModelName, schemaModel)
		if err != nil {
			return fmt.Errorf("mapping Terraform Schema Model %q: %+v", schemaModelName, err)
		}

		fileName := fmt.Sprintf("%s-Resource-Schema-%s.json", g.resourceDetails.ResourceName, strings.TrimPrefix(schemaModelName, g.resourceDetails.SchemaModelName))
		if schemaModelName == g.resourceDetails.SchemaModelName {
			// Special-case the Resources Model so that it's easier to find the Resource's Schema quickly
			fileName = fmt.Sprintf("%s-Resource-Schema.json", g.resourceDetails.ResourceName)
		}
		path := filepath.Join(g.serviceName, "Terraform", fileName)
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Terraform Schema Model %q at %q: %+v", schemaModelName, path, err)
		}
		logging.Log.Trace("Processed Schema Model %q.", schemaModelName)
	}

	return nil
}

func (g generateTerraformSchemaModelsStage) name() string {
	return "Terraform Schema Models"
}
