package dataapigeneratorjson

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	dataApiModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformSchemaModelDefinition(modelName string, schemaModel resourcemanager.TerraformSchemaModelDefinition) (*dataApiModels.TerraformSchemaModel, error) {
	fieldList := make([]string, 0)
	for f := range schemaModel.Fields {
		fieldList = append(fieldList, f)
	}
	sort.Strings(fieldList)

	schemaFields := make([]dataApiModels.TerraformSchemaField, 0)
	for _, fieldName := range fieldList {
		def := schemaModel.Fields[fieldName]

		fieldBody, err := fieldDefinitionForTerraformSchemaField(fieldName, def)
		if err != nil {
			return nil, fmt.Errorf("determining the dotnet field for the terraform schema field %q: %+v", fieldName, err)
		}

		schemaFields = append(schemaFields, *fieldBody)
	}

	return &dataApiModels.TerraformSchemaModel{
		Fields: schemaFields,
		Name:   modelName,
	}, nil
}

func fieldDefinitionForTerraformSchemaField(fieldName string, input resourcemanager.TerraformSchemaFieldDefinition) (*dataApiModels.TerraformSchemaField, error) {
	objectDefinition, err := mapTerraformSchemaObjectDefinition(input.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("mapping Terraform Schema Object Definition: %+v", err)
	}

	output := dataApiModels.TerraformSchemaField{
		HclName:          input.HclName,
		Name:             fieldName,
		ObjectDefinition: *objectDefinition,
	}

	if input.Computed {
		output.Computed = pointer.To(true)
	}
	if input.ForceNew {
		output.ForceNew = pointer.To(true)
	}
	if input.Optional {
		output.Optional = pointer.To(true)
	}
	if input.Required {
		output.Required = pointer.To(true)
	}
	if input.Documentation.Markdown != "" {
		output.Documentation = &dataApiModels.TerraformSchemaFieldDocumentation{
			Markdown: input.Documentation.Markdown,
		}
	}
	if input.Validation != nil {
		validation, err := mapFieldValidationDefinition(*input.Validation)
		if err != nil {
			return nil, fmt.Errorf("building validation: %+v", err)
		}
		output.Validation = validation
	}

	// sanity-check
	if !input.Computed && !input.Optional && !input.Required {
		return nil, fmt.Errorf("the field %q is neither Computed, Optional or Required - this is a bug", fieldName)
	}

	return &output, nil
}

var objectDefinitionsToTerraformSchemaObjectDefinitionTypes = map[resourcemanager.TerraformSchemaFieldType]dataApiModels.TerraformSchemaObjectDefinitionType{
	resourcemanager.TerraformSchemaFieldTypeBoolean:                       dataApiModels.BooleanTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeDateTime:                      dataApiModels.DateTimeTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeDictionary:                    dataApiModels.DictionaryTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeEdgeZone:                      dataApiModels.EdgeZoneTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        dataApiModels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: dataApiModels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  dataApiModels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          dataApiModels.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeLocation:                      dataApiModels.LocationTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeFloat:                         dataApiModels.FloatTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeInteger:                       dataApiModels.IntegerTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeList:                          dataApiModels.ListTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeReference:                     dataApiModels.ReferenceTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeResourceGroup:                 dataApiModels.ResourceGroupTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeSet:                           dataApiModels.SetTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeString:                        dataApiModels.StringTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeTags:                          dataApiModels.TagsTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeSku:                           dataApiModels.SkuTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeZone:                          dataApiModels.ZoneTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeZones:                         dataApiModels.ZonesTerraformSchemaObjectDefinitionType,
}

func mapTerraformSchemaObjectDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition) (*dataApiModels.TerraformSchemaObjectDefinition, error) {
	mapped, ok := objectDefinitionsToTerraformSchemaObjectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for the Terraform Schema Field Object Definition %q", string(input.Type))
	}

	objectDefinition := dataApiModels.TerraformSchemaObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          mapped,
	}

	if input.NestedObject != nil {
		nestedItem, err := mapTerraformSchemaObjectDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("mapping nested Object Definition: %+v", err)
		}
		objectDefinition.NestedItem = nestedItem
	}

	return &objectDefinition, nil
}

var fieldValidationTypesToTerraformSchemaFieldValidationTypes = map[resourcemanager.TerraformSchemaValidationType]dataApiModels.TerraformSchemaFieldValidationType{
	resourcemanager.TerraformSchemaValidationTypePossibleValues: dataApiModels.PossibleValuesTerraformSchemaValidationType,
}

func mapFieldValidationDefinition(input resourcemanager.TerraformSchemaValidationDefinition) (*dataApiModels.TerraformSchemaFieldValidationDefinition, error) {
	mappedType, ok := fieldValidationTypesToTerraformSchemaFieldValidationTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Schema Field Validation Type %q", string(input.Type))
	}

	output := dataApiModels.TerraformSchemaFieldValidationDefinition{
		Type: mappedType,
	}

	if mappedType == dataApiModels.PossibleValuesTerraformSchemaValidationType {
		if input.PossibleValues == nil {
			return nil, fmt.Errorf("internal-error: bad data -`internal.PossibleValues` was nil for a PossibleValues type")
		}
		possibleValues, err := mapPossibleValuesForTerraformSchemaFieldValidation(*input.PossibleValues)
		if err != nil {
			return nil, fmt.Errorf("mapping the Possible Values for the Terraform Schema Field: %+v", err)
		}
		output.PossibleValues = possibleValues
	}
	return &output, nil
}

var possibleValuesTypeMappings = map[resourcemanager.TerraformSchemaValidationPossibleValueType]dataApiModels.TerraformSchemaValidationPossibleValuesType{
	resourcemanager.TerraformSchemaValidationPossibleValueTypeInt:    dataApiModels.FloatTerraformSchemaValidationPossibleValuesType,
	resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat:  dataApiModels.IntegerTerraformSchemaValidationPossibleValuesType,
	resourcemanager.TerraformSchemaValidationPossibleValueTypeString: dataApiModels.StringTerraformSchemaValidationPossibleValuesType,
}

func mapPossibleValuesForTerraformSchemaFieldValidation(input resourcemanager.TerraformSchemaValidationPossibleValuesDefinition) (*dataApiModels.TerraformSchemaValidationPossibleValuesDefinition, error) {
	val, ok := possibleValuesTypeMappings[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Validation PossibleValueType %q", string(input.Type))
	}

	return &dataApiModels.TerraformSchemaValidationPossibleValuesDefinition{
		Type:   val,
		Values: input.Values,
	}, nil
}
