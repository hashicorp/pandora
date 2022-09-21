package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var directAssignmentTypes = map[resourcemanager.TerraformSchemaFieldType]resourcemanager.ApiObjectDefinitionType{
	resourcemanager.TerraformSchemaFieldTypeBoolean: resourcemanager.BooleanApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeFloat:   resourcemanager.FloatApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeInteger: resourcemanager.IntegerApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeString:  resourcemanager.StringApiObjectDefinitionType,
}

var directAssignmentConstantTypesToStrings = map[resourcemanager.TerraformSchemaFieldType]string{
	resourcemanager.TerraformSchemaFieldTypeInteger: "int64",
	resourcemanager.TerraformSchemaFieldTypeFloat:   "float64",
	resourcemanager.TerraformSchemaFieldTypeString:  "string",
}

var _ assignmentType = directAssignmentLine{}

type directAssignmentLine struct{}

func (d directAssignmentLine) assignmentForCreateUpdateMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	schemaFieldName, err := singleFieldNameFromFieldPath(mapping.From.SchemaFieldPath)
	if err != nil {
		return nil, fmt.Errorf("obtaining Schema Field Name from Field Path %q: %+v", mapping.From.SchemaFieldPath, err)
	}
	schemaField, ok := schemaModel.Fields[*schemaFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for Schema Model %q was not found", *schemaFieldName, mapping.From.SchemaModelName)
	}

	sdkFieldName, err := singleFieldNameFromFieldPath(mapping.To.SdkFieldPath)
	if err != nil {
		return nil, fmt.Errorf("obtaining SDK Field Name from Field Path %q: %+v", mapping.To.SdkFieldPath, err)
	}
	sdkField, ok := sdkModel.Fields[*sdkFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for SDK Model %q was not found", *sdkFieldName, mapping.To.SdkModelName)
	}

	// check the assignment type - if it's a List these are special-cased
	if schemaField.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList && sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		return d.createUpdateMappingBetweenListFields(mapping, schemaField, sdkField, sdkConstant)
	}

	return d.createUpdateMappingBetweenFields(mapping, schemaField, sdkField, sdkConstant)
}

func (d directAssignmentLine) assignmentForReadMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	schemaFieldName, err := singleFieldNameFromFieldPath(mapping.From.SchemaFieldPath)
	if err != nil {
		return nil, fmt.Errorf("obtaining Schema Field Name from Field Path %q: %+v", mapping.From.SchemaFieldPath, err)
	}
	schemaField, ok := schemaModel.Fields[*schemaFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for Schema Model %q was not found", *schemaFieldName, mapping.From.SchemaModelName)
	}

	sdkFieldName, err := singleFieldNameFromFieldPath(mapping.To.SdkFieldPath)
	if err != nil {
		return nil, fmt.Errorf("obtaining SDK Field Name from Field Path %q: %+v", mapping.To.SdkFieldPath, err)
	}
	sdkField, ok := sdkModel.Fields[*sdkFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for SDK Model %q was not found", *sdkFieldName, mapping.To.SdkModelName)
	}

	// check the assignment type - if it's a List these are special-cased
	if schemaField.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList && sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		return d.readMappingBetweenListFields(mapping, schemaField, sdkField, sdkConstant)
	}

	return d.readMappingBetweenFields(mapping, schemaField, sdkField, sdkConstant)
}

func (d directAssignmentLine) createUpdateMappingBetweenFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if sdkConstant != nil {
		sdkConstantTypeName := fmt.Sprintf("%s.%s", sdkConstant.sdkResourceName, sdkConstant.constantName)
		if schemaField.Required {
			line := fmt.Sprintf("out.%[1]s = %[2]s(input.%[3]s)", mapping.To.SdkFieldPath, sdkConstantTypeName, mapping.From.SchemaFieldPath)
			if sdkField.Optional {
				line = fmt.Sprintf("out.%[1]s = as.Pointer(%[2]s(input.%[3]s))", mapping.To.SdkFieldPath, sdkConstantTypeName, mapping.From.SchemaFieldPath)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
		}

		line := fmt.Sprintf(`
if input.%[3]s != nil {
	out.%[1]s = as.Pointer(%[2]s(*input.%[3]s))
}
`, mapping.To.SdkFieldPath, sdkConstantTypeName, mapping.From.SchemaFieldPath)
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
		line := fmt.Sprintf("out.%[1]s = input.%[2]s", mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath)
		if sdkField.Optional {
			line = fmt.Sprintf("out.%[1]s = &input.%[2]s", mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf(`out.%[1]s = input.%[2]s`, mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath)
	return &line, nil
}

func (d directAssignmentLine) createUpdateMappingBetweenListFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if sdkConstant != nil {
		sdkConstantTypeName := fmt.Sprintf("%s.%s", sdkConstant.sdkResourceName, sdkConstant.constantName)
		if schemaField.Required {
			line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
out.%[1]s = %[4]s
`, mapping.To.SdkFieldPath, sdkConstantTypeName, mapping.From.SchemaFieldPath, sdkField.JsonName)
			if sdkField.Optional {
				line = fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
out.%[1]s = &%[4]s
`, mapping.To.SdkFieldPath, sdkConstantTypeName, mapping.From.SchemaFieldPath, sdkField.JsonName)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
		}

		line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
if input.%[3]s != nil {
	for _, v := range *input.%[3]s {
		%[4]s = append(%[4]s, %[2]s(v))
	}
}
out.%[1]s = &%[4]s
`, mapping.To.SdkFieldPath, sdkConstantTypeName, mapping.From.SchemaFieldPath, sdkField.JsonName)
		return &line, nil
	}

	if schemaField.ObjectDefinition.NestedObject == nil {
		return nil, fmt.Errorf("the Schema Model %q Field %q was a List with no NestedObject", mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
	}
	if sdkField.ObjectDefinition.NestedItem == nil {
		return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", mapping.To.SdkModelName, mapping.To.SdkFieldPath)
	}

	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.NestedObject.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(sdkField.ObjectDefinition.NestedItem.Type))
	}
	if v != sdkField.ObjectDefinition.NestedItem.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(v), string(sdkField.ObjectDefinition.NestedItem.Type))
	}

	variableType, err := sdkField.ObjectDefinition.NestedItem.GolangTypeName(nil)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type for Sdk Model %q / Field %q Object Definition: %+v", mapping.To.SdkModelName, mapping.To.SdkFieldPath, err)
	}

	if schemaField.Required {
		line := fmt.Sprintf(`
%[3]s := make([]%[4]s, 0)
for _, v := range input.%[2]s {
    %[3]s = append(%[3]s, v)
}
out.%[1]s = %[3]s
`, mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath, sdkField.JsonName, *variableType)
		if sdkField.Optional {
			line = fmt.Sprintf(`
%[3]s := make([]%[4]s, 0)
for _, v := range input.%[2]s {
    %[3]s = append(%[3]s, v)
}
out.%[1]s = &%[3]s
`, mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath, sdkField.JsonName, *variableType)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf(`
%[3]s := make([]%[4]s, 0)
if input.%[2]s != nil {
	for _, v := range *input.%[2]s {
		%[3]s = append(%[3]s, v)
	}
}
out.%[1]s = &%[3]s
`, mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath, sdkField.JsonName, *variableType)
	return &line, nil
}

func (d directAssignmentLine) readMappingBetweenFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if sdkConstant != nil {
		constantGoType, ok := directAssignmentConstantTypesToStrings[schemaField.ObjectDefinition.Type]
		if !ok {
			return nil, fmt.Errorf("missing mapping between Schema Field Type %q and Constant Type", string(schemaField.ObjectDefinition.Type))
		}
		if schemaField.Required {
			line := fmt.Sprintf("out.%[1]s = %[2]s(input.%[3]s)", mapping.From.SchemaFieldPath, constantGoType, mapping.To.SdkFieldPath)
			if sdkField.Optional {
				line = fmt.Sprintf("out.%[1]s = as.Pointer(%[2]s(input.%[3]s))", mapping.From.SchemaFieldPath, constantGoType, mapping.To.SdkFieldPath)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
		}

		line := fmt.Sprintf(`
	if input.%[3]s != nil {
		out.%[1]s = as.Pointer(%[2]s(*input.%[3]s))
	}
	`, mapping.To.SdkFieldPath, constantGoType, mapping.From.SchemaFieldPath)
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
		line := fmt.Sprintf("out.%[1]s = input.%[2]s", mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath)
		if sdkField.Optional {
			line = fmt.Sprintf(`
if input.%[2]s != nil {
	out.%[1]s = *input.%[2]s
}
`, mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf(`out.%[1]s = input.%[2]s`, mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath)
	return &line, nil
}

func (d directAssignmentLine) readMappingBetweenListFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if schemaField.ObjectDefinition.NestedObject == nil {
		return nil, fmt.Errorf("the Schema Model %q Field %q was a List with no NestedObject", mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
	}
	if sdkField.ObjectDefinition.NestedItem == nil {
		return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", mapping.To.SdkModelName, mapping.To.SdkFieldPath)
	}

	if sdkConstant != nil {
		constantGoType, ok := directAssignmentConstantTypesToStrings[schemaField.ObjectDefinition.NestedObject.Type]
		if !ok {
			return nil, fmt.Errorf("missing mapping between Schema Field Type %q and Constant Type", string(schemaField.ObjectDefinition.Type))
		}

		if schemaField.Required {
			line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
out.%[1]s = %[4]s
`, mapping.To.SdkFieldPath, constantGoType, mapping.From.SchemaFieldPath, sdkField.JsonName)
			if sdkField.Optional {
				line = fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
out.%[1]s = &%[4]s
`, mapping.To.SdkFieldPath, constantGoType, mapping.From.SchemaFieldPath, sdkField.JsonName)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
		}

		line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
if input.%[3]s != nil {
	for _, v := range *input.%[3]s {
		%[4]s = append(%[4]s, %[2]s(v))
	}
}
out.%[1]s = &%[4]s
`, mapping.To.SdkFieldPath, constantGoType, mapping.From.SchemaFieldPath, sdkField.JsonName)
		return &line, nil
	}

	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.NestedObject.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(sdkField.ObjectDefinition.NestedItem.Type))
	}
	if v != sdkField.ObjectDefinition.NestedItem.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(v), string(sdkField.ObjectDefinition.NestedItem.Type))
	}

	variableType, err := sdkField.ObjectDefinition.NestedItem.GolangTypeName(nil)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type for Sdk Model %q / Field %q Object Definition: %+v", mapping.To.SdkModelName, mapping.To.SdkFieldPath, err)
	}

	if schemaField.Required {
		line := fmt.Sprintf(`
%[3]s := make([]%[4]s, 0)
for _, v := range input.%[1]s {
    %[3]s = append(%[3]s, v)
}
out.%[2]s = %[3]s
`, mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath, sdkField.JsonName, *variableType)
		if sdkField.Optional {
			line = fmt.Sprintf(`
%[3]s := make([]%[4]s, 0)
for _, v := range input.%[1]s {
    %[3]s = append(%[3]s, v)
}
out.%[2]s = &%[3]s
`, mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath, sdkField.JsonName, *variableType)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf(`
%[3]s := make([]%[4]s, 0)
if input.%[1]s != nil {
	for _, v := range *input.%[1]s {
		%[3]s = append(%[3]s, v)
	}
}
out.%[2]s = &%[3]s
`, mapping.To.SdkFieldPath, mapping.From.SchemaFieldPath, sdkField.JsonName, *variableType)
	return &line, nil
}
