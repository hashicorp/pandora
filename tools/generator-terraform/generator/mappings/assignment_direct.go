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
	resourcemanager.TerraformSchemaFieldTypeDateTime:               resourcemanager.DateTimeApiObjectDefinitionType,
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

	// check if it requires a custom transform
	if v, ok := transformTypes[schemaField.ObjectDefinition.Type]; ok && v == sdkField.ObjectDefinition.Type {
		return d.schemaToSdkMappingRequiringTransform(mapping, schemaField, sdkField, sdkConstant, apiResourcePackageName)
	}

	// check the assignment type - if it's a List these are special-cased
	if schemaField.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList && sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		// TODO: the Schema maybe a List but the SDK can be a Reference too, fwiw - also needs the read

		if schemaField.ObjectDefinition.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeReference && sdkField.ObjectDefinition.NestedItem.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			return d.schemaToSdkMappingBetweenListOfReferenceFields(mapping, schemaField, sdkField, apiResourcePackageName)
		}

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

	// check if it requires a custom transform
	if v, ok := transformTypes[schemaField.ObjectDefinition.Type]; ok && v == sdkField.ObjectDefinition.Type {
		return d.sdkToSchemaMappingRequiringTransform(mapping, schemaField, sdkField, sdkConstant, apiResourcePackageName)
	}

	// check the assignment type - if it's a List these are special-cased
	if schemaField.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList && sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		// TODO: the Schema maybe a List but the SDK can be a Reference too, fwiw - also needs the read

		if schemaField.ObjectDefinition.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeReference && sdkField.ObjectDefinition.NestedItem.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			return d.sdkToSchemaMappingBetweenListOfReferenceFields(mapping, schemaField, sdkField, apiResourcePackageName)
		}

		return d.sdkToSchemaMappingBetweenListFields(mapping, schemaField, sdkField, sdkConstant, apiResourcePackageName)
	}

	return d.sdkToSchemaMappingBetweenFields(mapping, schemaField, sdkField, sdkConstant)
}

var transformTypes = map[resourcemanager.TerraformSchemaFieldType]resourcemanager.ApiObjectDefinitionType{
	resourcemanager.TerraformSchemaFieldTypeLocation:                      resourcemanager.LocationApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType, // TODO add support for List Api Object
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType,  // TODO add support for List Api Object
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          resourcemanager.UserAssignedIdentityListApiObjectDefinitionType,         // TODO add support for Map Api Object
	resourcemanager.TerraformSchemaFieldTypeTags:                          resourcemanager.TagsApiObjectDefinitionType,
}
var transformRequiredExpandFunctions = map[resourcemanager.TerraformSchemaFieldType]func(outputAssignment, outputVariableName, inputAssignment string) string{
	resourcemanager.TerraformSchemaFieldTypeLocation: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = location.Normalize(%s)", outputAssignment, inputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemAssignedFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemAndUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemOrUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemOrUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandUserAssignedListFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding UserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeTags: func(outputAssignment, _, inputAssignment string) string {
		return fmt.Sprintf("%s = tags.Expand(%s)", outputAssignment, inputAssignment)
	},
}
var transformOptionalExpandFunctions = map[resourcemanager.TerraformSchemaFieldType]func(outputAssignment, outputVariableName, inputAssignment string) string{
	resourcemanager.TerraformSchemaFieldTypeLocation: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = pointer.To(location.Normalize(%s))", outputAssignment, inputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		// TODO: tests for Identity & add support for Zones
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemAssignedFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemAndUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemOrUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemOrUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandUserAssignedListFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding UserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeTags: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = tags.Expand(%s)", outputAssignment, inputAssignment)
	},
}
var transformRequiredFlattenFunctions = map[resourcemanager.TerraformSchemaFieldType]func(outputAssignment, outputVariableName, inputAssignment string) string{
	resourcemanager.TerraformSchemaFieldTypeLocation: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = location.Normalize(%s)", outputAssignment, inputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemAssignedFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemAndUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemOrUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemOrUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenUserAssignedListToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening UserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeTags: func(outputAssignment, _, inputAssignment string) string {
		return fmt.Sprintf("%s = tags.Flatten(%s)", outputAssignment, inputAssignment)
	},
}
var transformOptionalFlattenFunctions = map[resourcemanager.TerraformSchemaFieldType]func(outputAssignment, outputVariableName, inputAssignment string) string{
	resourcemanager.TerraformSchemaFieldTypeLocation: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = location.NormalizeNilable(%s)", outputAssignment, inputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemAssignedFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemAndUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemOrUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemOrUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenUserAssignedListToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening UserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	},
	resourcemanager.TerraformSchemaFieldTypeTags: func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = tags.Flatten(%s)", outputAssignment, inputAssignment)
	},
}

func (d directAssignmentLine) schemaToSdkMappingBetweenFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if sdkConstant != nil {
		sdkConstantTypeName := fmt.Sprintf("%s.%s", sdkConstant.apiResourcePackageName, sdkConstant.constantName)
		if schemaField.Required {
			line := fmt.Sprintf("output.%[1]s = %[2]s(input.%[3]s)", mapping.DirectAssignment.SdkFieldPath, sdkConstantTypeName, mapping.DirectAssignment.SchemaFieldPath)
			if sdkField.Optional {
				line = fmt.Sprintf("output.%[1]s = pointer.To(%[2]s(input.%[3]s))", mapping.DirectAssignment.SdkFieldPath, sdkConstantTypeName, mapping.DirectAssignment.SchemaFieldPath)
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
	output.%[1]s = pointer.To(%[2]s(*input.%[3]s))
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
	line := fmt.Sprintf(`output.%[1]s = &input.%[2]s`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath)
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

func (d directAssignmentLine) schemaToSdkMappingBetweenListOfReferenceFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, apiResourcePackageName string) (*string, error) {
	listVariableType, err := sdkField.ObjectDefinition.GolangTypeName(&apiResourcePackageName)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type for Sdk Model %q / Field %q Object Definition: %+v", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, err)
	}

	listItemVariableReferenceType, err := sdkField.ObjectDefinition.NestedItem.GolangTypeName(&apiResourcePackageName)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type for Sdk Model %q / Field %q Nested Object Definition: %+v", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, err)
	}
	listItemVariableReferenceName := *sdkField.ObjectDefinition.NestedItem.ReferenceName

	schemaFieldTypeName := *schemaField.ObjectDefinition.NestedObject.ReferenceName

	if schemaField.Required {
		line := fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for i, v := range input.%[2]s {
	item := %[5]s{}
	if err := r.map%[6]sTo%[7]s(v, &item); err != nil {
		return fmt.Errorf("mapping %[6]s item %%d to %[7]s: %%+v", i, err)
	} 
    %[3]s = append(%[3]s, item)
}
output.%[1]s = %[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *listVariableType, *listItemVariableReferenceType, schemaFieldTypeName, listItemVariableReferenceName)
		if sdkField.Optional {
			line = fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for i, v := range input.%[2]s {
	item := %[5]s{}
	if err := r.map%[6]sTo%[7]s(v, &item); err != nil {
		return fmt.Errorf("mapping %[6]s item %%d to %[7]s: %%+v", i, err)
	} 
    %[3]s = append(%[3]s, item)
}
output.%[1]s = &%[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *listVariableType, *listItemVariableReferenceType, schemaFieldTypeName, listItemVariableReferenceName)
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
	for i, v := range *input.%[2]s {
		item := %[5]s{}
		if err := r.map%[6]sTo%[7]s(v, &item); err != nil {
			return fmt.Errorf("mapping %[6]s item %%d to %[7]s: %%+v", i, err)
		} 
		%[3]s = append(%[3]s, item)
	}
}
output.%[1]s = &%[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, *listVariableType, *listItemVariableReferenceType, schemaFieldTypeName, listItemVariableReferenceName)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingBetweenLocation(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, _ *assignmentConstantDetails, _ string) (*string, error) {
	if schemaField.Required {
		line := fmt.Sprintf("output.%[1]s = location.Normalize(input.%[2]s)", mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
		if sdkField.Optional {
			line = fmt.Sprintf("output.%[1]s = pointer.To(location.Normalize(input.%[2]s))", mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf("output.%[1]s = pointer.To(location.Normalize(input.%[2]s))", mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingBetweenTags(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, _ *assignmentConstantDetails, _ string) (*string, error) {
	if schemaField.Required {
		line := fmt.Sprintf("output.%[1]s = tags.Expand(input.%[2]s)", mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
		if sdkField.Optional {
			line = fmt.Sprintf("output.%[1]s = pointer.To(tags.Expand(input.%[2]s))", mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}

	// optional -> optional
	line := fmt.Sprintf("output.%[1]s = pointer.To(tags.Expand(input.%[2]s))", mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingRequiringTransform(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, _ *assignmentConstantDetails, _ string) (*string, error) {
	outputAssignment := fmt.Sprintf("output.%s", mapping.DirectAssignment.SchemaFieldPath)
	outputVariable := sdkField.JsonName
	inputAssignment := fmt.Sprintf("input.%s", mapping.DirectAssignment.SdkFieldPath)

	if schemaField.Required {
		transform, ok := transformRequiredExpandFunctions[schemaField.ObjectDefinition.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing required expand transform function for Schema Field Object Definition Type %q", string(schemaField.ObjectDefinition.Type))
		}
		if sdkField.Optional {
			transform, ok = transformOptionalExpandFunctions[schemaField.ObjectDefinition.Type]
			if !ok {
				return nil, fmt.Errorf("internal-error: missing optional expand transform function for Schema Field Object Definition Type %q", string(schemaField.ObjectDefinition.Type))
			}
		}
		transformLine := transform(outputAssignment, outputVariable, inputAssignment)
		return &transformLine, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}

	// optional -> optional
	transform, ok := transformOptionalExpandFunctions[schemaField.ObjectDefinition.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing optional expand transform function for Schema Field Object Definition Type %q", string(schemaField.ObjectDefinition.Type))
	}
	transformLine := transform(outputAssignment, outputVariable, inputAssignment)
	return &transformLine, nil
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
				line = fmt.Sprintf("output.%[1]s = pointer.To(%[2]s(input.%[3]s))", mapping.DirectAssignment.SchemaFieldPath, constantGoType, mapping.DirectAssignment.SdkFieldPath)
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
		output.%[1]s = pointer.To(%[2]s(*input.%[3]s))
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
	line := fmt.Sprintf(`output.%[1]s = pointer.From(input.%[2]s)`, mapping.DirectAssignment.SchemaFieldPath, mapping.DirectAssignment.SdkFieldPath)
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
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
output.%[1]s = %[4]s
`, mapping.DirectAssignment.SdkFieldPath, constantGoType, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName)
			if sdkField.Optional {
				line = fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
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
%[4]s := make([]%[2]s, 0)
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

func (d directAssignmentLine) sdkToSchemaMappingBetweenListOfReferenceFields(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, apiResourcePackageName string) (*string, error) {
	sdkFieldTypeName := *sdkField.ObjectDefinition.NestedItem.ReferenceName
	schemaFieldTypeName := *schemaField.ObjectDefinition.NestedObject.ReferenceName

	if schemaField.Required {
		line := fmt.Sprintf(`
%[3]s := make([]%[5]s, 0)
for i, v := range input.%[1]s {
	item := %[5]s{}
	if err := r.map%[4]sTo%[5]s(v, &item); err != nil {
		return fmt.Errorf("mapping %[5]s item %%d to %[4]s: %%+v", i, err)
	} 
    %[3]s = append(%[3]s, item)
}
output.%[2]s = %[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, sdkFieldTypeName, schemaFieldTypeName)

		if sdkField.Optional {
			line = fmt.Sprintf(`
%[3]s := make([]%[5]s, 0)
for i, v := range input.%[1]s {
    item := %[5]s{}
	if err := r.map%[4]sTo%[5]s(v, &item); err != nil {
		return fmt.Errorf("mapping %[5]s item %%d to %[4]s: %%+v", i, err)
	} 
    %[3]s = append(%[3]s, item)
}
output.%[2]s = &%[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, sdkFieldTypeName, schemaFieldTypeName)
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
%[3]s := make([]%[5]s, 0)
if input.%[1]s != nil {
	for i, v := range *input.%[1]s {
		item := %[5]s{}
		if err := r.map%[4]sTo%[5]s(v, &item); err != nil {
			return fmt.Errorf("mapping %[5]s item %%d to %[4]s: %%+v", i, err)
		} 
		%[3]s = append(%[3]s, item)
	}
}
output.%[2]s = &%[3]s
`, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaFieldPath, sdkField.JsonName, sdkFieldTypeName, schemaFieldTypeName)
	return &line, nil
}

func (d directAssignmentLine) sdkToSchemaMappingRequiringTransform(mapping resourcemanager.FieldMappingDefinition, schemaField resourcemanager.TerraformSchemaFieldDefinition, sdkField resourcemanager.FieldDetails, _ *assignmentConstantDetails, _ string) (*string, error) {
	outputAssignment := fmt.Sprintf("output.%s", mapping.DirectAssignment.SchemaFieldPath)
	outputVariable := sdkField.JsonName
	inputAssignment := fmt.Sprintf("input.%s", mapping.DirectAssignment.SdkFieldPath)

	if schemaField.Required {
		transform, ok := transformRequiredFlattenFunctions[schemaField.ObjectDefinition.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing required flatten transform function for Schema Field Object Definition Type %q", string(schemaField.ObjectDefinition.Type))
		}
		if sdkField.Optional {
			transform, ok = transformOptionalFlattenFunctions[schemaField.ObjectDefinition.Type]
			if !ok {
				return nil, fmt.Errorf("internal-error: missing optional flatten transform function for Schema Field Object Definition Type %q", string(schemaField.ObjectDefinition.Type))
			}
		}
		transformLine := transform(outputAssignment, outputVariable, inputAssignment)
		return &transformLine, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SdkModelName, mapping.DirectAssignment.SdkFieldPath, mapping.DirectAssignment.SchemaModelName, mapping.DirectAssignment.SchemaFieldPath)
	}

	// optional -> optional
	transform, ok := transformOptionalFlattenFunctions[schemaField.ObjectDefinition.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing optional flatten transform function for Schema Field Object Definition Type %q", string(schemaField.ObjectDefinition.Type))
	}
	transformLine := transform(outputAssignment, outputVariable, inputAssignment)
	return &transformLine, nil
}
