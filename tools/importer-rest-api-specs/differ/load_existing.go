package differ

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (d *Differ) RetrieveExistingService(serviceName, apiVersion string) (*[]parser.ParsedData, error) {
	services, err := d.client.Services().Get()
	if err != nil {
		return nil, fmt.Errorf("retrieving Services from Data API: %+v", err)
	}
	if services == nil {
		return nil, nil
	}

	var existingService *parser.ParsedData
	for name, service := range *services {
		if !strings.EqualFold(name, serviceName) {
			continue
		}

		serviceDetails, err := d.client.ServiceDetails().Get(service)
		if err != nil {
			return nil, fmt.Errorf("retrieving Service Details for %q: %+v", serviceName, err)
		}
		if serviceDetails == nil {
			return nil, nil
		}

		for version, versionSummary := range serviceDetails.Versions {
			if !strings.EqualFold(version, apiVersion) {
				continue
			}

			versionDetails, err := d.client.ServiceVersion().Get(versionSummary)
			if err != nil {
				return nil, fmt.Errorf("retrieving Details for Service %q Version %q: %+v", serviceName, apiVersion, err)
			}
			if versionDetails == nil {
				continue
			}

			resources := make(map[string]models.AzureApiResource)

			for resourceName, resourceSummary := range versionDetails.Resources {
				resourceOperations, err := d.client.ApiOperations().Get(resourceSummary)
				if err != nil {
					return nil, fmt.Errorf("retrieving API Operations for Service %q Version %q Resource %q: %+v", serviceName, apiVersion, resourceName, err)
				}
				if resourceOperations == nil {
					continue
				}

				resourceSchema, err := d.client.ApiSchema().Get(resourceSummary)
				if err != nil {
					return nil, fmt.Errorf("retrieving API Schema for Service %q Version %q Resource %q: %+v", serviceName, apiVersion, resourceName, err)
				}
				if resourceSchema == nil {
					continue
				}

				mappedConstants, err := mapApiConstantsToConstantDetails(resourceSchema.Constants)
				if err != nil {
					return nil, fmt.Errorf("mapping Constants for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				mappedModels, err := mapApiModelsToModelDetails(resourceSchema.Models)
				if err != nil {
					return nil, fmt.Errorf("mapping Models for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				mappedOperations, err := mapApiOperationsToOperationDetails(resourceOperations.Operations)
				if err != nil {
					return nil, fmt.Errorf("mapping Operations for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				mappedResourceIds, err := mapApiResourceIdDefinitionsToParsedResourceIds(resourceSchema.ResourceIds, *mappedConstants)
				if err != nil {
					return nil, fmt.Errorf("mapping Resource ID's for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				resources[resourceName] = models.AzureApiResource{
					Constants:   *mappedConstants,
					Models:      *mappedModels,
					Operations:  *mappedOperations,
					ResourceIds: *mappedResourceIds,
				}
			}

			existingService = &parser.ParsedData{
				ServiceName: serviceName,
				ApiVersion:  version,
				Resources:   resources,
			}
		}
	}

	// TODO: if the parser returns a single `parser.ParsedData` then this can too - but for now emulate the same result
	if existingService == nil {
		return nil, nil
	}
	out := []parser.ParsedData{
		*existingService,
	}
	return &out, nil
}

func mapApiConstantsToConstantDetails(input map[string]resourcemanager.ConstantDetails) (*map[string]models.ConstantDetails, error) {
	output := make(map[string]models.ConstantDetails)

	for k, v := range input {
		fieldType, err := mapConstantFieldType(v.Type)
		if err != nil {
			return nil, fmt.Errorf("mapping Field Type %q for Constant %q: %+v", string(v.Type), k, err)
		}

		output[k] = models.ConstantDetails{
			FieldType: *fieldType,
			Values:    v.Values,
		}
	}

	return &output, nil
}

func mapConstantFieldType(input resourcemanager.ConstantType) (*models.ConstantFieldType, error) {
	switch input {
	case resourcemanager.IntegerConstant:
		v := models.IntegerConstant
		return &v, nil

	case resourcemanager.FloatConstant:
		v := models.FloatConstant
		return &v, nil

	case resourcemanager.StringConstant:
		v := models.StringConstant
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}

func mapApiModelsToModelDetails(input map[string]resourcemanager.ModelDetails) (*map[string]models.ModelDetails, error) {
	output := make(map[string]models.ModelDetails)

	for k, v := range input {
		fields, err := mapFieldsFromApi(v.Fields)
		if err != nil {
			return nil, fmt.Errorf("mapping fields for model %q: %+v", k, err)
		}

		output[k] = models.ModelDetails{
			Description:    "",
			Fields:         *fields,
			ParentTypeName: v.ParentTypeName,
			TypeHintIn:     v.TypeHintIn,
			TypeHintValue:  v.TypeHintValue,
		}
	}

	return &output, nil
}

func mapFieldsFromApi(input map[string]resourcemanager.FieldDetails) (*map[string]models.FieldDetails, error) {
	output := make(map[string]models.FieldDetails)

	for k, v := range input {
		objectDefinition, customFieldType, err := mapApiObjectDefinition(v.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("mapping ObjectDefinition from Api for Field %q: %+v", k, err)
		}

		output[k] = models.FieldDetails{
			Required:         v.Required,
			ReadOnly:         false,
			Sensitive:        false,
			JsonName:         v.JsonName,
			CustomFieldType:  customFieldType,
			ObjectDefinition: objectDefinition,
		}
	}

	return &output, nil
}

func mapApiObjectDefinition(input resourcemanager.ApiObjectDefinition) (*models.ObjectDefinition, *models.CustomFieldType, error) {
	objectDefinitionType, customFieldType, err := mapApiObjectDefinitionType(input.Type)
	if err != nil {
		return nil, nil, fmt.Errorf("mapping API Object Definition Type %q: %+v", string(input.Type), err)
	}
	if objectDefinitionType != nil && customFieldType != nil {
		return nil, nil, fmt.Errorf("mapping API Object Definition Type %q: both ObjectDefinition and CustomFieldType were non-nil - this is a bug", string(input.Type))
	}

	if input.NestedItem != nil {
		if objectDefinitionType == nil {
			return nil, nil, fmt.Errorf("ObjectDefinitionType was nil with a NestedItem - this is a bug")
		}

		nestedObjectDefinition, nestedCustomFieldType, err := mapApiObjectDefinition(*input.NestedItem)
		if err != nil {
			return nil, nil, fmt.Errorf("mapping nested item: %+v", err)
		}
		if nestedCustomFieldType != nil {
			return nil, nil, fmt.Errorf("got a Nested CustomFieldType - this is a bug")
		}

		objectDefinition := models.ObjectDefinition{
			NestedItem: nestedObjectDefinition,
			Type:       *objectDefinitionType,
			// TODO: expose min/max etc in the API
		}
		return &objectDefinition, nil, nil
	}

	if objectDefinitionType != nil {
		objectDefinition := models.ObjectDefinition{
			ReferenceName: input.ReferenceName,
			Type:          *objectDefinitionType,
			// TODO: expose min/max etc in the API
		}
		return &objectDefinition, nil, nil
	}
	if customFieldType != nil {
		return nil, customFieldType, nil
	}
	return nil, nil, fmt.Errorf("no ObjectDefinition or CustomFieldType for Type %q", string(input.Type))
}

func mapApiObjectDefinitionType(input resourcemanager.ApiObjectDefinitionType) (*models.ObjectDefinitionType, *models.CustomFieldType, error) {
	objectDefinitions := map[resourcemanager.ApiObjectDefinitionType]models.ObjectDefinitionType{
		resourcemanager.BooleanApiObjectDefinitionType:    models.ObjectDefinitionBoolean,
		resourcemanager.CsvApiObjectDefinitionType:        models.ObjectDefinitionCsv,
		resourcemanager.DateTimeApiObjectDefinitionType:   models.ObjectDefinitionDateTime,
		resourcemanager.DictionaryApiObjectDefinitionType: models.ObjectDefinitionDictionary,
		resourcemanager.IntegerApiObjectDefinitionType:    models.ObjectDefinitionInteger,
		resourcemanager.FloatApiObjectDefinitionType:      models.ObjectDefinitionFloat,
		resourcemanager.ListApiObjectDefinitionType:       models.ObjectDefinitionList,
		resourcemanager.RawFileApiObjectDefinitionType:    models.ObjectDefinitionRawFile,
		resourcemanager.RawObjectApiObjectDefinitionType:  models.ObjectDefinitionRawObject,
		resourcemanager.ReferenceApiObjectDefinitionType:  models.ObjectDefinitionReference,
		resourcemanager.StringApiObjectDefinitionType:     models.ObjectDefinitionString,
	}
	if v, ok := objectDefinitions[input]; ok {
		return &v, nil, nil
	}

	customTypes := map[resourcemanager.ApiObjectDefinitionType]models.CustomFieldType{
		resourcemanager.LocationApiObjectDefinitionType:                       models.CustomFieldTypeLocation,
		resourcemanager.SystemAssignedIdentityApiObjectDefinitionType:         models.CustomFieldTypeSystemAssignedIdentity,
		resourcemanager.SystemUserAssignedIdentityListApiObjectDefinitionType: models.CustomFieldTypeSystemAssignedUserAssignedIdentityList,
		resourcemanager.SystemUserAssignedIdentityMapApiObjectDefinitionType:  models.CustomFieldTypeSystemAssignedUserAssignedIdentityMap,
		resourcemanager.UserAssignedIdentityListApiObjectDefinitionType:       models.CustomFieldTypeUserAssignedIdentityList,
		resourcemanager.UserAssignedIdentityMapApiObjectDefinitionType:        models.CustomFieldTypeUserAssignedIdentityMap,
		resourcemanager.TagsApiObjectDefinitionType:                           models.CustomFieldTypeTags,
	}
	if v, ok := customTypes[input]; ok {
		return nil, &v, nil
	}

	return nil, nil, fmt.Errorf("Type %q was not an ObjectDefinition or a Custom Type - missing mapping?", string(input))
}

func mapApiOperationsToOperationDetails(input map[string]resourcemanager.ApiOperation) (*map[string]models.OperationDetails, error) {
	output := make(map[string]models.OperationDetails)

	for k, v := range input {
		var requestObject *models.ObjectDefinition
		if v.RequestObject != nil {
			objectDefinition, customFieldType, err := mapApiObjectDefinition(*v.RequestObject)
			if err != nil {
				return nil, fmt.Errorf("mapping request object for Operation %q: %+v", k, err)
			}
			if customFieldType != nil {
				return nil, fmt.Errorf("custom field types aren't supported for Request Objects but got one for Operation %q", k)
			}
			requestObject = objectDefinition
		}

		var responseObject *models.ObjectDefinition
		if v.ResponseObject != nil {
			objectDefinition, customFieldType, err := mapApiObjectDefinition(*v.ResponseObject)
			if err != nil {
				return nil, fmt.Errorf("mapping response object for Operation %q: %+v", k, err)
			}
			if customFieldType != nil {
				return nil, fmt.Errorf("custom field types aren't supported for Response Objects but got one for Operation %q", k)
			}
			responseObject = objectDefinition
		}

		options, err := mapApiOperationOptions(v.Options)
		if err != nil {
			return nil, fmt.Errorf("mapping Options for Api Operation %q: %+v", k, err)
		}

		// TODO: this should always be returned by the API
		contentType := "application/json"
		if v.ContentType != nil {
			contentType = *v.ContentType
		}

		output[k] = models.OperationDetails{
			ApiVersion:                       v.ApiVersion,
			ContentType:                      contentType,
			ExpectedStatusCodes:              v.ExpectedStatusCodes,
			FieldContainingPaginationDetails: v.FieldContainingPaginationDetails,
			IsListOperation:                  v.FieldContainingPaginationDetails != nil,
			LongRunning:                      v.LongRunning,
			Method:                           v.Method,
			Options:                          *options,
			RequestObject:                    requestObject,
			ResourceIdName:                   v.ResourceIdName,
			ResponseObject:                   responseObject,
			Uri:                              "", // intentionally not mapped, since this should probably be removed in time
			UriSuffix:                        v.UriSuffix,
		}
	}

	return &output, nil
}

func mapApiOperationOptions(input map[string]resourcemanager.ApiOperationOption) (*map[string]models.OperationOption, error) {
	output := make(map[string]models.OperationOption)

	for k, v := range input {
		objectDefinition, customFieldType, err := mapApiObjectDefinition(v.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("mapping ObjectDefinition for Option %q: %+v", k, err)
		}
		if customFieldType != nil {
			return nil, fmt.Errorf("custom field types are not supported for operation options but got one for Option %q: %+v", k, err)
		}

		output[k] = models.OperationOption{
			// TODO: support Headers (#6)
			ObjectDefinition: objectDefinition,
			QueryStringName:  *v.QueryStringName,
			Required:         v.Required,
		}
	}

	return &output, nil
}

func mapApiResourceIdDefinitionsToParsedResourceIds(input map[string]resourcemanager.ResourceIdDefinition, constants map[string]models.ConstantDetails) (*map[string]models.ParsedResourceId, error) {
	output := make(map[string]models.ParsedResourceId)

	for k, v := range input {
		constantsUsed := make(map[string]models.ConstantDetails)
		for _, name := range v.ConstantNames {
			constant, ok := constants[name]
			if !ok {
				return nil, fmt.Errorf("constant %q was not found", name)
			}

			constantsUsed[name] = constant
		}

		segments, err := mapApiResourceIdSegments(v.Segments)
		if err != nil {
			return nil, fmt.Errorf("mapping segments for Resource ID %q: %+v", k, err)
		}

		output[k] = models.ParsedResourceId{
			Constants: constantsUsed,
			Segments:  *segments,
		}
	}

	return &output, nil
}

func mapApiResourceIdSegments(input []resourcemanager.ResourceIdSegment) (*[]models.ResourceIdSegment, error) {
	output := make([]models.ResourceIdSegment, 0)

	for _, v := range input {
		segmentType, err := mapApiResourceIdSegmentType(v.Type)
		if err != nil {
			return nil, fmt.Errorf("mapping Segment Type %q: %+v", string(v.Type), err)
		}

		output = append(output, models.ResourceIdSegment{
			Type:              *segmentType,
			ConstantReference: v.ConstantReference,
			FixedValue:        v.FixedValue,
			Name:              v.Name,
		})
	}

	return &output, nil
}

func mapApiResourceIdSegmentType(input resourcemanager.ResourceIdSegmentType) (*models.SegmentType, error) {
	vals := map[resourcemanager.ResourceIdSegmentType]models.SegmentType{
		resourcemanager.ConstantSegment:         models.ConstantSegment,
		resourcemanager.ResourceGroupSegment:    models.ResourceGroupSegment,
		resourcemanager.ResourceProviderSegment: models.ResourceProviderSegment,
		resourcemanager.ScopeSegment:            models.ScopeSegment,
		resourcemanager.StaticSegment:           models.StaticSegment,
		resourcemanager.SubscriptionIdSegment:   models.SubscriptionIdSegment,
		resourcemanager.UserSpecifiedSegment:    models.UserSpecifiedSegment,

		// TODO: until #272 is merged
		resourcemanager.ResourceIdSegmentType("UserSpecified"): models.UserSpecifiedSegment,
	}
	if v, ok := vals[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("missing mapping for Segment Type %q", string(input))
}
