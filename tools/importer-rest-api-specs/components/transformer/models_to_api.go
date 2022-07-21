package transformer

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

func ApiResourceFromModelResource(schema models.AzureApiResource) (*services.Resource, error) {
	operations, err := apiOperationsFromModelOperations(schema.Operations)
	if err != nil {
		return nil, fmt.Errorf("converting Model Operation Details into Data API Operation Details: %+v", err)
	}

	constants, err := apiConstantsFromModelConstants(schema.Constants)
	if err != nil {
		return nil, fmt.Errorf("converting Model Constant Details into Data API Constant Details: %+v", err)
	}

	models, err := apiModelsFromModelModels(schema.Models)
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
			Constants:   *constants,
			Models:      *models,
			ResourceIds: *resourceIds,
		},
	}, nil
}

func apiConstantsFromModelConstants(input map[string]models.ConstantDetails) (*map[string]resourcemanager.ConstantDetails, error) {
	out := make(map[string]resourcemanager.ConstantDetails, 0)

	for k, v := range input {
		details := resourcemanager.ConstantDetails{
			CaseInsensitive: false,
			Values:          v.Values,
		}

		switch v.FieldType {
		case models.IntegerConstant:
			details.Type = resourcemanager.IntegerConstant
		case models.FloatConstant:
			details.Type = resourcemanager.FloatConstant
		case models.StringConstant:
			details.Type = resourcemanager.StringConstant
		default:
			return nil, fmt.Errorf("unsupported constant type %q for %q", string(details.Type), k)
		}

		out[k] = details
	}

	return &out, nil
}

func apiModelsFromModelModels(input map[string]models.ModelDetails) (*map[string]resourcemanager.ModelDetails, error) {
	out := make(map[string]resourcemanager.ModelDetails)

	for k, v := range input {
		fields, err := apiFieldsFromModelFields(v.Fields, v)
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

func apiFieldsFromModelFields(input map[string]models.FieldDetails, model models.ModelDetails) (*map[string]resourcemanager.FieldDetails, error) {
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
			Validation: nil,
		}

		if details.ObjectDefinition.Type == resourcemanager.DateTimeApiObjectDefinitionType {
			dateFormat := resourcemanager.RFC3339
			details.DateFormat = &dateFormat
		}

		out[k] = details
	}

	return &out, nil
}

func apiObjectDefinitionFromModelObjectDefinition(input *models.ObjectDefinition, fieldType *models.CustomFieldType) (*resourcemanager.ApiObjectDefinition, error) {
	if fieldType != nil {
		mappings := map[models.CustomFieldType]resourcemanager.ApiObjectDefinitionType{
			models.CustomFieldTypeEdgeZone:                                resourcemanager.EdgeZoneApiObjectDefinitionType,
			models.CustomFieldTypeLocation:                                resourcemanager.LocationApiObjectDefinitionType,
			models.CustomFieldTypeSystemAssignedIdentity:                  resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
			models.CustomFieldTypeSystemAndUserAssignedIdentityList:       resourcemanager.SystemAndUserAssignedIdentityListApiObjectDefinitionType,
			models.CustomFieldTypeSystemAndUserAssignedIdentityMap:        resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
			models.CustomFieldTypeLegacySystemAndUserAssignedIdentityList: resourcemanager.LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType,
			models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap:  resourcemanager.LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType,
			models.CustomFieldTypeSystemOrUserAssignedIdentityList:        resourcemanager.SystemOrUserAssignedIdentityListApiObjectDefinitionType,
			models.CustomFieldTypeSystemOrUserAssignedIdentityMap:         resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType,
			models.CustomFieldTypeUserAssignedIdentityList:                resourcemanager.UserAssignedIdentityListApiObjectDefinitionType,
			models.CustomFieldTypeUserAssignedIdentityMap:                 resourcemanager.UserAssignedIdentityMapApiObjectDefinitionType,
			models.CustomFieldTypeTags:                                    resourcemanager.TagsApiObjectDefinitionType,
			models.CustomFieldTypeSystemData:                              resourcemanager.SystemData,
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

	if input.Type == models.ObjectDefinitionDictionary {
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

	if input.Type == models.ObjectDefinitionList {
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

	if input.Type == models.ObjectDefinitionReference {
		return &resourcemanager.ApiObjectDefinition{
			ReferenceName: input.ReferenceName,
			Type:          resourcemanager.ReferenceApiObjectDefinitionType,
		}, nil
	}

	mappings := map[models.ObjectDefinitionType]resourcemanager.ApiObjectDefinitionType{
		models.ObjectDefinitionBoolean:   resourcemanager.BooleanApiObjectDefinitionType,
		models.ObjectDefinitionCsv:       resourcemanager.CsvApiObjectDefinitionType,
		models.ObjectDefinitionDateTime:  resourcemanager.DateTimeApiObjectDefinitionType,
		models.ObjectDefinitionInteger:   resourcemanager.IntegerApiObjectDefinitionType,
		models.ObjectDefinitionFloat:     resourcemanager.FloatApiObjectDefinitionType,
		models.ObjectDefinitionRawFile:   resourcemanager.RawFileApiObjectDefinitionType,
		models.ObjectDefinitionRawObject: resourcemanager.RawObjectApiObjectDefinitionType,
		models.ObjectDefinitionString:    resourcemanager.StringApiObjectDefinitionType,
	}
	mapping, ok := mappings[input.Type]
	if !ok {
		return nil, fmt.Errorf("unimplemented object definition mapping for %q", string(input.Type))
	}
	return &resourcemanager.ApiObjectDefinition{
		Type: mapping,
	}, nil
}

func apiOperationsFromModelOperations(input map[string]models.OperationDetails) (*map[string]resourcemanager.ApiOperation, error) {
	out := make(map[string]resourcemanager.ApiOperation)

	for k, v := range input {
		details := resourcemanager.ApiOperation{
			ContentType:                      &v.ContentType,
			ExpectedStatusCodes:              v.ExpectedStatusCodes,
			LongRunning:                      v.LongRunning,
			Method:                           v.Method,
			ResourceIdName:                   v.ResourceIdName,
			FieldContainingPaginationDetails: v.FieldContainingPaginationDetails,
			Options:                          map[string]resourcemanager.ApiOperationOption{},
			UriSuffix:                        v.UriSuffix,
		}
		if v.Options != nil {
			options, err := apiOptionsFromModelOptions(v.Options)
			if err != nil {
				return nil, fmt.Errorf("mapping options for operation %q: %+v", k, err)
			}
			details.Options = *options
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

func apiOptionsFromModelOptions(input map[string]models.OperationOption) (*map[string]resourcemanager.ApiOperationOption, error) {
	out := make(map[string]resourcemanager.ApiOperationOption)

	for k, v := range input {
		objectDefinition, err := apiObjectDefinitionFromModelObjectDefinition(v.ObjectDefinition, nil)
		if err != nil {
			return nil, fmt.Errorf("mapping object definition for options key %q: %+v", k, err)
		}

		out[k] = resourcemanager.ApiOperationOption{
			HeaderName:       v.HeaderName,
			QueryStringName:  v.QueryStringName,
			ObjectDefinition: *objectDefinition,
			Required:         v.Required,
		}
	}

	return &out, nil
}

func apiResourceIdsFromModelResourceIds(input map[string]models.ParsedResourceId) (*map[string]resourcemanager.ResourceIdDefinition, error) {
	out := make(map[string]resourcemanager.ResourceIdDefinition)

	for k, v := range input {
		constantNames := make([]string, 0)
		for constantName := range v.Constants {
			constantNames = append(constantNames, constantName)
		}

		segments, err := apiResourceIdSegmentsFromModelResourceIdSegments(v.Segments)
		if err != nil {
			return nil, fmt.Errorf("mapping resource id segments for id %q: %+v", k, err)
		}

		out[k] = resourcemanager.ResourceIdDefinition{
			CommonAlias:   v.CommonAlias,
			ConstantNames: constantNames,
			Id:            v.ID(),
			Segments:      *segments,
		}
	}

	return &out, nil
}

func apiResourceIdSegmentsFromModelResourceIdSegments(input []models.ResourceIdSegment) (*[]resourcemanager.ResourceIdSegment, error) {
	out := make([]resourcemanager.ResourceIdSegment, 0)

	for _, v := range input {
		mappings := map[models.SegmentType]resourcemanager.ResourceIdSegmentType{
			resourcemanager.ConstantSegment:         resourcemanager.ConstantSegment,
			resourcemanager.ResourceGroupSegment:    resourcemanager.ResourceGroupSegment,
			resourcemanager.ResourceProviderSegment: resourcemanager.ResourceProviderSegment,
			models.ScopeSegment:                     resourcemanager.ScopeSegment,
			models.SubscriptionIdSegment:            resourcemanager.SubscriptionIdSegment,
			resourcemanager.StaticSegment:           resourcemanager.StaticSegment,
			models.UserSpecifiedSegment:             resourcemanager.UserSpecifiedSegment,
		}
		mapping, ok := mappings[v.Type]
		if !ok {
			return nil, fmt.Errorf("missing mapping for segment type %q", string(v.Type))
		}

		out = append(out, resourcemanager.ResourceIdSegment{
			ConstantReference: v.ConstantReference,
			ExampleValue:      "(unused)",
			FixedValue:        v.FixedValue,
			Name:              v.Name,
			Type:              mapping,
		})
	}

	return &out, nil
}
