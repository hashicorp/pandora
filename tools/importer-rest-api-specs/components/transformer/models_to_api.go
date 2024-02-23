// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transformer

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

func ApiResourceFromModelResource(schema importerModels.AzureApiResource) (*services.Resource, error) {
	operations, err := apiOperationsFromModelOperations(schema.Operations)
	if err != nil {
		return nil, fmt.Errorf("converting Model Operation Details into Data API Operation Details: %+v", err)
	}

	models, err := apiModelsFromModelModels(schema.Models, schema.Constants)
	if err != nil {
		return nil, fmt.Errorf("converting Model Constant Details into Data API Constant Details: %+v", err)
	}

	return &services.Resource{
		Operations: resourcemanager.ApiOperationDetails{
			Operations: *operations,
		},
		Schema: resourcemanager.ApiSchemaDetails{
			Constants:   schema.Constants,
			Models:      *models,
			ResourceIds: schema.ResourceIds,
		},
	}, nil
}

func apiModelsFromModelModels(inputModels map[string]importerModels.ModelDetails, inputConstants map[string]models.SDKConstant) (*map[string]resourcemanager.ModelDetails, error) {
	out := make(map[string]resourcemanager.ModelDetails)

	for k, v := range inputModels {
		fields, err := apiFieldsFromModelFields(v.Fields, v, inputConstants)
		if err != nil {
			return nil, fmt.Errorf("mapping fields for model %q: %+v", k, err)
		}
		out[k] = resourcemanager.ModelDetails{
			Fields:         *fields,
			ParentTypeName: v.ParentTypeName,
			TypeHintIn:     v.TypeHintIn,
			TypeHintValue:  v.TypeHintValue,
			// TODO: work out what to do with description
		}
	}

	return &out, nil
}

func apiFieldsFromModelFields(input map[string]importerModels.FieldDetails, model importerModels.ModelDetails, inputConstants map[string]models.SDKConstant) (*map[string]resourcemanager.FieldDetails, error) {
	out := make(map[string]resourcemanager.FieldDetails)

	for k, v := range input {
		details := resourcemanager.FieldDetails{
			Default:          nil,
			ForceNew:         false,
			IsTypeHint:       model.TypeHintIn != nil && *model.TypeHintIn == k,
			JsonName:         v.JsonName,
			ObjectDefinition: v.ObjectDefinition,
			Optional:         !v.Required,
			Required:         v.Required,
			// TODO: support validation
			Validation:  nil,
			Description: v.Description,
		}

		if v.ReadOnly {
			details.Required = false
			details.Optional = false
		}

		if details.ObjectDefinition.Type == models.DateTimeSDKObjectDefinitionType {
			dateFormat := resourcemanager.RFC3339
			details.DateFormat = &dateFormat
		}

		if details.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
			constantName := *details.ObjectDefinition.ReferenceName
			constant, isConstant := inputConstants[constantName]
			if isConstant {
				details.Validation = validationForConstant(constant)
			}
		}

		out[k] = details
	}

	return &out, nil
}

func validationForConstant(input models.SDKConstant) *resourcemanager.FieldValidationDetails {
	vals := make([]interface{}, 0)
	for _, v := range input.Values {
		vals = append(vals, v)
	}

	return &resourcemanager.FieldValidationDetails{
		Type:   resourcemanager.RangeValidation,
		Values: &vals,
	}
}

func apiOperationsFromModelOperations(input map[string]importerModels.OperationDetails) (*map[string]resourcemanager.ApiOperation, error) {
	out := make(map[string]resourcemanager.ApiOperation)

	for k, v := range input {
		out[k] = resourcemanager.ApiOperation{
			ContentType:                      &v.ContentType,
			ExpectedStatusCodes:              v.ExpectedStatusCodes,
			LongRunning:                      v.LongRunning,
			Method:                           v.Method,
			RequestObject:                    v.RequestObject,
			ResourceIdName:                   v.ResourceIdName,
			ResponseObject:                   v.ResponseObject,
			FieldContainingPaginationDetails: v.FieldContainingPaginationDetails,
			Options:                          v.Options,
			UriSuffix:                        v.UriSuffix,
		}
	}

	return &out, nil
}
