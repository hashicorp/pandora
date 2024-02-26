// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

// MapSDKFields maps the FieldDetails type from the repositories package into the V1 API Response Model.
func MapSDKFields(input map[string]repositories.FieldDetails) (*map[string]models.SDKField, error) {
	output := make(map[string]models.SDKField)
	for key, val := range input {
		mapped, err := mapSDKField(val)
		if err != nil {
			return nil, fmt.Errorf("mapping SDKField %q: %+v", key, err)
		}
		output[key] = *mapped
	}
	return &output, nil
}

func mapSDKField(input repositories.FieldDetails) (*models.SDKField, error) {
	objectDefinition, err := mapSDKObjectDefinition(input.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("mapping ObjectDefinition: %+v", err)
	}

	output := models.SDKField{
		ContainsDiscriminatedValue: input.IsTypeHint,
		DateFormat:                 nil,
		Description:                input.Description,
		JsonName:                   input.JsonName,
		ObjectDefinition:           *objectDefinition,
		Optional:                   input.Optional,
		ReadOnly:                   input.ReadOnly,
		Required:                   input.Required,
		Sensitive:                  input.Sensitive,
	}

	if input.DateFormat != nil {
		mappedDateFormat, err := mapSDKDateFormat(*input.DateFormat)
		if err != nil {
			return nil, fmt.Errorf("mapping SDKDateFormat: %+v", err)
		}
		output.DateFormat = mappedDateFormat
	}

	return &output, nil
}
