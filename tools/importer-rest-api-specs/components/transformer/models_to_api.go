// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transformer

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

func ApiResourceFromModelResource(schema importerModels.AzureApiResource) (*services.Resource, error) {
	return &services.Resource{
		Operations: resourcemanager.ApiOperationDetails{
			Operations: schema.Operations,
		},
		Schema: resourcemanager.ApiSchemaDetails{
			Constants:   schema.Constants,
			Models:      schema.Models,
			ResourceIds: schema.ResourceIds,
		},
	}, nil
}
