// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var optionObjectDefinitionTypes = map[repositories.OptionObjectDefinitionType]models.SDKOperationOptionObjectDefinitionType{
	repositories.BooleanOptionObjectDefinition:       models.BooleanSDKOperationOptionObjectDefinitionType,
	repositories.CsvOptionObjectDefinitionType:       models.CSVSDKOperationOptionObjectDefinitionType,
	repositories.FloatOptionObjectDefinitionType:     models.FloatSDKOperationOptionObjectDefinitionType,
	repositories.IntegerOptionObjectDefinition:       models.IntegerSDKOperationOptionObjectDefinitionType,
	repositories.ListOptionObjectDefinitionType:      models.ListSDKOperationOptionObjectDefinitionType,
	repositories.StringOptionObjectDefinitionType:    models.StringSDKOperationOptionObjectDefinitionType,
	repositories.ReferenceOptionObjectDefinitionType: models.ReferenceSDKOperationOptionObjectDefinitionType,
}

func mapSDKOperationOptionObjectDefinition(input repositories.OptionObjectDefinition) (*models.SDKOperationOptionObjectDefinition, error) {
	objectDefinitionType, ok := optionObjectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for SDKOperationOptionObjectDefinitionType %q", string(input.Type))
	}
	output := models.SDKOperationOptionObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          objectDefinitionType,
	}
	if input.NestedItem != nil {
		nestedItem, err := mapSDKOperationOptionObjectDefinition(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping NestedItem: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	return &output, nil
}
