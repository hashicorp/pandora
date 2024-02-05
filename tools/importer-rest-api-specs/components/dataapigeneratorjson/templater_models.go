// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
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

	dataApiModel := dataapimodels.Model{
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

func mapFieldsForModel(model importerModels.ModelDetails, parentModel *importerModels.ModelDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails, logger hclog.Logger) (*[]dataapimodels.ModelField, error) {
	// TODO: thread through logging

	// ensure consistency in the output
	sortedFieldNames := make([]string, 0)
	for fieldName := range model.Fields {
		sortedFieldNames = append(sortedFieldNames, fieldName)
	}
	sort.Strings(sortedFieldNames)

	fields := make([]dataapimodels.ModelField, 0)

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

func mapField(fieldName string, fieldDetails importerModels.FieldDetails, isTypeHint bool, constants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails) (*dataapimodels.ModelField, error) {
	// TODO: thread through logging
	objectDefinition, err := mapObjectDefinitionForField(fieldDetails, constants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping the ObjectDefinition for field %q: %+v", fieldName, err)
	}

	return &dataapimodels.ModelField{
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

var customFieldTypesToObjectDefinitionTypes = map[importerModels.CustomFieldType]dataapimodels.ObjectDefinitionType{
	importerModels.CustomFieldTypeEdgeZone:                                dataapimodels.EdgeZoneObjectDefinitionType,
	importerModels.CustomFieldTypeLocation:                                dataapimodels.LocationObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAssignedIdentity:                  dataapimodels.SystemAssignedIdentityObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAndUserAssignedIdentityList:       dataapimodels.SystemAndUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAndUserAssignedIdentityMap:        dataapimodels.SystemAndUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityList: dataapimodels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap:  dataapimodels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeSystemOrUserAssignedIdentityList:        dataapimodels.SystemOrUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeSystemOrUserAssignedIdentityMap:         dataapimodels.SystemOrUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeUserAssignedIdentityList:                dataapimodels.UserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeUserAssignedIdentityMap:                 dataapimodels.UserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeTags:                                    dataapimodels.TagsObjectDefinitionType,
	importerModels.CustomFieldTypeSystemData:                              dataapimodels.SystemDataObjectDefinitionType,
	importerModels.CustomFieldTypeZone:                                    dataapimodels.ZoneObjectDefinitionType,
	importerModels.CustomFieldTypeZones:                                   dataapimodels.ZonesObjectDefinitionType,
}

var internalObjectDefinitionsToObjectDefinitionTypes = map[importerModels.ObjectDefinitionType]dataapimodels.ObjectDefinitionType{
	importerModels.ObjectDefinitionBoolean:    dataapimodels.BooleanObjectDefinitionType,
	importerModels.ObjectDefinitionCsv:        dataapimodels.CsvObjectDefinitionType,
	importerModels.ObjectDefinitionDateTime:   dataapimodels.DateTimeObjectDefinitionType,
	importerModels.ObjectDefinitionDictionary: dataapimodels.DictionaryObjectDefinitionType,
	importerModels.ObjectDefinitionInteger:    dataapimodels.IntegerObjectDefinitionType,
	importerModels.ObjectDefinitionFloat:      dataapimodels.FloatObjectDefinitionType,
	importerModels.ObjectDefinitionList:       dataapimodels.ListObjectDefinitionType,
	importerModels.ObjectDefinitionRawFile:    dataapimodels.RawFileObjectDefinitionType,
	importerModels.ObjectDefinitionRawObject:  dataapimodels.RawObjectObjectDefinitionType,
	importerModels.ObjectDefinitionReference:  dataapimodels.ReferenceObjectDefinitionType,
	importerModels.ObjectDefinitionString:     dataapimodels.StringObjectDefinitionType,
}

func mapObjectDefinitionForField(details importerModels.FieldDetails, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) (*dataapimodels.ObjectDefinition, error) {
	// if it's a CustomFieldType then it can't contain another item
	if details.CustomFieldType != nil {
		typeVal, ok := customFieldTypesToObjectDefinitionTypes[*details.CustomFieldType]
		if !ok {
			return nil, fmt.Errorf("internal-error: no ObjectDefinition mapping is defined for the CustomFieldType %q", string(*details.CustomFieldType))
		}
		return &dataapimodels.ObjectDefinition{
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

func mapObjectDefinition(definition *importerModels.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) (*dataapimodels.ObjectDefinition, error) {
	typeVal, ok := internalObjectDefinitionsToObjectDefinitionTypes[definition.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: no ObjectDefinition mapping is defined for the ObjectDefinition Type %q", string(definition.Type))
	}

	output := dataapimodels.ObjectDefinition{
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
	if output.Type == dataapimodels.DateTimeObjectDefinitionType {
		// TODO: support additional types of Date Formats (#8)
		output.DateFormat = pointer.To(dataapimodels.RFC3339DateFormat)
	}

	// finally let's do some sanity-checking to ensure the data being output looks legit
	if err := validateObjectDefinition(output, constants, models); err != nil {
		return nil, fmt.Errorf("validating mapped ObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateObjectDefinition(input dataapimodels.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) error {
	requiresNestedItem := input.Type == dataapimodels.CsvObjectDefinitionType ||
		input.Type == dataapimodels.DictionaryObjectDefinitionType ||
		input.Type == dataapimodels.ListObjectDefinitionType
	requiresReference := input.Type == dataapimodels.ReferenceObjectDefinitionType
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
