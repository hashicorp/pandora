// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package examples

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/models"
)

func Build(input models.WorkInProgressData) (*models.WorkInProgressData, error) {
	for resourceLabel := range input.Resources {
		resource := input.Resources[resourceLabel]
		exampleUsage, err := exampleUsageForResource(resource.Resource.Tests)
		if err != nil {
			return nil, fmt.Errorf("building Example Usage for %q: %+v", resourceLabel, err)
		}

		resource.Resource.Documentation.ExampleUsageHCL = *exampleUsage
		input.Resources[resourceLabel] = resource
	}

	return &input, nil
}
