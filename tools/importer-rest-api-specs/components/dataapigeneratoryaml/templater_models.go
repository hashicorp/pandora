package dataapigeneratoryaml

import (
	"fmt"
	"sort"
	"strings"

	"github.com/go-yaml/yaml"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type Model struct {
	Fields          []Field `yaml:"Fields"`
	IsDiscriminator *bool   `yaml:"IsDiscriminator,omitempty"`
	ParentModelName *string `yaml:"ParentModelName,omitempty"`
	// TODO rename, and should this be a slice? haven't found examples where there are multiple of these
	ValueForType *string `yaml:"ValueForType,omitempty"`
}

type Field struct {
	Name             string  `yaml:"Name"`
	JsonName         string  `yaml:"JsonName"`
	Required         *bool    `yaml:"Required,omitempty"`
	Optional         *bool    `yaml:"Optional,omitempty"`
	Type             string  `yaml:"Type"`
	ReferenceName    *string `yaml:"ReferenceName,omitempty"`
	MinItems         *int    `yaml:"MinItems,omitempty"`
	MaxItems         *int    `yaml:"MaxItems,omitempty"`
	DateFormat       *string `yaml:"DateFormat,omitempty"`
	ProvidesTypeHint *bool   `yaml:"ProvidesTypeHint,omitempty"`
}


func codeForModel(metadata string, modelName string, model models.ModelDetails, parentModel *models.ModelDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]models.ModelDetails) ([]byte, error) {
	if len(model.Fields) == 0 {
		return nil, fmt.Errorf("the model %q in namespace %q has no fields", modelName, metadata)
	}

	// ensure consistency in the output
	sortedFieldNames := make([]string, 0)
	for fieldName := range model.Fields {
		sortedFieldNames = append(sortedFieldNames, fieldName)
	}
	sort.Strings(sortedFieldNames)

	fields := make([]Field, 0)

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
		fieldCode, err := codeForField(fieldName, field, isTypeHint, knownConstants, knownModels)
		if err != nil {
			return nil, fmt.Errorf("generating code for field %q: %+v", fieldName, err)
		}

		fields = append(fields, *fieldCode)
	}

	var DataApiModel Model

	DataApiModel.Fields = fields

	if model.TypeHintIn != nil {
		DataApiModel.IsDiscriminator = pointer.To(true)
		if model.ParentTypeName != nil {
			DataApiModel.ParentModelName = model.ParentTypeName
		}
	}

	if model.TypeHintValue != nil {
		DataApiModel.ValueForType = model.TypeHintValue
	}

	data, err := yaml.Marshal(DataApiModel)
	if err != nil {
		return nil, err
	}

	return data, nil
}

func codeForField(fieldName string, fieldDetails models.FieldDetails, isTypeHint bool, constants map[string]resourcemanager.ConstantDetails, knownModels map[string]models.ModelDetails) (*Field, error) {
	var field Field

	field.Name = fieldName
	field.JsonName = fieldDetails.JsonName

	fieldType, err := typeNameForField(fieldDetails, constants, knownModels)
	if err != nil {
		return nil, err
	}

	field.Type = *fieldType

	if fieldDetails.ObjectDefinition != nil {
		innerObjectDefinition := topLevelObjectDefinition(*fieldDetails.ObjectDefinition)
		if innerObjectDefinition.Minimum != nil {
			field.MinItems = innerObjectDefinition.Minimum
		}
		if innerObjectDefinition.Maximum != nil {
			field.MaxItems = innerObjectDefinition.Maximum
		}

		if fieldDetails.ObjectDefinition.Type == models.ObjectDefinitionDateTime {
			// TODO: support for custom date formats
			field.DateFormat = pointer.To("RFC3339")
		}
	}

	if isTypeHint {
		field.ProvidesTypeHint = pointer.To(true)
	}

	if fieldDetails.Required {
		field.Required = pointer.To(true)
	} else {
		field.Optional = pointer.To(true)
	}

	return &field, nil
}

func typeNameForField(field models.FieldDetails, constants map[string]resourcemanager.ConstantDetails, models map[string]models.ModelDetails) (*string, error) {
	if field.CustomFieldType != nil {
		return typeNameForCustomType(*field.CustomFieldType)
	}

	return typeNameForObjectDefinition(field.ObjectDefinition, constants, models)
}

func typeNameForCustomType(input models.CustomFieldType) (*string, error) {
	var nilableType = func(in string) (*string, error) {
		return &in, nil
	}

	switch input {
	case models.CustomFieldTypeEdgeZone:
		return nilableType("CustomTypes.EdgeZone")

	case models.CustomFieldTypeLocation:
		return nilableType("CustomTypes.Location")

	case models.CustomFieldTypeTags:
		return nilableType("CustomTypes.Tags")

	case models.CustomFieldTypeSystemAssignedIdentity:
		return nilableType("CustomTypes.SystemAssignedIdentity")

	case models.CustomFieldTypeSystemAndUserAssignedIdentityList:
		return nilableType("CustomTypes.SystemAndUserAssignedIdentityList")

	case models.CustomFieldTypeSystemAndUserAssignedIdentityMap:
		return nilableType("CustomTypes.SystemAndUserAssignedIdentityMap")

	case models.CustomFieldTypeLegacySystemAndUserAssignedIdentityList:
		return nilableType("CustomTypes.LegacySystemAndUserAssignedIdentityList")

	case models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap:
		return nilableType("CustomTypes.LegacySystemAndUserAssignedIdentityMap")

	case models.CustomFieldTypeSystemOrUserAssignedIdentityList:
		return nilableType("CustomTypes.SystemOrUserAssignedIdentityList")

	case models.CustomFieldTypeSystemOrUserAssignedIdentityMap:
		return nilableType("CustomTypes.SystemOrUserAssignedIdentityMap")

	case models.CustomFieldTypeUserAssignedIdentityList:
		return nilableType("CustomTypes.UserAssignedIdentityList")

	case models.CustomFieldTypeUserAssignedIdentityMap:
		return nilableType("CustomTypes.UserAssignedIdentityMap")

	case models.CustomFieldTypeSystemData:
		return nilableType("CustomTypes.SystemData")

	case models.CustomFieldTypeZone:
		return nilableType("CustomTypes.Zone")

	case models.CustomFieldTypeZones:
		return nilableType("CustomTypes.Zones")
	}

	return nil, fmt.Errorf("unmapped Custom Type %q", string(input))
}

func typeNameForObjectDefinition(input *models.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, knownModels map[string]models.ModelDetails) (*string, error) {
	if input == nil {
		return nil, fmt.Errorf("missing object definition")
	}

	var nilableValue = func(in string) (*string, error) {
		return &in, nil
	}

	switch input.Type {
	case models.ObjectDefinitionCsv:
		{
			if input.ReferenceName != nil {
				if _, isConstant := constants[*input.ReferenceName]; isConstant {
					return nilableValue(fmt.Sprintf("Csv%sConstant", *input.ReferenceName))
				}
				if _, isModel := knownModels[*input.ReferenceName]; isModel {
					return nilableValue(fmt.Sprintf("Csv%sModel", *input.ReferenceName))
				}

				return nil, fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
			}

			if input.NestedItem == nil {
				return nil, fmt.Errorf("a Csv must have a reference or a nested item but got neither")
			}

			innerType, err := typeNameForObjectDefinition(input.NestedItem, constants, knownModels)
			if err != nil {
				return nil, fmt.Errorf("determining inner type for object definition: %+v", err)
			}
			return nilableValue(fmt.Sprintf("Csv%s", *innerType))
		}

	case models.ObjectDefinitionDictionary:
		{
			if input.ReferenceName != nil {
				if _, isConstant := constants[*input.ReferenceName]; isConstant {
					return nilableValue(fmt.Sprintf("Dictionary<string, %sConstant>", *input.ReferenceName))
				}
				if _, isModel := knownModels[*input.ReferenceName]; isModel {
					return nilableValue(fmt.Sprintf("Dictionary<string, %sModel>", *input.ReferenceName))
				}

				return nil, fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
			}

			if input.NestedItem == nil {
				return nil, fmt.Errorf("a dictionary must have a reference or a nested item but got neither")
			}

			innerType, err := typeNameForObjectDefinition(input.NestedItem, constants, knownModels)
			if err != nil {
				return nil, fmt.Errorf("determining inner type for object definition: %+v", err)
			}
			return nilableValue(fmt.Sprintf("Dictionary<string, %s>", *innerType))
		}

	case models.ObjectDefinitionList:
		{
			if input.ReferenceName != nil {
				if _, isConstant := constants[*input.ReferenceName]; isConstant {
					return nilableValue(fmt.Sprintf("List<%sConstant>", *input.ReferenceName))
				}
				if _, isModel := knownModels[*input.ReferenceName]; isModel {
					return nilableValue(fmt.Sprintf("List<%sModel>", *input.ReferenceName))
				}

				return nil, fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
			}

			if input.NestedItem == nil {
				return nil, fmt.Errorf("a list item must have a reference or a nested item but got neither")
			}

			innerType, err := typeNameForObjectDefinition(input.NestedItem, constants, knownModels)
			if err != nil {
				return nil, fmt.Errorf("determining inner type for object definition: %+v", err)
			}
			return nilableValue(fmt.Sprintf("List<%s>", *innerType))
		}

	case models.ObjectDefinitionReference:
		{
			if input.ReferenceName == nil {
				return nil, fmt.Errorf("a reference must have a reference name but didn't get one")
			}

			// is this a constant or a model
			if _, isConstant := constants[*input.ReferenceName]; isConstant {
				val := fmt.Sprintf("%s", *input.ReferenceName)
				return &val, nil
			}
			if _, isModel := knownModels[*input.ReferenceName]; isModel {
				val := fmt.Sprintf("%s", *input.ReferenceName)
				return &val, nil
			}

			return nil, fmt.Errorf("the Reference %q wasn't found as a Constant or a Model", *input.ReferenceName)
		}

	case models.ObjectDefinitionBoolean:
		return nilableValue("bool")

	case models.ObjectDefinitionDateTime:
		return nilableValue("DateTime")

	case models.ObjectDefinitionFloat:
		return nilableValue("float")

	case models.ObjectDefinitionInteger:
		return nilableValue("int")

	// this is using RawFile and not `byte[]` since byte streams are also possible but aren't files
	case models.ObjectDefinitionRawFile:
		return nilableValue("CustomTypes.RawFile")

	case models.ObjectDefinitionRawObject:
		return nilableValue("object")

	case models.ObjectDefinitionString:
		return nilableValue("string")
	}

	return nil, fmt.Errorf("unmapped object definition value: %+v", *input)
}

// topLevelObjectDefinition returns the top level object definition, that is a Constant or Model (or simple type) directly
func topLevelObjectDefinition(input models.ObjectDefinition) models.ObjectDefinition {
	if input.NestedItem != nil {
		return topLevelObjectDefinition(*input.NestedItem)
	}

	return input
}
