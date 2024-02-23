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

	resourceIds, err := apiResourceIdsFromModelResourceIds(schema.ResourceIds)
	if err != nil {
		return nil, fmt.Errorf("converting Model ResourceId Details into Data API ResourceId Details: %+v", err)
	}

	return &services.Resource{
		Operations: resourcemanager.ApiOperationDetails{
			Operations: *operations,
		},
		Schema: resourcemanager.ApiSchemaDetails{
			Constants:   schema.Constants,
			Models:      *models,
			ResourceIds: *resourceIds,
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
		objectDefinition, err := apiObjectDefinitionFromModelObjectDefinition(v.ObjectDefinition, v.CustomFieldType)
		if err != nil {
			return nil, fmt.Errorf("mapping object definition for field %q: %+v", k, err)
		}

		details := resourcemanager.FieldDetails{
			Default:          nil,
			ForceNew:         false,
			IsTypeHint:       model.TypeHintIn != nil && *model.TypeHintIn == k,
			JsonName:         v.JsonName,
			ObjectDefinition: *objectDefinition,
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

		if details.ObjectDefinition.Type == resourcemanager.DateTimeApiObjectDefinitionType {
			dateFormat := resourcemanager.RFC3339
			details.DateFormat = &dateFormat
		}

		if details.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
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

func apiObjectDefinitionFromModelObjectDefinition(input *importerModels.ObjectDefinition, fieldType *importerModels.CustomFieldType) (*resourcemanager.ApiObjectDefinition, error) {
	if fieldType != nil {
		mappings := map[importerModels.CustomFieldType]resourcemanager.ApiObjectDefinitionType{
			importerModels.CustomFieldTypeEdgeZone:                                resourcemanager.EdgeZoneApiObjectDefinitionType,
			importerModels.CustomFieldTypeLocation:                                resourcemanager.LocationApiObjectDefinitionType,
			importerModels.CustomFieldTypeSystemAssignedIdentity:                  resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
			importerModels.CustomFieldTypeSystemAndUserAssignedIdentityList:       resourcemanager.SystemAndUserAssignedIdentityListApiObjectDefinitionType,
			importerModels.CustomFieldTypeSystemAndUserAssignedIdentityMap:        resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
			importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityList: resourcemanager.LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType,
			importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap:  resourcemanager.LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType,
			importerModels.CustomFieldTypeSystemOrUserAssignedIdentityList:        resourcemanager.SystemOrUserAssignedIdentityListApiObjectDefinitionType,
			importerModels.CustomFieldTypeSystemOrUserAssignedIdentityMap:         resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType,
			importerModels.CustomFieldTypeUserAssignedIdentityList:                resourcemanager.UserAssignedIdentityListApiObjectDefinitionType,
			importerModels.CustomFieldTypeUserAssignedIdentityMap:                 resourcemanager.UserAssignedIdentityMapApiObjectDefinitionType,
			importerModels.CustomFieldTypeTags:                                    resourcemanager.TagsApiObjectDefinitionType,
			importerModels.CustomFieldTypeSystemData:                              resourcemanager.SystemData,
			importerModels.CustomFieldTypeZone:                                    resourcemanager.ZoneApiObjectDefinitionType,
			importerModels.CustomFieldTypeZones:                                   resourcemanager.ZonesApiObjectDefinitionType,
		}
		mapping, ok := mappings[*fieldType]
		if !ok {
			return nil, fmt.Errorf("missing mapping for CustomFieldType %q", string(*fieldType))
		}

		return &resourcemanager.ApiObjectDefinition{
			Type: mapping,
		}, nil
	}

	if input == nil {
		return nil, fmt.Errorf("objectDefinition was neither an ObjectDefinition or a CustomFieldType")
	}

	if input.Type == importerModels.ObjectDefinitionCsv {
		nestedItem, err := apiObjectDefinitionFromModelObjectDefinition(input.NestedItem, nil)
		if err != nil {
			return nil, fmt.Errorf("mapping list item: %+v", err)
		}

		return &resourcemanager.ApiObjectDefinition{
			NestedItem:    nestedItem,
			ReferenceName: nil,
			Type:          resourcemanager.CsvApiObjectDefinitionType,
		}, nil
	}

	if input.Type == importerModels.ObjectDefinitionDictionary {
		nestedItem, err := apiObjectDefinitionFromModelObjectDefinition(input.NestedItem, nil)
		if err != nil {
			return nil, fmt.Errorf("mapping dictionary item: %+v", err)
		}

		return &resourcemanager.ApiObjectDefinition{
			NestedItem:    nestedItem,
			ReferenceName: nil,
			Type:          resourcemanager.DictionaryApiObjectDefinitionType,
		}, nil
	}

	if input.Type == importerModels.ObjectDefinitionList {
		nestedItem, err := apiObjectDefinitionFromModelObjectDefinition(input.NestedItem, nil)
		if err != nil {
			return nil, fmt.Errorf("mapping list item: %+v", err)
		}

		return &resourcemanager.ApiObjectDefinition{
			NestedItem:    nestedItem,
			ReferenceName: nil,
			Type:          resourcemanager.ListApiObjectDefinitionType,
		}, nil
	}

	if input.Type == importerModels.ObjectDefinitionReference {
		return &resourcemanager.ApiObjectDefinition{
			ReferenceName: input.ReferenceName,
			Type:          resourcemanager.ReferenceApiObjectDefinitionType,
		}, nil
	}

	mappings := map[importerModels.ObjectDefinitionType]resourcemanager.ApiObjectDefinitionType{
		importerModels.ObjectDefinitionBoolean:   resourcemanager.BooleanApiObjectDefinitionType,
		importerModels.ObjectDefinitionDateTime:  resourcemanager.DateTimeApiObjectDefinitionType,
		importerModels.ObjectDefinitionInteger:   resourcemanager.IntegerApiObjectDefinitionType,
		importerModels.ObjectDefinitionFloat:     resourcemanager.FloatApiObjectDefinitionType,
		importerModels.ObjectDefinitionRawFile:   resourcemanager.RawFileApiObjectDefinitionType,
		importerModels.ObjectDefinitionRawObject: resourcemanager.RawObjectApiObjectDefinitionType,
		importerModels.ObjectDefinitionString:    resourcemanager.StringApiObjectDefinitionType,
	}
	mapping, ok := mappings[input.Type]
	if !ok {
		return nil, fmt.Errorf("unimplemented object definition mapping for %q", string(input.Type))
	}
	return &resourcemanager.ApiObjectDefinition{
		Type: mapping,
	}, nil
}

func apiOperationsFromModelOperations(input map[string]importerModels.OperationDetails) (*map[string]resourcemanager.ApiOperation, error) {
	out := make(map[string]resourcemanager.ApiOperation)

	for k, v := range input {
		details := resourcemanager.ApiOperation{
			ContentType:                      &v.ContentType,
			ExpectedStatusCodes:              v.ExpectedStatusCodes,
			LongRunning:                      v.LongRunning,
			Method:                           v.Method,
			ResourceIdName:                   v.ResourceIdName,
			FieldContainingPaginationDetails: v.FieldContainingPaginationDetails,
			Options:                          v.Options,
			UriSuffix:                        v.UriSuffix,
		}
		if v.RequestObject != nil {
			obj, err := apiObjectDefinitionFromModelObjectDefinition(v.RequestObject, nil)
			if err != nil {
				return nil, fmt.Errorf("mapping request object for operation %q: %+v", k, err)
			}
			details.RequestObject = obj
		}
		if v.ResponseObject != nil {
			obj, err := apiObjectDefinitionFromModelObjectDefinition(v.ResponseObject, nil)
			if err != nil {
				return nil, fmt.Errorf("mapping response object for operation %q: %+v", k, err)
			}
			details.ResponseObject = obj
		}

		out[k] = details
	}

	return &out, nil
}

func apiResourceIdsFromModelResourceIds(input map[string]importerModels.ParsedResourceId) (*map[string]resourcemanager.ResourceIdDefinition, error) {
	out := make(map[string]resourcemanager.ResourceIdDefinition)

	for k, v := range input {
		constantNames := make([]string, 0)
		for constantName := range v.Constants {
			constantNames = append(constantNames, constantName)
		}

		out[k] = resourcemanager.ResourceIdDefinition{
			CommonAlias:   v.CommonAlias,
			ConstantNames: constantNames,
			Id:            v.ID(),
			Segments:      v.Segments,
		}
	}

	return &out, nil
}
