// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func Build(input models.WorkInProgressData) (*models.WorkInProgressData, error) {
	for resourceLabel := range input.Resources {
		logging.Infof("Building the Schema for Terraform Resource %q..", resourceLabel)
		resource := input.Resources[resourceLabel]

		resource.Resource.SchemaModelName = fmt.Sprintf("%sResource", resource.Resource.ResourceName)
		builder := NewBuilder(resource.APIResource)
		schemaModels, mappings, err := builder.Build(resource.Resource, resource.InputData)
		if err != nil {
			return nil, fmt.Errorf("building the Terraform Schema: %+v", err)
		}

		logging.Tracef("The Resource %q has %d models", resourceLabel, len(schemaModels))
		resource.Resource.SchemaModels = schemaModels
		resource.Resource.Mappings = *mappings

		input.Resources[resourceLabel] = resource
	}

	return &input, nil
}
