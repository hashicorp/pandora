// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var sdkOperationOptionObjectDefinitionTypes = map[models.SDKOperationOptionObjectDefinitionType]string{
	models.BooleanSDKOperationOptionObjectDefinitionType: "bool",
	models.FloatSDKOperationOptionObjectDefinitionType:   "float64",
	models.IntegerSDKOperationOptionObjectDefinitionType: "int64",
	models.StringSDKOperationOptionObjectDefinitionType:  "string",
}

// GolangTypeForSDKOperationOptionObjectDefinition returns the Golang Type for the specified SDKOperationOptionObjectDefinition.
func GolangTypeForSDKOperationOptionObjectDefinition(input models.SDKOperationOptionObjectDefinition) (*string, error) {
	if input.Type == models.CSVSDKOperationOptionObjectDefinitionType {
		// this is sufficient for now
		return pointer.To("string"), nil
	}

	if input.Type == models.ListSDKOperationOptionObjectDefinitionType {
		if input.NestedItem == nil {
			return nil, fmt.Errorf("a List must contain a NestedItem but got nil")
		}

		if input.NestedItem.Type == models.CSVSDKOperationOptionObjectDefinitionType {
			// there's no examples of this right now, so we can ignore this for the moment
			return nil, fmt.Errorf("a List cannot contain a nested CSV")
		}

		if input.NestedItem.Type == models.ListSDKOperationOptionObjectDefinitionType {
			// there's no examples of this right now, so we can ignore this for the moment
			return nil, fmt.Errorf("a List cannot contain a nested List")
		}

		innerType, err := GolangTypeForSDKOperationOptionObjectDefinition(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("determining Type for NestedItem: %+v", err)
		}

		output := fmt.Sprintf("[]%s", *innerType)
		return pointer.To(output), nil
	}

	if input.Type == models.ReferenceSDKOperationOptionObjectDefinitionType {
		return input.ReferenceName, nil
	}

	sdkOperationOptionObjectDefinitionType, ok := sdkOperationOptionObjectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing type for SDKOperationOptionObjectDefinition %q", string(input.Type))
	}

	return pointer.To(sdkOperationOptionObjectDefinitionType), nil
}
