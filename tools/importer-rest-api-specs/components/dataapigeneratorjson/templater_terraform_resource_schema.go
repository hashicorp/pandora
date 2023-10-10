package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type SchemaModel struct {
	Fields []SchemaField `json:"Fields"`
}

type SchemaField struct {
	HclName       string  `json:"HclName"`
	Documentation *string `json:"Documentation,omitempty"`
	Required      *bool   `json:"Required,omitempty"`
	Optional      *bool   `json:"Optional,omitempty"`
	Computed      *bool   `json:"Computed,omitempty"`
	ForceNew      *bool   `json:"ForceNew,omitempty"`
	Name          string  `json:"Name"`
	// mbfrahry todo figure out if I need to go all the way down or just use the top level information for nested object definitions
	ObjectDefinition *SchemaFieldObjectDefinition     `json:"ObjectDefinition,omitempty"`
	Constants        *resourcemanager.ConstantDetails `json:"Constants,omitempty"`
}

type SchemaFieldObjectDefinition struct {
	NestedObject *SchemaFieldObjectDefinition `json:"NestedObject,omitempty"`

	// ReferenceName is the name of the Reference associated with this ObjectDefinition.
	ReferenceName *string `json:"ReferenceName"`

	// Type specifies the Type of field that this is, for example a String or a Location.
	Type TerraformSchemaFieldType `json:"Type"`
}

func codeForTerraformSchemaModelDefinition(model resourcemanager.TerraformSchemaModelDefinition, details resourcemanager.TerraformResourceDetails, resource models.AzureApiResource, apiVersionPackageName, resourcePackageName string) ([]byte, error) {
	fieldList := make([]string, 0)
	for f := range model.Fields {
		fieldList = append(fieldList, f)
	}
	sort.Strings(fieldList)

	schemaFields := make([]SchemaField, 0)
	for _, fieldName := range fieldList {
		def := model.Fields[fieldName]

		fieldBody, err := fieldDefinitionForTerraformSchemaField(fieldName, def, resource.Constants, details.SchemaModels, apiVersionPackageName, resourcePackageName)
		if err != nil {
			return nil, fmt.Errorf("determining the dotnet field for the terraform schema field %q: %+v", fieldName, err)
		}

		schemaFields = append(schemaFields, fieldBody)
	}

	data, err := json.MarshalIndent(schemaFields, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}

func fieldDefinitionForTerraformSchemaField(name string, input resourcemanager.TerraformSchemaFieldDefinition, constants map[string]resourcemanager.ConstantDetails, schemaModels map[string]resourcemanager.TerraformSchemaModelDefinition, apiVersionPackageName, resourcePackageName string) (SchemaField, error) {
	schemaField := SchemaField{
		HclName: input.HclName,
		Name:    name,
	}

	if input.Documentation.Markdown != "" {
		schemaField.Documentation = &input.Documentation.Markdown
	}

	if input.Required {
		schemaField.Required = &input.Required
	}

	if input.Optional {
		schemaField.Optional = &input.Optional
	}

	// TODO - The Or case here shouldn't be needed, however, some deeply nested models are not currently being processed, so this will catch those for now and just enforces the rule in any case
	if input.Computed || (!input.Optional && !input.Required) {
		schemaField.Computed = &input.Computed
	}

	if input.ForceNew {
		schemaField.ForceNew = &input.ForceNew
	}

	topLevelDefinition := topLevelFieldObjectDefinition(input.ObjectDefinition)
	if topLevelDefinition.ReferenceName != nil {
		// TODO - The value for ReferenceName should have been nilled in `schema/object_definition.go` before here, but until we can fix that, this will do for a "quick fix" for now
		if _, isConstant := constants[*topLevelDefinition.ReferenceName]; isConstant {
			schemaField.Constants = nil
			if constants[*topLevelDefinition.ReferenceName].Type != "" {
				constant := constants[*topLevelDefinition.ReferenceName]
				schemaField.Constants = &constant
			}
		}
	}

	return schemaField, nil
}

func topLevelFieldObjectDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition) resourcemanager.TerraformSchemaFieldObjectDefinition {
	if input.NestedObject != nil {
		return topLevelFieldObjectDefinition(*input.NestedObject)
	}

	return input
}
