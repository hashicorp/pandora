// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transformer

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func ApiResourceFromModelResource(schema importerModels.AzureApiResource) (*models.APIResource, error) {
	return &models.APIResource{
		Operations:  schema.Operations,
		Constants:   schema.Constants,
		Models:      schema.Models,
		ResourceIDs: schema.ResourceIds,
	}, nil
}
