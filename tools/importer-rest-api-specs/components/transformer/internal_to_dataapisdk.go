package transformer

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// NOTE: this file contains temporary glue code to enable refactoring this tool gradually, component-by-component.

func MapInternalTypesToDataAPISDKTypes(inputApiVersions []importerModels.AzureApiDefinition, resourceProvider, terraformPackageName *string, logger hclog.Logger) (*models.Service, error) {
	apiVersions := make(map[string]models.APIVersion)

	logger.Debug("Mapping API Versions..")
	for _, item := range inputApiVersions {
		logger.Trace(fmt.Sprintf("Mapping Service %q / API Version %q", item.ServiceName, item.ApiVersion))
		mapped, err := mapInternalAPIVersionTypeToDataAPISDKType(item)
		if err != nil {
			return nil, fmt.Errorf("mapping API Version %q: %+v", item.ApiVersion, err)
		}

		apiVersions[item.ApiVersion] = *mapped
	}

	output := models.Service{
		APIVersions:      apiVersions,
		Generate:         true,
		ResourceProvider: resourceProvider,
	}

	if terraformPackageName != nil {
		logger.Debug("Mapping Terraform Definition..")
		resources := make(map[string]models.TerraformResourceDefinition, 0)
		for _, apiVersion := range inputApiVersions {
			for _, apiResource := range apiVersion.Resources {
				if apiResource.Terraform == nil {
					continue
				}
				for key, value := range apiResource.Terraform.Resources {
					mapped, err := mapTerraformResourceDefinitionToSDKType(value)
					if err != nil {
						return nil, fmt.Errorf("mapping the Terraform Resource Definition for %q: %+v", key, err)
					}

					resources[key] = *mapped
				}
			}
		}

		output.TerraformDefinition = &models.TerraformDefinition{
			Resources:            resources,
			TerraformPackageName: *terraformPackageName,
		}
	}

	return &output, nil
}

func mapInternalAPIVersionTypeToDataAPISDKType(input importerModels.AzureApiDefinition) (*models.APIVersion, error) {
	resources := make(map[string]models.APIResource)

	for apiResource, apiResourceDetails := range input.Resources {
		constants, err := mapInternalConstantsToDataAPISDKType(apiResourceDetails.Constants)
		if err != nil {
			return nil, fmt.Errorf("mapping Constants for API Resource %q: %+v", apiResource, err)
		}
		mappedModels, err := mapInternalModelsToDataAPISDKType(apiResourceDetails.Models)
		if err != nil {
			return nil, fmt.Errorf("mapping Models for API Resource %q: %+v", apiResource, err)
		}
		operations, err := mapInternalOperationsToDataAPISDKType(apiResourceDetails.Operations)
		if err != nil {
			return nil, fmt.Errorf("mapping Operations for API Resource %q: %+v", apiResource, err)
		}
		resourceIds, err := mapInternalResourceIDsToDataAPISDKType(apiResourceDetails.ResourceIds)
		if err != nil {
			return nil, fmt.Errorf("mapping ResourceIDs for API Resource %q: %+v", apiResource, err)
		}

		resources[apiResource] = models.APIResource{
			Constants:   *constants,
			Models:      *mappedModels,
			Operations:  *operations,
			ResourceIDs: *resourceIds,
		}
	}

	return &models.APIVersion{
		Generate:  true,
		Preview:   input.IsPreviewVersion(),
		Resources: resources,
		Source:    models.AzureRestAPISpecsSourceDataOrigin,
	}, nil
}

func mapInternalConstantsToDataAPISDKType(input map[string]resourcemanager.ConstantDetails) (*map[string]models.SDKConstant, error) {
	output := make(map[string]models.SDKConstant)

	for key, value := range input {
		mappings := map[resourcemanager.ConstantType]models.SDKConstantType{
			resourcemanager.FloatConstant:   models.FloatSDKConstantType,
			resourcemanager.IntegerConstant: models.IntegerSDKConstantType,
			resourcemanager.StringConstant:  models.StringSDKConstantType,
		}
		mappedType, ok := mappings[value.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for Constant Type %q", string(value.Type))
		}

		output[key] = models.SDKConstant{
			Type:   mappedType,
			Values: value.Values,
		}
	}

	return &output, nil
}

func mapInternalModelsToDataAPISDKType(input map[string]importerModels.ModelDetails) (*map[string]models.SDKModel, error) {
	output := make(map[string]models.SDKModel)

	for key, value := range input {
		fields, err := mapInternalModelFieldsToDataAPISDKType(value.Fields, value.TypeHintIn)
		if err != nil {
			return nil, fmt.Errorf("mapping Field %q: %+v", key, err)
		}

		output[key] = models.SDKModel{
			DiscriminatedValue:                    value.TypeHintValue,
			FieldNameContainingDiscriminatedValue: value.TypeHintIn,
			Fields:                                *fields,
			ParentTypeName:                        value.ParentTypeName,
		}
	}

	return &output, nil
}

func mapInternalModelFieldsToDataAPISDKType(input map[string]importerModels.FieldDetails, fieldNameContainingDiscriminatedValue *string) (*map[string]models.SDKField, error) {
	output := make(map[string]models.SDKField)

	for key, value := range input {
		objectDefinition, err := mapInternalFieldObjectDefinitionToDataAPISDKType(value.CustomFieldType, value.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("mapping ObjectDefinition for Field %q: %+v", key, err)
		}

		field := models.SDKField{
			ContainsDiscriminatedValue: false,
			DateFormat:                 nil,
			Description:                value.Description,
			JsonName:                   value.JsonName,
			ObjectDefinition:           *objectDefinition,
			Optional:                   !value.Required,
			Required:                   value.Required,
		}
		if fieldNameContainingDiscriminatedValue != nil && *fieldNameContainingDiscriminatedValue != key {
			field.ContainsDiscriminatedValue = *fieldNameContainingDiscriminatedValue != key
		}
		if value.ObjectDefinition != nil && value.ObjectDefinition.Type == importerModels.ObjectDefinitionDateTime {
			field.DateFormat = pointer.To(models.RFC3339SDKDateFormat) // everything is for now
		}

		output[key] = field
	}

	return &output, nil
}

func mapInternalFieldObjectDefinitionToDataAPISDKType(customFieldType *importerModels.CustomFieldType, objectDefinition *importerModels.ObjectDefinition) (*models.SDKObjectDefinition, error) {
	if customFieldType != nil {
		// Custom Field Types == Top Level Common Schema Types so this is a direct mapping
		val, ok := customFieldTypesToSDKTypes[*customFieldType]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for CustomFieldType %q", string(*customFieldType))
		}

		return &models.SDKObjectDefinition{
			NestedItem:    nil,
			ReferenceName: nil,
			Type:          val,
		}, nil
	}

	if objectDefinition != nil {
		return mapInternalObjectDefinitionToDataAPISDKType(*objectDefinition)
	}

	return nil, fmt.Errorf("internal-error: expected either a CustomFieldType or ObjectDefinition but got neither")
}

func mapInternalOperationsToDataAPISDKType(input map[string]importerModels.OperationDetails) (*map[string]models.SDKOperation, error) {
	output := make(map[string]models.SDKOperation)

	for key, value := range input {
		operation := models.SDKOperation{
			ContentType:                      value.ContentType,
			ExpectedStatusCodes:              value.ExpectedStatusCodes,
			FieldContainingPaginationDetails: value.FieldContainingPaginationDetails,
			LongRunning:                      value.LongRunning,
			Method:                           value.Method,
			Options:                          nil,
			RequestObject:                    nil,
			ResourceIDName:                   value.ResourceIdName,
			ResponseObject:                   nil,
			URISuffix:                        value.UriSuffix,
		}
		if value.RequestObject != nil {
			obj, err := mapInternalObjectDefinitionToDataAPISDKType(*value.RequestObject)
			if err != nil {
				return nil, fmt.Errorf("mapping RequestObject for Operation %q: %+v", key, err)
			}
			operation.RequestObject = obj
		}
		if value.ResponseObject != nil {
			obj, err := mapInternalObjectDefinitionToDataAPISDKType(*value.ResponseObject)
			if err != nil {
				return nil, fmt.Errorf("mapping ResponseObject for Operation %q: %+v", key, err)
			}
			operation.ResponseObject = obj
		}

		operation.Options = map[string]models.SDKOperationOption{}
		for k, v := range value.Options {
			optionObjectDefinition, err := mapInternalOperationOptionObjectDefinitionToDataAPISDKType(*v.ObjectDefinition)
			if err != nil {
				return nil, fmt.Errorf("mapping ObjectDefinition for Operation %q Option %q: %+v", key, k, err)
			}

			operation.Options[k] = models.SDKOperationOption{
				HeaderName:       v.HeaderName,
				QueryStringName:  v.QueryStringName,
				ObjectDefinition: *optionObjectDefinition,
				Required:         v.Required,
			}
		}
		output[key] = operation
	}

	return &output, nil
}

func mapInternalOperationOptionObjectDefinitionToDataAPISDKType(input importerModels.ObjectDefinition) (*models.SDKOperationOptionObjectDefinition, error) {
	val, ok := operationOptionObjectDefinitionsToSDKTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Operation Object Definition Type %q", string(input.Type))
	}

	out := models.SDKOperationOptionObjectDefinition{
		NestedItem:    nil,
		ReferenceName: input.ReferenceName,
		Type:          val,
	}
	if input.NestedItem != nil {
		nestedItem, err := mapInternalOperationOptionObjectDefinitionToDataAPISDKType(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping NestedItem: %+v", err)
		}
		out.NestedItem = nestedItem
	}
	return &out, nil
}

func mapInternalObjectDefinitionToDataAPISDKType(input importerModels.ObjectDefinition) (*models.SDKObjectDefinition, error) {
	var ok bool
	out := models.SDKObjectDefinition{}

	if out.Type, ok = objectDefinitionToSDKTypes[input.Type]; !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for ObjectDefinition %q", string(input.Type))
	}

	if input.ReferenceName != nil {
		out.ReferenceName = input.ReferenceName
	}

	if input.NestedItem != nil {
		mapped, err := mapInternalObjectDefinitionToDataAPISDKType(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping Nested Object: %+v", err)
		}
		out.NestedItem = mapped
	}

	return &out, nil
}

func mapTerraformResourceDefinitionToSDKType(input resourcemanager.TerraformResourceDetails) (*models.TerraformResourceDefinition, error) {
	createMethod := mapTerraformMethodDefinitionToSDKType(input.CreateMethod)
	deleteMethod := mapTerraformMethodDefinitionToSDKType(input.DeleteMethod)
	readMethod := mapTerraformMethodDefinitionToSDKType(input.ReadMethod)
	tests := mapTerraformResourceTestsToSDKType(input.Tests)

	mappings, err := mapTerraformMappingsToSDKType(input.Mappings)
	if err != nil {
		return nil, fmt.Errorf("mapping Terraform Mappings: %+v", err)
	}

	schemaModels, err := mapTerraformSchemaModelsToSDKType(input.SchemaModels)
	if err != nil {
		return nil, fmt.Errorf("mapping Terraform Schema Models: %+v", err)
	}

	output := models.TerraformResourceDefinition{
		APIResource:  input.Resource,
		APIVersion:   input.ApiVersion,
		CreateMethod: createMethod,
		DeleteMethod: deleteMethod,
		Documentation: models.TerraformDocumentationDefinition{
			Category:        input.Documentation.Category,
			Description:     input.Documentation.Description,
			ExampleUsageHCL: input.Documentation.ExampleUsageHcl,
		},
		DisplayName:          input.DisplayName,
		Generate:             input.Generate,
		GenerateModel:        input.GenerateModel,
		GenerateIDValidation: input.GenerateIdValidation,
		GenerateSchema:       input.GenerateSchema,
		Mappings:             *mappings,
		ReadMethod:           readMethod,
		ResourceIDName:       input.ResourceIdName,
		ResourceName:         input.ResourceName,
		SchemaModelName:      input.SchemaModelName,
		SchemaModels:         *schemaModels,
		Tests:                tests,
		UpdateMethod:         nil,
	}

	if input.UpdateMethod != nil {
		updateMethod := mapTerraformMethodDefinitionToSDKType(*input.UpdateMethod)
		output.UpdateMethod = pointer.To(updateMethod)
	}

	return &output, nil
}

func mapTerraformSchemaModelsToSDKType(input map[string]resourcemanager.TerraformSchemaModelDefinition) (*map[string]models.TerraformSchemaModel, error) {
	output := make(map[string]models.TerraformSchemaModel)

	for key, value := range input {
		fields, err := mapTerraformSchemaFieldsToSDKType(value.Fields)
		if err != nil {
			return nil, fmt.Errorf("mapping Terraform Schema Fields: %+v", err)
		}

		output[key] = models.TerraformSchemaModel{
			Fields: *fields,
		}
	}

	return &output, nil
}

func mapTerraformSchemaFieldsToSDKType(input map[string]resourcemanager.TerraformSchemaFieldDefinition) (*map[string]models.TerraformSchemaField, error) {
	output := make(map[string]models.TerraformSchemaField)

	for key, value := range input {
		objectDefinition, err := mapTerraformSchemaObjectDefinitionToSDKType(value.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("mapping ObjectDefinition for Field %q: %+v", key, err)
		}

		field := models.TerraformSchemaField{
			Computed: value.Computed,
			Documentation: models.TerraformSchemaFieldDocumentationDefinition{
				Markdown: value.Documentation.Markdown,
			},
			ForceNew:         value.ForceNew,
			HCLName:          value.HclName,
			ObjectDefinition: *objectDefinition,
			Optional:         value.Optional,
			Required:         value.Required,
			Validation:       nil,
		}

		if value.Validation != nil {
			mapped, err := mapTerraformSchemaFieldValidationToSDKType(*value.Validation)
			if err != nil {
				return nil, fmt.Errorf("mapping Validation for Field %q: %+v", key, err)
			}
			field.Validation = mapped
		}

		output[key] = field
	}

	return &output, nil
}

func mapTerraformSchemaObjectDefinitionToSDKType(input resourcemanager.TerraformSchemaFieldObjectDefinition) (*models.TerraformSchemaObjectDefinition, error) {
	val, ok := terraformObjectDefinitionToSDKType[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Terraform Schema Object Definition Type %q", string(input.Type))
	}

	output := models.TerraformSchemaObjectDefinition{
		NestedObject:  nil,
		ReferenceName: input.ReferenceName,
		Type:          val,
	}

	if input.NestedObject != nil {
		nested, err := mapTerraformSchemaObjectDefinitionToSDKType(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("mapping NestedObject: %+v", err)
		}

		output.NestedObject = nested
	}

	return &output, nil
}

func mapTerraformSchemaFieldValidationToSDKType(input resourcemanager.TerraformSchemaValidationDefinition) (models.TerraformSchemaFieldValidationDefinition, error) {
	if input.Type == resourcemanager.TerraformSchemaValidationTypePossibleValues {
		mapped, ok := terraformSchemaValidationPossibleValuesTypeToSDKType[input.PossibleValues.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for Possible Values Type %q", string(input.PossibleValues.Type))
		}
		return models.TerraformSchemaFieldValidationPossibleValuesDefinition{
			PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
				Type:   mapped,
				Values: input.PossibleValues.Values,
			},
		}, nil
	}

	return nil, fmt.Errorf("internal-error: missing mapping for Schema Field Validation %q", string(input.Type))
}

func mapTerraformResourceTestsToSDKType(input resourcemanager.TerraformResourceTestsDefinition) models.TerraformResourceTestsDefinition {
	return models.TerraformResourceTestsDefinition{
		BasicConfiguration:          input.BasicConfiguration,
		RequiresImportConfiguration: input.RequiresImportConfiguration,
		CompleteConfiguration:       input.CompleteConfiguration,
		Generate:                    input.Generate,
		OtherTests:                  pointer.To(input.OtherTests),
		TemplateConfiguration:       input.TemplateConfiguration,
	}
}

func mapTerraformMappingsToSDKType(input resourcemanager.MappingDefinition) (*models.TerraformMappingDefinition, error) {
	fields, err := mapTerraformFieldMappingsToSDKType(input.Fields)
	if err != nil {
		return nil, fmt.Errorf("mapping Field Mappings: %+v", err)
	}
	modelToModels, err := mapTerraformModelToModelMappingsToSDKType(input.ModelToModels)
	if err != nil {
		return nil, fmt.Errorf("mapping ModelToModel Mappings: %+v", err)
	}
	resourceIds, err := mapTerraformResourceIDMappingsToSDKType(input.ResourceId)
	if err != nil {
		return nil, fmt.Errorf("mapping ResourceId Mappings: %+v", err)
	}

	return &models.TerraformMappingDefinition{
		Fields:        *fields,
		ModelToModels: *modelToModels,
		ResourceID:    *resourceIds,
	}, nil
}

func mapTerraformFieldMappingsToSDKType(input []resourcemanager.FieldMappingDefinition) (*[]models.TerraformFieldMappingDefinition, error) {
	output := make([]models.TerraformFieldMappingDefinition, 0)

	for _, item := range input {
		if item.Type == resourcemanager.DirectAssignmentMappingDefinitionType {
			output = append(output, models.TerraformDirectAssignmentFieldMappingDefinition{
				DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
					TerraformSchemaModelName: item.DirectAssignment.SchemaModelName,
					TerraformSchemaFieldName: item.DirectAssignment.SchemaFieldPath,
					SDKModelName:             item.DirectAssignment.SdkModelName,
					SDKFieldName:             item.DirectAssignment.SdkFieldPath,
				},
			})
			continue
		}

		if item.Type == resourcemanager.ModelToModelMappingDefinitionType {
			output = append(output, models.TerraformModelToModelFieldMappingDefinition{
				ModelToModel: models.TerraformModelToModelFieldMappingDefinitionImpl{
					TerraformSchemaModelName: item.ModelToModel.SchemaModelName,
					SDKModelName:             item.ModelToModel.SdkModelName,
					SDKFieldName:             item.ModelToModel.SdkFieldName,
				},
			})
			continue
		}

		return nil, fmt.Errorf("internal-error: missing mapping for Mapping Type %q", string(item.Type))
	}

	return &output, nil
}

func mapTerraformModelToModelMappingsToSDKType(input []resourcemanager.ModelToModelMappingDefinition) (*[]models.TerraformModelToModelMappingDefinition, error) {
	output := make([]models.TerraformModelToModelMappingDefinition, 0)

	for _, item := range input {
		output = append(output, models.TerraformModelToModelMappingDefinition{
			SDKModelName:             item.SdkModelName,
			TerraformSchemaModelName: item.SchemaModelName,
		})
	}

	return &output, nil
}

func mapTerraformResourceIDMappingsToSDKType(input []resourcemanager.ResourceIdMappingDefinition) (*[]models.TerraformResourceIDMappingDefinition, error) {
	output := make([]models.TerraformResourceIDMappingDefinition, 0)

	for _, item := range input {
		output = append(output, models.TerraformResourceIDMappingDefinition{
			ParsedFromParentID:       item.ParsedFromParentID,
			SegmentName:              item.SegmentName,
			TerraformSchemaFieldName: item.SchemaFieldName,
		})
	}

	return &output, nil
}

func mapTerraformMethodDefinitionToSDKType(input resourcemanager.MethodDefinition) models.TerraformMethodDefinition {
	return models.TerraformMethodDefinition{
		Generate:         input.Generate,
		SDKOperationName: input.MethodName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}

func mapInternalResourceIDsToDataAPISDKType(input map[string]importerModels.ParsedResourceId) (*map[string]models.ResourceID, error) {
	output := make(map[string]models.ResourceID)

	for key, value := range input {
		segments, err := mapInternalResourceIDSegmentsToDataAPISDKType(value.Segments)
		if err != nil {
			return nil, fmt.Errorf("mapping Segments for Resource ID %q: %+v", key, err)
		}
		uniqueConstants := make(map[string]struct{})
		for _, segment := range value.Segments {
			if segment.ConstantReference == nil {
				continue
			}

			uniqueConstants[*segment.ConstantReference] = struct{}{}
		}
		constantNames := make([]string, 0)
		for k := range uniqueConstants {
			constantNames = append(constantNames, k)
		}
		sort.Strings(constantNames)

		output[key] = models.ResourceID{
			CommonIDAlias: value.CommonAlias,
			ConstantNames: constantNames,
			ExampleValue:  value.ID(),
			Segments:      *segments,
		}
	}

	return &output, nil
}

func mapInternalResourceIDSegmentsToDataAPISDKType(input []resourcemanager.ResourceIdSegment) (*[]models.ResourceIDSegment, error) {
	output := make([]models.ResourceIDSegment, 0)

	for _, item := range input {
		val, ok := resourceIdSegmentTypesToDataAPISDKType[item.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for Resource ID Segment Type %q", string(item.Type))
		}

		output = append(output, models.ResourceIDSegment{
			ConstantReference: item.ConstantReference,
			ExampleValue:      item.ExampleValue,
			FixedValue:        item.FixedValue,
			Type:              val,
			Name:              item.Name,
		})
	}

	return &output, nil
}

var customFieldTypesToSDKTypes = map[importerModels.CustomFieldType]models.SDKObjectDefinitionType{
	importerModels.CustomFieldTypeEdgeZone:                                models.EdgeZoneSDKObjectDefinitionType,
	importerModels.CustomFieldTypeLocation:                                models.LocationSDKObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAssignedIdentity:                  models.SystemAssignedIdentitySDKObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAndUserAssignedIdentityList:       models.SystemAndUserAssignedIdentityListSDKObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAndUserAssignedIdentityMap:        models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
	importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityList: models.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType,
	importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap:  models.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
	importerModels.CustomFieldTypeSystemOrUserAssignedIdentityList:        models.SystemOrUserAssignedIdentityListSDKObjectDefinitionType,
	importerModels.CustomFieldTypeSystemOrUserAssignedIdentityMap:         models.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType,
	importerModels.CustomFieldTypeUserAssignedIdentityList:                models.UserAssignedIdentityListSDKObjectDefinitionType,
	importerModels.CustomFieldTypeUserAssignedIdentityMap:                 models.UserAssignedIdentityMapSDKObjectDefinitionType,
	importerModels.CustomFieldTypeTags:                                    models.TagsSDKObjectDefinitionType,
	importerModels.CustomFieldTypeSystemData:                              models.SystemDataSDKObjectDefinitionType,
	importerModels.CustomFieldTypeZone:                                    models.ZoneTerraformSchemaObjectDefinitionType,
	importerModels.CustomFieldTypeZones:                                   models.ZonesTerraformSchemaObjectDefinitionType,
}

var objectDefinitionToSDKTypes = map[importerModels.ObjectDefinitionType]models.SDKObjectDefinitionType{
	importerModels.ObjectDefinitionBoolean:    models.BooleanSDKObjectDefinitionType,
	importerModels.ObjectDefinitionCsv:        models.CSVSDKObjectDefinitionType,
	importerModels.ObjectDefinitionDateTime:   models.DateTimeSDKObjectDefinitionType,
	importerModels.ObjectDefinitionDictionary: models.DictionarySDKObjectDefinitionType,
	importerModels.ObjectDefinitionInteger:    models.IntegerSDKObjectDefinitionType,
	importerModels.ObjectDefinitionFloat:      models.FloatSDKObjectDefinitionType,
	importerModels.ObjectDefinitionList:       models.ListSDKObjectDefinitionType,
	importerModels.ObjectDefinitionRawFile:    models.RawFileSDKObjectDefinitionType,
	importerModels.ObjectDefinitionRawObject:  models.RawObjectSDKObjectDefinitionType,
	importerModels.ObjectDefinitionReference:  models.ReferenceSDKObjectDefinitionType,
	importerModels.ObjectDefinitionString:     models.StringSDKObjectDefinitionType,
}

var operationOptionObjectDefinitionsToSDKTypes = map[importerModels.ObjectDefinitionType]models.SDKOperationOptionObjectDefinitionType{
	importerModels.ObjectDefinitionBoolean:   models.BooleanSDKOperationOptionObjectDefinitionType,
	importerModels.ObjectDefinitionCsv:       models.CSVSDKOperationOptionObjectDefinitionType,
	importerModels.ObjectDefinitionInteger:   models.IntegerSDKOperationOptionObjectDefinitionType,
	importerModels.ObjectDefinitionFloat:     models.FloatSDKOperationOptionObjectDefinitionType,
	importerModels.ObjectDefinitionList:      models.ListSDKOperationOptionObjectDefinitionType,
	importerModels.ObjectDefinitionReference: models.ReferenceSDKOperationOptionObjectDefinitionType,
	importerModels.ObjectDefinitionString:    models.StringSDKOperationOptionObjectDefinitionType,
}

var terraformObjectDefinitionToSDKType = map[resourcemanager.TerraformSchemaFieldType]models.TerraformSchemaFieldType{
	resourcemanager.TerraformSchemaFieldTypeBoolean:    models.BooleanTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeDateTime:   models.DateTimeTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeDictionary: models.DictionaryTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeFloat:      models.FloatTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeInteger:    models.IntegerTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeList:       models.ListTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeReference:  models.ReferenceTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeSet:        models.SetTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeString:     models.StringTerraformSchemaObjectDefinitionType,

	resourcemanager.TerraformSchemaFieldTypeEdgeZone:                      models.EdgeZoneTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeLocation:                      models.LocationTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeResourceGroup:                 models.ResourceGroupTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeTags:                          models.TagsTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeZone:                          models.ZoneTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeZones:                         models.ZonesTerraformSchemaObjectDefinitionType,
	// NOTE: sku is intentionally not mapped
}

var terraformSchemaValidationPossibleValuesTypeToSDKType = map[resourcemanager.TerraformSchemaValidationPossibleValueType]models.TerraformSchemaFieldValidationPossibleValuesType{
	resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat:  models.FloatTerraformSchemaFieldValidationPossibleValuesType,
	resourcemanager.TerraformSchemaValidationPossibleValueTypeInt:    models.IntegerTerraformSchemaFieldValidationPossibleValuesType,
	resourcemanager.TerraformSchemaValidationPossibleValueTypeString: models.StringTerraformSchemaFieldValidationPossibleValuesType,
}

var resourceIdSegmentTypesToDataAPISDKType = map[resourcemanager.ResourceIdSegmentType]models.ResourceIDSegmentType{
	resourcemanager.ConstantSegment:         models.ConstantResourceIDSegmentType,
	resourcemanager.ResourceGroupSegment:    models.ResourceGroupResourceIDSegmentType,
	resourcemanager.ResourceProviderSegment: models.ResourceProviderResourceIDSegmentType,
	resourcemanager.ScopeSegment:            models.ScopeResourceIDSegmentType,
	resourcemanager.StaticSegment:           models.StaticResourceIDSegmentType,
	resourcemanager.SubscriptionIdSegment:   models.SubscriptionIDResourceIDSegmentType,
	resourcemanager.UserSpecifiedSegment:    models.UserSpecifiedResourceIDSegmentType,
}
