package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	models "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformSchemaModelDefinition(terraformNamespace, name string, model resourcemanager.TerraformSchemaModelDefinition, details resourcemanager.TerraformResourceDetails, resource models.AzureApiResource) (*string, error) {
	// Make the schema ordered
	fieldList := make([]string, 0)
	for f := range model.Fields {
		fieldList = append(fieldList, f)
	}
	sort.Strings(fieldList)

	fields := make([]string, 0)
	for _, fieldName := range fieldList {
		def := model.Fields[fieldName]

		// TODO: logger
		fieldBody, err := dotNetFieldDefinitionForTerraformSchemaField(fieldName, def, resource.Constants, details.SchemaModels)
		if err != nil {
			return nil, fmt.Errorf("determining the dotnet field for the terraform schema field %q: %+v", fieldName, err)
		}

		fields = append(fields, *fieldBody)
	}

	out := fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace %[1]s;

public class %[2]sSchema
{
%s
}
`, terraformNamespace, name, strings.Join(fields, "\n"))
	return &out, nil
}

func dotNetFieldDefinitionForTerraformSchemaField(name string, input resourcemanager.TerraformSchemaFieldDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]resourcemanager.TerraformSchemaModelDefinition) (*string, error) {
	typeName, err := dotNetTypeNameForTerraformFieldObjectDefinition(input.ObjectDefinition, constants, models)
	if err != nil {
		return nil, fmt.Errorf("determining dotnet type name for field object definition: %+v", err)
	}
	attributes := make([]string, 0)
	if input.Computed {
		attributes = append(attributes, "[Computed]")
	}
	attributes = append(attributes, fmt.Sprintf("[HclName(%q)]", input.HclName))
	if input.ForceNew {
		attributes = append(attributes, "[ForceNew]")
	}
	if input.Optional {
		attributes = append(attributes, "[Optional]")
	}
	if input.Required {
		attributes = append(attributes, "[Required]")
	}

	// TODO: if this is a Constant we need to add appropriate validation
	// TODO: support for accessors (e.g. get only/set only/both)

	out := fmt.Sprintf(`
%s
public %s %s { get; set; }
`, strings.Join(attributes, "\n"), *typeName, name)
	return &out, nil
}

func dotNetTypeNameForTerraformFieldObjectDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]resourcemanager.TerraformSchemaModelDefinition) (*string, error) {
	if input.Type == resourcemanager.TerraformSchemaFieldTypeList {
		if input.NestedObject == nil {
			return nil, fmt.Errorf("a list must have a nested object")
		}
		nestedObject, err := dotNetTypeNameForTerraformFieldObjectDefinition(*input.NestedObject, constants, models)
		if err != nil {
			return nil, fmt.Errorf("determining dotnet type name for nested object definition: %+v", err)
		}
		out := fmt.Sprintf("List<%s>", *nestedObject)
		return &out, nil
	}

	if input.Type == resourcemanager.TerraformSchemaFieldTypeSet {
		if input.NestedObject == nil {
			return nil, fmt.Errorf("a set must have a nested object")
		}

		// TODO: determine how we handle Sets
		return nil, fmt.Errorf("TODO: lookup the type we're using for Sets")
	}

	if input.Type == resourcemanager.TerraformSchemaFieldTypeReference {
		if input.ReferenceName == nil {
			return nil, fmt.Errorf("expected a Reference to have a reference but it didn't")
		}

		constant, isConstant := constants[*input.ReferenceName]
		_, isSchemaModel := models[*input.ReferenceName]
		if !isConstant && !isSchemaModel {
			constantNames := getKeys(constants)
			modelNames := getKeys(models)
			return nil, fmt.Errorf("expected the Reference to be either to a Constant or a SchemaModel but didn't get either for %q (Constants %s / Models %s)", *input.ReferenceName, strings.Join(constantNames, ", "), strings.Join(modelNames, ", "))
		}

		if isConstant {
			if isSchemaModel {
				// overkill, but checking for bugs
				return nil, fmt.Errorf("expected the Reference to be either to a Constant or a SchemaModel but got both")
			}

			// TODO: if it's a Constant this should ultimately be output as the constant type itself (e.g. float/int/string)
			// with validation for the possible values - this requires implementing 'validation' types
			out, err := dotnetTypeNameForConstant(constant.Type)
			if err != nil {
				return nil, fmt.Errorf("determining dotnet type name for constant type %q: %+v", string(constant.Type), err)
			}
			return out, nil
		}

		out := fmt.Sprintf("List<%sSchema>", *input.ReferenceName)
		return &out, nil
	}

	if input.NestedObject != nil {
		return nil, fmt.Errorf("non-list/set type had a NestedObject when it shouldn't: %+v", *input.NestedObject)
	}

	// first check if it's a basic type (e.g. int/string)
	if v, ok := basicSchemaFieldTypesToDotNetTypes[input.Type]; ok {
		return &v, nil
	}

	// then check if it's a custom type (e.g. edgezone/identity/tags)
	if v, ok := commonSchemaFieldTypesToDotNetTypes[input.Type]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unimplemented schema field type %q", string(input.Type))
}

func dotnetTypeNameForConstant(input resourcemanager.ConstantType) (*string, error) {
	names := map[resourcemanager.ConstantType]string{
		resourcemanager.IntegerConstant: "int",
		resourcemanager.FloatConstant:   "float",
		resourcemanager.StringConstant:  "string",
	}
	if v, ok := names[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unimplemented constant type: %q", string(input))
}

func getKeys[T any](input map[string]T) []string {
	out := make([]string, 0)

	for k := range input {
		out = append(out, k)
	}
	sort.Strings(out)

	return out
}

var basicSchemaFieldTypesToDotNetTypes = map[resourcemanager.TerraformSchemaFieldType]string{
	resourcemanager.TerraformSchemaFieldTypeBoolean:  "bool",
	resourcemanager.TerraformSchemaFieldTypeDateTime: "System.DateTime",
	resourcemanager.TerraformSchemaFieldTypeFloat:    "float",
	resourcemanager.TerraformSchemaFieldTypeInteger:  "int",
	resourcemanager.TerraformSchemaFieldTypeString:   "string",
}

var commonSchemaFieldTypesToDotNetTypes = map[resourcemanager.TerraformSchemaFieldType]string{
	resourcemanager.TerraformSchemaFieldTypeEdgeZone:                      "CommonSchema.EdgeZone",
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        "CommonSchema.SystemAssignedIdentity",
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: "CommonSchema.SystemAndUserAssignedIdentity",
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  "CommonSchema.SystemOrUserAssignedIdentity",
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          "CommonSchema.UserAssignedIdentity",
	resourcemanager.TerraformSchemaFieldTypeLocation:                      "CommonSchema.Location",
	resourcemanager.TerraformSchemaFieldTypeResourceGroup:                 "CommonSchema.ResourceGroup",
	resourcemanager.TerraformSchemaFieldTypeTags:                          "CommonSchema.Tags",
	resourcemanager.TerraformSchemaFieldTypeZone:                          "CommonSchema.ZoneSingle",
	resourcemanager.TerraformSchemaFieldTypeZones:                         "CommonSchema.ZonesMultiple",
}
