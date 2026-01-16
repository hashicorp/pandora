// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

// Build works through each of the Resources within the WorkInProgressData and builds up the Tests for these.
func Build(input models.WorkInProgressData) (*models.WorkInProgressData, error) {
	for resourceLabel := range input.Resources {
		resource := input.Resources[resourceLabel]

		logging.Infof("Generating Tests for the Resource %q..", resourceLabel)
		builder := newTestBuilder(input.ProviderPrefix, resourceLabel, resource.Resource)
		tests, err := builder.generateTestsForResource(resource.InputData.TestData)
		if err != nil {
			return nil, fmt.Errorf("generating the tests for Resource %q: %+v", resourceLabel, err)
		}

		resource.Resource.Tests = *tests
		input.Resources[resourceLabel] = resource
	}
	return &input, nil
}
