package dataapigeneratorjson

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformSchemaModelDefinition(modelName string, schemaModel resourcemanager.TerraformSchemaModelDefinition) (*dataapimodels.TerraformSchemaModel, error) {
	fieldList := make([]string, 0)
	for f := range schemaModel.Fields {
		fieldList = append(fieldList, f)
	}
	sort.Strings(fieldList)

	schemaFields := make([]dataapimodels.TerraformSchemaField, 0)
	for _, fieldName := range fieldList {
		def := schemaModel.Fields[fieldName]

		fieldBody, err := fieldDefinitionForTerraformSchemaField(fieldName, def)
		if err != nil {
			return nil, fmt.Errorf("mapping the terraform schema field %q: %+v", fieldName, err)
		}

		schemaFields = append(schemaFields, *fieldBody)
	}

	return &dataapimodels.TerraformSchemaModel{
		Fields: schemaFields,
		// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
		Name: fmt.Sprintf("%sSchema", modelName),
	}, nil
}

func fieldDefinitionForTerraformSchemaField(fieldName string, input resourcemanager.TerraformSchemaFieldDefinition) (*dataapimodels.TerraformSchemaField, error) {
	objectDefinition, err := mapTerraformSchemaObjectDefinition(input.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("mapping Terraform Schema Object Definition: %+v", err)
	}

	output := dataapimodels.TerraformSchemaField{
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
		output.Documentation = &dataapimodels.TerraformSchemaFieldDocumentation{
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

var objectDefinitionsToTerraformSchemaObjectDefinitionTypes = map[resourcemanager.TerraformSchemaFieldType]dataapimodels.TerraformSchemaObjectDefinitionType{
	resourcemanager.TerraformSchemaFieldTypeBoolean:                       dataapimodels.BooleanTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeDateTime:                      dataapimodels.DateTimeTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeDictionary:                    dataapimodels.DictionaryTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeEdgeZone:                      dataapimodels.EdgeZoneTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        dataapimodels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: dataapimodels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  dataapimodels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          dataapimodels.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeLocation:                      dataapimodels.LocationTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeFloat:                         dataapimodels.FloatTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeInteger:                       dataapimodels.IntegerTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeList:                          dataapimodels.ListTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeReference:                     dataapimodels.ReferenceTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeResourceGroup:                 dataapimodels.ResourceGroupTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeSet:                           dataapimodels.SetTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeString:                        dataapimodels.StringTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeTags:                          dataapimodels.TagsTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeSku:                           dataapimodels.SkuTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeZone:                          dataapimodels.ZoneTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeZones:                         dataapimodels.ZonesTerraformSchemaObjectDefinitionType,
}

func mapTerraformSchemaObjectDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition) (*dataapimodels.TerraformSchemaObjectDefinition, error) {
	mapped, ok := objectDefinitionsToTerraformSchemaObjectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for the Terraform Schema Field Object Definition %q", string(input.Type))
	}

	objectDefinition := dataapimodels.TerraformSchemaObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          mapped,
	}

	if input.ReferenceName != nil && !strings.HasSuffix(*input.ReferenceName, "Schema") {
		// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
		referenceName := fmt.Sprintf("%sSchema", *input.ReferenceName)
		objectDefinition.ReferenceName = &referenceName
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

var fieldValidationTypesToTerraformSchemaFieldValidationTypes = map[resourcemanager.TerraformSchemaValidationType]dataapimodels.TerraformSchemaFieldValidationType{
	resourcemanager.TerraformSchemaValidationTypePossibleValues: dataapimodels.PossibleValuesTerraformSchemaValidationType,
}

func mapFieldValidationDefinition(input resourcemanager.TerraformSchemaValidationDefinition) (*dataapimodels.TerraformSchemaFieldValidationDefinition, error) {
	mappedType, ok := fieldValidationTypesToTerraformSchemaFieldValidationTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Schema Field Validation Type %q", string(input.Type))
	}

	output := dataapimodels.TerraformSchemaFieldValidationDefinition{
		Type: mappedType,
	}

	if mappedType == dataapimodels.PossibleValuesTerraformSchemaValidationType {
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

var possibleValuesTypeMappings = map[resourcemanager.TerraformSchemaValidationPossibleValueType]dataapimodels.TerraformSchemaValidationPossibleValuesType{
	resourcemanager.TerraformSchemaValidationPossibleValueTypeInt:    dataapimodels.FloatTerraformSchemaValidationPossibleValuesType,
	resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat:  dataapimodels.IntegerTerraformSchemaValidationPossibleValuesType,
	resourcemanager.TerraformSchemaValidationPossibleValueTypeString: dataapimodels.StringTerraformSchemaValidationPossibleValuesType,
}

func mapPossibleValuesForTerraformSchemaFieldValidation(input resourcemanager.TerraformSchemaValidationPossibleValuesDefinition) (*dataapimodels.TerraformSchemaValidationPossibleValuesDefinition, error) {
	val, ok := possibleValuesTypeMappings[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Validation PossibleValueType %q", string(input.Type))
	}

	return &dataapimodels.TerraformSchemaValidationPossibleValuesDefinition{
		Type:   val,
		Values: input.Values,
	}, nil
}
