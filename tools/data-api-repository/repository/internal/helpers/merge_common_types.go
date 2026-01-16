// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// MergeCommonTypes merges two sets of Common Types, this is to allow for multiple SourceDataOrigins
// to contain CommonTypes (for example, an imported set of data with overrides from handwritten data)
func MergeCommonTypes(first, second sdkModels.CommonTypes) (*sdkModels.CommonTypes, error) {
	output := sdkModels.CommonTypes{
		Constants: first.Constants,
		Models:    second.Models,
	}

	for key, value := range second.Constants {
		if _, exists := output.Constants[key]; exists {
			return nil, fmt.Errorf("a duplicate Common Type Constant %q was found", key)
		}
		output.Constants[key] = value
	}

	for key, value := range second.Models {
		if _, exists := output.Models[key]; exists {
			return nil, fmt.Errorf("a duplicate Common Type Model %q was found", key)
		}
		output.Models[key] = value
	}

	return &output, nil
}
