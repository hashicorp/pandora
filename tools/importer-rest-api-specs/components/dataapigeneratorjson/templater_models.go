package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForModel(modelName string, model importerModels.ModelDetails, parentModel *importerModels.ModelDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails, logger hclog.Logger) ([]byte, error) {
	// TODO: thread through logging
	if len(model.Fields) == 0 {
		return nil, fmt.Errorf("the model %q has no fields", modelName)
	}

	fields, err := mapFieldsForModel(model, parentModel, knownConstants, knownModels, logger)
	if err != nil {
		return nil, fmt.Errorf("mapping fields for model %q: %+v", modelName, err)
	}

	dataApiModel := dataApiModels.Model{
		Name:   modelName,
		Fields: *fields,
	}

	// NOTE: `Parent` types don't get a `TypeHintIn` or `TypeHintValue`
	// meaning that only
	if model.ParentTypeName != nil {
		dataApiModel.DiscriminatedParentModelName = model.ParentTypeName
	}
	if model.TypeHintValue != nil {
		dataApiModel.DiscriminatedTypeValue = model.TypeHintValue
	}

	if model.TypeHintIn != nil {
		dataApiModel.TypeHintIn = model.TypeHintIn
	}

	data, err := json.MarshalIndent(dataApiModel, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}

func mapFieldsForModel(model importerModels.ModelDetails, parentModel *importerModels.ModelDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails, logger hclog.Logger) (*[]dataApiModels.ModelField, error) {
	// TODO: thread through logging

	// ensure consistency in the output
	sortedFieldNames := make([]string, 0)
	for fieldName := range model.Fields {
		sortedFieldNames = append(sortedFieldNames, fieldName)
	}
	sort.Strings(sortedFieldNames)

	fields := make([]dataApiModels.ModelField, 0)

	for _, fieldName := range sortedFieldNames {
		// we should skip outputting this field if it's present on the parent
		fieldInParent := false
		if parentModel != nil {
			// the importer flattens fields from parents/AllOf, since we don't use inheritance for that within the
			// data layer - as such we only want to skip the fields when the parent type is output, e.g. when there's
			// a discriminator involved
			for name := range parentModel.Fields {
				if strings.EqualFold(name, fieldName) {
					fieldInParent = true
					break
				}
			}
		}
		if fieldInParent {
			continue
		}

		field := model.Fields[fieldName]
		isTypeHint := model.TypeHintIn != nil && strings.EqualFold(*model.TypeHintIn, fieldName)
		fieldCode, err := mapField(fieldName, field, isTypeHint, knownConstants, knownModels)
		if err != nil {
			return nil, fmt.Errorf("generating code for field %q: %+v", fieldName, err)
		}

		fields = append(fields, *fieldCode)
	}

	return &fields, nil
}

func mapField(fieldName string, fieldDetails importerModels.FieldDetails, isTypeHint bool, constants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails) (*dataApiModels.ModelField, error) {
	// TODO: thread through logging
	objectDefinition, err := mapObjectDefinitionForField(fieldDetails, constants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping the ObjectDefinition for field %q: %+v", fieldName, err)
	}

	return &dataApiModels.ModelField{
		ContainsDiscriminatedTypeValue: isTypeHint,
		JsonName:                       fieldDetails.JsonName,
		Name:                           fieldName,
		ObjectDefinition:               *objectDefinition,
		// TODO: support Optional being a distinct value in-time so we can have ReadOnly fields too
		Optional: !fieldDetails.Required,
		Required: fieldDetails.Required,
		// TODO this can be uncommented when #3325 has been fixed
		// Description: fieldDetails.Description,
	}, nil
}

var customFieldTypesToObjectDefinitionTypes = map[importerModels.CustomFieldType]dataApiModels.ObjectDefinitionType{
	importerModels.CustomFieldTypeEdgeZone:                                dataApiModels.EdgeZoneObjectDefinitionType,
	importerModels.CustomFieldTypeLocation:                                dataApiModels.LocationObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAssignedIdentity:                  dataApiModels.SystemAssignedIdentityObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAndUserAssignedIdentityList:       dataApiModels.SystemAndUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAndUserAssignedIdentityMap:        dataApiModels.SystemAndUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityList: dataApiModels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap:  dataApiModels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeSystemOrUserAssignedIdentityList:        dataApiModels.SystemOrUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeSystemOrUserAssignedIdentityMap:         dataApiModels.SystemOrUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeUserAssignedIdentityList:                dataApiModels.UserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeUserAssignedIdentityMap:                 dataApiModels.UserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeTags:                                    dataApiModels.TagsObjectDefinitionType,
	importerModels.CustomFieldTypeSystemData:                              dataApiModels.SystemDataObjectDefinitionType,
	importerModels.CustomFieldTypeZone:                                    dataApiModels.ZoneObjectDefinitionType,
	importerModels.CustomFieldTypeZones:                                   dataApiModels.ZonesObjectDefinitionType,
}

var internalObjectDefinitionsToObjectDefinitionTypes = map[importerModels.ObjectDefinitionType]dataApiModels.ObjectDefinitionType{
	importerModels.ObjectDefinitionBoolean:    dataApiModels.BooleanObjectDefinitionType,
	importerModels.ObjectDefinitionCsv:        dataApiModels.CsvObjectDefinitionType,
	importerModels.ObjectDefinitionDateTime:   dataApiModels.DateTimeObjectDefinitionType,
	importerModels.ObjectDefinitionDictionary: dataApiModels.DictionaryObjectDefinitionType,
	importerModels.ObjectDefinitionInteger:    dataApiModels.IntegerObjectDefinitionType,
	importerModels.ObjectDefinitionFloat:      dataApiModels.FloatObjectDefinitionType,
	importerModels.ObjectDefinitionList:       dataApiModels.ListObjectDefinitionType,
	importerModels.ObjectDefinitionRawFile:    dataApiModels.RawFileObjectDefinitionType,
	importerModels.ObjectDefinitionRawObject:  dataApiModels.RawObjectObjectDefinitionType,
	importerModels.ObjectDefinitionReference:  dataApiModels.ReferenceObjectDefinitionType,
	importerModels.ObjectDefinitionString:     dataApiModels.StringObjectDefinitionType,
}

func mapObjectDefinitionForField(details importerModels.FieldDetails, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) (*dataApiModels.ObjectDefinition, error) {
	// if it's a CustomFieldType then it can't contain another item
	if details.CustomFieldType != nil {
		typeVal, ok := customFieldTypesToObjectDefinitionTypes[*details.CustomFieldType]
		if !ok {
			return nil, fmt.Errorf("internal-error: no ObjectDefinition mapping is defined for the CustomFieldType %q", string(*details.CustomFieldType))
		}
		return &dataApiModels.ObjectDefinition{
			Type:          typeVal,
			ReferenceName: nil,
			NestedItem:    nil,
		}, nil
	}

	if details.ObjectDefinition == nil {
		return nil, fmt.Errorf("internal-error: neither a CustomFieldType or an ObjectDefinition was defined for this field")
	}

	objectDefinition, err := mapObjectDefinition(details.ObjectDefinition, constants, models)
	if err != nil {
		return nil, fmt.Errorf("mapping the object definition: %+v", err)
	}

	return objectDefinition, nil
}

func mapObjectDefinition(definition *importerModels.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) (*dataApiModels.ObjectDefinition, error) {
	typeVal, ok := internalObjectDefinitionsToObjectDefinitionTypes[definition.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: no ObjectDefinition mapping is defined for the ObjectDefinition Type %q", string(definition.Type))
	}

	output := dataApiModels.ObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if definition.ReferenceName != nil {
		output.ReferenceName = definition.ReferenceName
	}

	if definition.NestedItem != nil {
		nestedItem, err := mapObjectDefinition(definition.NestedItem, constants, models)
		if err != nil {
			return nil, fmt.Errorf("mapping nested object definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	if definition.Maximum != nil {
		output.MaxItems = definition.Maximum
	}
	if definition.Minimum != nil {
		output.MinItems = definition.Minimum
	}
	if output.Type == dataApiModels.DateTimeObjectDefinitionType {
		// TODO: support additional types of Date Formats (#8)
		output.DateFormat = pointer.To(dataApiModels.RFC3339DateFormat)
	}

	// finally let's do some sanity-checking to ensure the data being output looks legit
	if err := validateObjectDefinition(output, constants, models); err != nil {
		return nil, fmt.Errorf("validating mapped ObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateObjectDefinition(input dataApiModels.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) error {
	requiresNestedItem := input.Type == dataApiModels.CsvObjectDefinitionType ||
		input.Type == dataApiModels.DictionaryObjectDefinitionType ||
		input.Type == dataApiModels.ListObjectDefinitionType
	requiresReference := input.Type == dataApiModels.ReferenceObjectDefinitionType
	if requiresNestedItem && input.NestedItem == nil {
		return fmt.Errorf("a Nested Object Definition must be specified for a %q type but didn't get one", string(input.Type))
	}
	if !requiresNestedItem && input.NestedItem != nil {
		return fmt.Errorf("a Nested Object Definition must not be specified for a %q type but got %q", string(input.Type), string(input.NestedItem.Type))
	}
	if requiresReference {
		if input.ReferenceName == nil {
			return fmt.Errorf("a Reference must be specified for a %q type but didn't get one", string(input.Type))
		}

		_, isConstant := constants[*input.ReferenceName]
		_, isModel := models[*input.ReferenceName]
		if !isConstant && !isModel {
			return fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
		}
		if isConstant && isModel {
			return fmt.Errorf("internal-error: %q was found as BOTH a Constant and a Model", *input.ReferenceName)
		}
	}
	if !requiresReference && input.ReferenceName != nil {
		return fmt.Errorf("a Reference must not be specified for a %q type but got %q", string(input.Type), *input.ReferenceName)
	}

	return nil
}
