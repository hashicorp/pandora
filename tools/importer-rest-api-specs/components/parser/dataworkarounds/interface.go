// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type workaround interface {
	// IsApplicable determines whether this workaround is applicable for this AzureApiDefinition
	IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool

	// Name returns the Service Name and associated Pull Request number
	Name() string

	// Process takes the apiDefinition and applies the Workaround to this AzureApiDefinition
	Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error)
}
