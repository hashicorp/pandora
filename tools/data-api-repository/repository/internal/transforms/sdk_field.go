// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapSDKFieldFromRepository(input repositoryModels.ModelField) (*sdkModels.SDKField, error) {
	objectDefinition, err := mapSDKFieldObjectDefinitionFromRepository(input.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("mapping the SDKObjectDefinition for Field %q: %+v", input.Name, err)
	}

	output := sdkModels.SDKField{
		ContainsDiscriminatedValue: input.ContainsDiscriminatedTypeValue,
		DateFormat:                 nil,
		Description:                pointer.From(input.Description),
		JsonName:                   input.JsonName,
		ObjectDefinition:           *objectDefinition,
		Optional:                   input.Optional,
		ReadOnly:                   input.ReadOnly,
		Required:                   input.Required,
		Sensitive:                  input.Sensitive,
	}

	if input.DateFormat != nil {
		dateFormat, err := mapSDKDateFormatFromRepository(*input.DateFormat)
		if err != nil {
			return nil, fmt.Errorf("mapping the SDK Date Format: %+v", err)
		}

		output.DateFormat = dateFormat
	}

	return &output, nil
}

func mapSDKFieldToRepository(fieldName string, input sdkModels.SDKField, isTypeHint bool, knownData helpers.KnownData) (*repositoryModels.ModelField, error) {
	// TODO: thread through logging
	objectDefinition, err := mapSDKFieldObjectDefinitionToRepository(input.ObjectDefinition, knownData)
	if err != nil {
		return nil, fmt.Errorf("mapping the ObjectDefinition for field %q: %+v", fieldName, err)
	}

	output := repositoryModels.ModelField{
		ContainsDiscriminatedTypeValue: isTypeHint,
		DateFormat:                     nil,
		Description:                    nil,
		// TODO this can be uncommented when #3325 has been fixed
		// Description: input.Description,
		JsonName:         input.JsonName,
		Name:             fieldName,
		ObjectDefinition: *objectDefinition,
		Optional:         input.Optional,
		ReadOnly:         input.ReadOnly,
		Required:         input.Required,
		Sensitive:        input.Sensitive,
	}
	if input.DateFormat != nil {
		dateFormat, err := mapSDKDateFormatToRepository(*input.DateFormat)
		if err != nil {
			return nil, fmt.Errorf("mapping SDK Date Format: %+v", *input.DateFormat)
		}
		output.DateFormat = dateFormat
	}

	return &output, nil
}
