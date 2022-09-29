package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/helpers"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var directAssignmentTypes = map[resourcemanager.TerraformSchemaFieldType]resourcemanager.ApiObjectDefinitionType{
	resourcemanager.TerraformSchemaFieldTypeBoolean: resourcemanager.BooleanApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeFloat:   resourcemanager.FloatApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeInteger: resourcemanager.IntegerApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeString:  resourcemanager.StringApiObjectDefinitionType,

	// TODO: handle/tests
	resourcemanager.TerraformSchemaFieldTypeLocation:               resourcemanager.LocationApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeTags:                   resourcemanager.TagsApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeReference:              resourcemanager.ReferenceApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned: resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
}

var directAssignmentConstantTypesToStrings = map[resourcemanager.TerraformSchemaFieldType]string{
	resourcemanager.TerraformSchemaFieldTypeInteger: "int64",
	resourcemanager.TerraformSchemaFieldTypeFloat:   "float64",
	resourcemanager.TerraformSchemaFieldTypeString:  "string",
}

var _ assignmentType = directAssignmentLine{}

type directAssignmentLine struct{}

// TODO: support for when Mapping is Computed

func (d directAssignmentLine) assignmentForCreateUpdateMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	schemaFieldName, err := singleFieldNameFromFieldPath(mapping.DirectAssignment.SchemaFieldPath)
	if err != nil {
		return nil, fmt.Errorf("obtaining Schema Field Name from Field Path %q: %+v", mapping.DirectAssignment.SchemaFieldPath, err)
	}
	schemaField, ok := schemaModel.Fields[*schemaFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for Schema Model %q was not found", *schemaFieldName, mapping.DirectAssignment.SchemaModelName)
	}

	sdkFieldName, err := singleFieldNameFromFieldPath(mapping.DirectAssignment.SdkFieldPath)
	if err != nil {
		return nil, fmt.Errorf("obtaining SDK Field Name from Field Path %q: %+v", mapping.DirectAssignment.SdkFieldPath, err)
	}
	sdkField, ok := sdkModel.Fields[*sdkFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for SDK Model %q was not found", *sdkFieldName, mapping.DirectAssignment.SdkModelName)
	}

	// check the assignment type - if it's a List these are special-cased
	if schemaField.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList && sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		return d.schemaToSdkMappingBetweenListFields(mapping, schemaField, sdkField, sdkConstant, apiResourcePackageName)
	}

	return d.schemaToSdkMappingBetweenFields(mapping, schemaField, sdkField, sdkConstant)
}

func (d directAssignmentLine) assignmentForReadMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	schemaFieldName, err := singleFieldNameFromFieldPath(mapping.DirectAssignment.SchemaFieldPath)
	if err != nil {
		return nil, fmt.Errorf("obtaining Schema Field Name from Field Path %q: %+v", mapping.DirectAssignment.SchemaFieldPath, err)
	}
	schemaField, ok := schemaModel.Fields[*schemaFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for Schema Model %q was not found", *schemaFieldName, mapping.DirectAssignment.SchemaModelName)
	}

	sdkFieldName, err := singleFieldNameFromFieldPath(mapping.DirectAssignment.SdkFieldPath)
	if err != nil {
		return nil, fmt.Errorf("obtaining SDK Field Name from Field Path %q: %+v", mapping.DirectAssignment.SdkFieldPath, err)
	}
	sdkField, ok := sdkModel.Fields[*sdkFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for SDK Model %q was not found", *sdkFieldName, mapping.DirectAssignment.SdkModelName)
	}

	// check the assignment type - if it's a List these are special-cased
	if schemaField.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList && sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		return d.sdkToSchemaMappingBetweenListFields(mapping, schemaField, sdkField, sdkConstant, apiResourcePackageName)
	}

	return d.sdkToSchemaMappingBetweenFields(mapping, schemaField, sdkField, sdkConstant)
}

func (d directAssignmentLine) schemaToSdkMappingBetweenFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if sdkConstant != nil {
		sdkConstantTypeName := fmt.Sprintf("%s.%s", sdkConstant.apiResourcePackageName, sdkConstant.constantName)
		if schemaField.Required {
			line := fmt.Sprintf("output.%[1]s = %[2]s(input.%[3]s)", mapping.DirectAssignment.SdkFieldPath, sdkConstantTypeName, mapping.DirectAssignment.SchemaFieldPath)
			if sdkField.Optional {
				line = fmt.Sprintf("output.%[1]s = as.Pointer(%[2]s(input.%[3]s))", mapping.DirectAssignment.SdkFieldPath, sdkConstantTypeName, mapping.DirectAssignment.SchemaFieldPath)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
		}

		line := fmt.Sprintf(`
if input.%[3]s != nil {
	output.%[1]s = as.Pointer(%[2]s(*input.%[3]s))
}
`, mapping.DirectAssignment.SdkFieldPath, sdkConstantTypeName, mapping.DirectAssignment.SchemaFieldPath)
		return &line, nil
	}

	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.Type), string(sdkField.ObjectDefinition.Type))
	}
	if v != sdkField.ObjectDefinition.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.Type), string(v), string(sdkField.ObjectDefinition.Type))
	}

	if schemaField.Required {
		line := fmt.Sprintf("output.%[1]s = input.%[2]s", mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath)
		if sdkField.Optional {
			line = fmt.Sprintf("output.%[1]s = &input.%[2]s", mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf(`output.%[1]s = input.%[2]s`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingBetweenListFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	if sdkConstant != nil {
		sdkConstantTypeName := fmt.Sprintf("%s.%s", sdkConstant.apiResourcePackageName, sdkConstant.constantName)
		if schemaField.Required {
			line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
output.%[1]s = %[4]s
`, mapping.DirectAssignment.SdkFieldPath, sdkConstantTypeName, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName)
			if sdkField.Optional {
				line = fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
output.%[1]s = &%[4]s
`, mapping.DirectAssignment.SdkFieldPath, sdkConstantTypeName, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
		}

		line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
if input.%[3]s != nil {
	for _, v := range *input.%[3]s {
		%[4]s = append(%[4]s, %[2]s(v))
	}
}
output.%[1]s = &%[4]s
`, mapping.DirectAssignment.SdkFieldPath, sdkConstantTypeName, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName)
		return &line, nil
	}

	if schemaField.ObjectDefinition.NestedObject == nil {
		return nil, fmt.Errorf("the Schema Model %q Field %q was a List with no NestedObject", mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}
	if sdkField.ObjectDefinition.NestedItem == nil {
		return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath)
	}

	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.NestedObject.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(sdkField.ObjectDefinition.NestedItem.Type))
	}
	if v != sdkField.ObjectDefinition.NestedItem.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(v), string(sdkField.ObjectDefinition.NestedItem.Type))
	}

	variableType, err := sdkField.ObjectDefinition.GolangTypeName(&apiResourcePackageName)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type for Sdk Model %q / Field %q Object Definition: %+v", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, err)
	}

	if schemaField.Required {
		line := fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for _, v := range input.%[2]s {
    %[3]s = append(%[3]s, v)
}
output.%[1]s = %[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *variableType)
		if sdkField.Optional {
			line = fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for _, v := range input.%[2]s {
    %[3]s = append(%[3]s, v)
}
output.%[1]s = &%[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *variableType)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
if input.%[2]s != nil {
	for _, v := range *input.%[2]s {
		%[3]s = append(%[3]s, v)
	}
}
output.%[1]s = &%[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *variableType)
	return &line, nil
}

func (d directAssignmentLine) sdkToSchemaMappingBetweenFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if sdkConstant != nil {
		constantGoType, ok := directAssignmentConstantTypesToStrings[schemaField.ObjectDefinition.Type]
		if !ok {
			return nil, fmt.Errorf("missing mapping between Schema Field Type %q and Constant Type", string(schemaField.ObjectDefinition.Type))
		}
		if schemaField.Required {
			line := fmt.Sprintf("output.%[1]s = %[2]s(input.%[3]s)", mapping.DirectAssignment.SchemaFieldPath, constantGoType, mapping.DirectAssignment.SdkFieldPath)
			if sdkField.Optional {
				line = fmt.Sprintf("output.%[1]s = as.Pointer(%[2]s(input.%[3]s))", mapping.DirectAssignment.SchemaFieldPath, constantGoType, mapping.DirectAssignment.SdkFieldPath)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
		}

		line := fmt.Sprintf(`
	if input.%[3]s != nil {
		output.%[1]s = as.Pointer(%[2]s(*input.%[3]s))
	}
	`, mapping.DirectAssignment.SdkFieldPath, constantGoType, mapping.DirectAssignment.SchemaFieldPath)
		return &line, nil
	}

	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.Type), string(sdkField.ObjectDefinition.Type))
	}
	if v != sdkField.ObjectDefinition.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.Type), string(v), string(sdkField.ObjectDefinition.Type))
	}

	if schemaField.Required {
		line := fmt.Sprintf("output.%[1]s = input.%[2]s", mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
		if sdkField.Optional {
			line = fmt.Sprintf(`
if input.%[2]s != nil {
	output.%[1]s = *input.%[2]s
}
`, mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf(`output.%[1]s = input.%[2]s`, mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
	return &line, nil
}

func (d directAssignmentLine) sdkToSchemaMappingBetweenListFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	if schemaField.ObjectDefinition.NestedObject == nil {
		return nil, fmt.Errorf("the Schema Model %q Field %q was a List with no NestedObject", mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}
	if sdkField.ObjectDefinition.NestedItem == nil {
		return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath)
	}

	if sdkConstant != nil {
		constantGoType, ok := directAssignmentConstantTypesToStrings[schemaField.ObjectDefinition.NestedObject.Type]
		if !ok {
			return nil, fmt.Errorf("missing mapping between Schema Field Type %q and Constant Type", string(schemaField.ObjectDefinition.Type))
		}

		if schemaField.Required {
			line := fmt.Sprintf(`
%[4]s := make(%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
output.%[1]s = %[4]s
`, mapping.DirectAssignment.SdkFieldPath, constantGoType, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName)
			if sdkField.Optional {
				line = fmt.Sprintf(`
%[4]s := make(%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
output.%[1]s = &%[4]s
`, mapping.DirectAssignment.SdkFieldPath, constantGoType, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
		}

		line := fmt.Sprintf(`
%[4]s := make(%[2]s, 0)
if input.%[3]s != nil {
	for _, v := range *input.%[3]s {
		%[4]s = append(%[4]s, %[2]s(v))
	}
}
output.%[1]s = &%[4]s
`, mapping.DirectAssignment.SdkFieldPath, constantGoType, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName)
		return &line, nil
	}

	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.NestedObject.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(sdkField.ObjectDefinition.NestedItem.Type))
	}
	if v != sdkField.ObjectDefinition.NestedItem.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(v), string(sdkField.ObjectDefinition.NestedItem.Type))
	}

	variableType, err := helpers.GolangFieldTypeFromObjectFieldDefinition(schemaField.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("building golang field type from schema nested object definition: %+v", err)
	}

	if schemaField.Required {
		line := fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for _, v := range input.%[1]s {
    %[3]s = append(%[3]s, v)
}
output.%[2]s = %[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *variableType)
		if sdkField.Optional {
			line = fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for _, v := range input.%[1]s {
    %[3]s = append(%[3]s, v)
}
output.%[2]s = &%[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *variableType)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
if input.%[1]s != nil {
	for _, v := range *input.%[1]s {
		%[3]s = append(%[3]s, v)
	}
}
output.%[2]s = &%[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *variableType)
	return &line, nil
}
