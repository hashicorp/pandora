// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
)

func removeUnusedItems(input map[string]sdkModels.APIResource) map[string]sdkModels.APIResource {
	// temporary glue logic to use the new package without breaking things too much
	apiVersion := sdkModels.APIVersion{
		Resources: input,

		// placeholders
		APIVersion: "2020-01-01",
		Generate:   true,
		Preview:    false,
		Source:     sdkModels.AzureRestAPISpecsSourceDataOrigin,
	}
	apiVersion = cleanup.RemoveUnusedItems(apiVersion)
	return apiVersion.Resources
}
