// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorHelpers "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/helpers"
)

var directAssignmentTypes = map[models.TerraformSchemaObjectDefinitionType]models.SDKObjectDefinitionType{
	models.BooleanTerraformSchemaObjectDefinitionType: models.BooleanSDKObjectDefinitionType,
	models.FloatTerraformSchemaObjectDefinitionType:   models.FloatSDKObjectDefinitionType,
	models.IntegerTerraformSchemaObjectDefinitionType: models.IntegerSDKObjectDefinitionType,
	models.StringTerraformSchemaObjectDefinitionType:  models.StringSDKObjectDefinitionType,

	// TODO: handle/tests
	models.DateTimeTerraformSchemaObjectDefinitionType:               models.DateTimeSDKObjectDefinitionType,
	models.LocationTerraformSchemaObjectDefinitionType:               models.LocationSDKObjectDefinitionType,
	models.TagsTerraformSchemaObjectDefinitionType:                   models.TagsSDKObjectDefinitionType,
	models.ReferenceTerraformSchemaObjectDefinitionType:              models.ReferenceSDKObjectDefinitionType,
	models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType: models.SystemAssignedIdentitySDKObjectDefinitionType,
}

var directAssignmentConstantTypesToStrings = map[models.TerraformSchemaObjectDefinitionType]string{
	models.FloatTerraformSchemaObjectDefinitionType:   "float64",
	models.IntegerTerraformSchemaObjectDefinitionType: "int64",
	models.StringTerraformSchemaObjectDefinitionType:  "string",
}

var _ assignmentType = directAssignmentLine{}

type directAssignmentLine struct{}

// TODO: support for when Mapping is Computed

func (d directAssignmentLine) assignmentForCreateUpdateMapping(mapping models.TerraformFieldMappingDefinition, schemaModel models.TerraformSchemaModel, sdkModel models.SDKModel, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	directAssignment, ok := mapping.(models.TerraformDirectAssignmentFieldMappingDefinition)
	if !ok {
		return nil, fmt.Errorf("internal-error: expected a DirectAssignment mapping but got %+v", mapping)
	}

	schemaField, ok := schemaModel.Fields[directAssignment.DirectAssignment.TerraformSchemaFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for Schema Model %q was not found", directAssignment.DirectAssignment.TerraformSchemaFieldName, directAssignment.DirectAssignment.TerraformSchemaModelName)
	}

	sdkField, ok := sdkModel.Fields[directAssignment.DirectAssignment.SDKFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for SDK Model %q was not found", directAssignment.DirectAssignment.SDKFieldName, directAssignment.DirectAssignment.SDKModelName)
	}

	// check if it requires a custom transform
	if transform := findDirectAssignmentTransform(schemaField.ObjectDefinition.Type, sdkField.ObjectDefinition.Type); transform != nil {
		return d.schemaToSdkMappingRequiringTransform(directAssignment, schemaField, sdkField, sdkConstant, apiResourcePackageName, transform)
	}

	// check the assignment type - if it's a List these are special-cased
	if schemaField.ObjectDefinition.Type == models.ListTerraformSchemaObjectDefinitionType && sdkField.ObjectDefinition.Type == models.ListSDKObjectDefinitionType {
		// TODO: the Schema maybe a List but the SDK can be a Reference too, fwiw - also needs the read

		if schemaField.ObjectDefinition.NestedObject.Type == models.ReferenceTerraformSchemaObjectDefinitionType && sdkField.ObjectDefinition.NestedItem.Type == models.ReferenceSDKObjectDefinitionType {
			return d.schemaToSdkMappingBetweenListOfReferenceFields(directAssignment, schemaField, sdkField, apiResourcePackageName)
		}

		return d.schemaToSdkMappingBetweenListFields(directAssignment, schemaField, sdkField, sdkConstant, apiResourcePackageName)
	}

	if schemaField.ObjectDefinition.Type == models.ReferenceTerraformSchemaObjectDefinitionType && sdkField.ObjectDefinition.NestedItem == nil {
		return d.schemaToSdkMappingBetweenFieldAndBlock(directAssignment, schemaField, sdkField)
	}

	return d.schemaToSdkMappingBetweenFields(directAssignment, schemaField, sdkField, sdkConstant)
}

func (d directAssignmentLine) assignmentForReadMapping(mapping models.TerraformFieldMappingDefinition, schemaModel models.TerraformSchemaModel, sdkModel models.SDKModel, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	directAssignment, ok := mapping.(models.TerraformDirectAssignmentFieldMappingDefinition)
	if !ok {
		return nil, fmt.Errorf("internal-error: expected a DirectAssignment mapping but got %+v", mapping)
	}

	schemaField, ok := schemaModel.Fields[directAssignment.DirectAssignment.TerraformSchemaFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for Schema Model %q was not found", directAssignment.DirectAssignment.TerraformSchemaFieldName, directAssignment.DirectAssignment.TerraformSchemaModelName)
	}

	sdkField, ok := sdkModel.Fields[directAssignment.DirectAssignment.SDKFieldName]
	if !ok {
		return nil, fmt.Errorf("the Field %q for SDK Model %q was not found", directAssignment.DirectAssignment.SDKFieldName, directAssignment.DirectAssignment.SDKModelName)
	}

	// check if it requires a custom transform
	if transform := findDirectAssignmentTransform(schemaField.ObjectDefinition.Type, sdkField.ObjectDefinition.Type); transform != nil {
		return d.sdkToSchemaMappingRequiringTransform(directAssignment, schemaField, sdkField, sdkConstant, apiResourcePackageName, transform)
	}

	// check the assignment type - if it's a List these are special-cased
	if schemaField.ObjectDefinition.Type == models.ListTerraformSchemaObjectDefinitionType && sdkField.ObjectDefinition.Type == models.ListSDKObjectDefinitionType {
		// TODO: the Schema maybe a List but the SDK can be a Reference too, fwiw - also needs the read

		if schemaField.ObjectDefinition.NestedObject.Type == models.ReferenceTerraformSchemaObjectDefinitionType && sdkField.ObjectDefinition.NestedItem.Type == models.ReferenceSDKObjectDefinitionType {
			return d.sdkToSchemaMappingBetweenListOfReferenceFields(directAssignment, schemaField, sdkField, apiResourcePackageName)
		}

		return d.sdkToSchemaMappingBetweenListFields(directAssignment, schemaField, sdkField, sdkConstant, apiResourcePackageName)
	}

	if schemaField.ObjectDefinition.Type == models.ReferenceTerraformSchemaObjectDefinitionType && sdkField.ObjectDefinition.NestedItem == nil {
		return d.sdkToSchemaMappingBetweenFieldAndBlock(directAssignment, schemaField, sdkField)
	}

	return d.sdkToSchemaMappingBetweenFields(directAssignment, schemaField, sdkField, sdkConstant)
}

func (d directAssignmentLine) schemaToSdkMappingBetweenFieldAndBlock(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField) (*string, error) {
	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.Type), string(sdkField.ObjectDefinition.Type))
	}
	if v != sdkField.ObjectDefinition.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.Type), string(v), string(sdkField.ObjectDefinition.Type))
	}

	if schemaField.ObjectDefinition.ReferenceName == nil {
		return nil, fmt.Errorf("expected a schema reference name, but it was nil")
	}

	line := fmt.Sprintf(`if len(input.%[1]s) > 0 {
		if err := r.map%[2]sTo%[3]s(input.%[1]s[0], output); err != nil {
			return err
		}
	}`, mapping.DirectAssignment.SDKFieldName, *schemaField.ObjectDefinition.ReferenceName, mapping.DirectAssignment.SDKModelName)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingBetweenFields(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, sdkConstant *assignmentConstantDetails) (*string, error) {
	if sdkConstant != nil {
		sdkConstantTypeName := fmt.Sprintf("%s.%s", sdkConstant.apiResourcePackageName, sdkConstant.constantName)
		if schemaField.Required {
			line := fmt.Sprintf("output.%[1]s = %[2]s(input.%[3]s)", mapping.DirectAssignment.SDKFieldName, sdkConstantTypeName, mapping.DirectAssignment.TerraformSchemaFieldName)
			if sdkField.Optional {
				line = fmt.Sprintf("output.%[1]s = pointer.To(%[2]s(input.%[3]s))", mapping.DirectAssignment.SDKFieldName, sdkConstantTypeName, mapping.DirectAssignment.TerraformSchemaFieldName)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
		}

		line := fmt.Sprintf(`
output.%[1]s = pointer.To(%[2]s(input.%[3]s))
`, mapping.DirectAssignment.SDKFieldName, sdkConstantTypeName, mapping.DirectAssignment.TerraformSchemaFieldName)
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
		line := fmt.Sprintf("output.%[1]s = input.%[2]s", mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName)
		if sdkField.Optional {
			line = fmt.Sprintf("output.%[1]s = &input.%[2]s", mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
	}

	if schemaField.Computed && (!schemaField.Optional && !schemaField.Required) {
		// We never send computed only fields?
		line := ""
		return &line, nil
	}

	// optional -> optional
	line := fmt.Sprintf(`output.%[1]s = &input.%[2]s`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingBetweenListFields(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	if sdkConstant != nil {
		sdkConstantTypeName := fmt.Sprintf("%s.%s", sdkConstant.apiResourcePackageName, sdkConstant.constantName)
		if schemaField.Required {
			line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
output.%[1]s = %[4]s
`, mapping.DirectAssignment.SDKFieldName, sdkConstantTypeName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName)
			if sdkField.Optional {
				line = fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
output.%[1]s = &%[4]s
`, mapping.DirectAssignment.SDKFieldName, sdkConstantTypeName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
		}

		line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
if input.%[3]s != nil {
	for _, v := range *input.%[3]s {
		%[4]s = append(%[4]s, %[2]s(v))
	}
}
output.%[1]s = &%[4]s
`, mapping.DirectAssignment.SDKFieldName, sdkConstantTypeName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName)
		return &line, nil
	}

	if schemaField.ObjectDefinition.NestedObject == nil {
		return nil, fmt.Errorf("the Schema Model %q Field %q was a List with no NestedObject", mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
	}
	if sdkField.ObjectDefinition.NestedItem == nil {
		return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName)
	}

	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.NestedObject.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(sdkField.ObjectDefinition.NestedItem.Type))
	}
	if v != sdkField.ObjectDefinition.NestedItem.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(v), string(sdkField.ObjectDefinition.NestedItem.Type))
	}

	variableType, err := helpers.GolangTypeForSDKObjectDefinition(sdkField.ObjectDefinition, &apiResourcePackageName, nil, nil)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type for Sdk Model %q / Field %q Object Definition: %+v", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, err)
	}

	if schemaField.Required {
		line := fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for _, v := range input.%[2]s {
    %[3]s = append(%[3]s, v)
}
output.%[1]s = %[3]s
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *variableType)
		if sdkField.Optional {
			line = fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for _, v := range input.%[2]s {
    %[3]s = append(%[3]s, v)
}
output.%[1]s = &%[3]s
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *variableType)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *variableType)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingBetweenListOfReferenceFields(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, apiResourcePackageName string) (*string, error) {
	listVariableType, err := helpers.GolangTypeForSDKObjectDefinition(sdkField.ObjectDefinition, &apiResourcePackageName, nil, nil)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type for Sdk Model %q / Field %q Object Definition: %+v", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, err)
	}

	listItemVariableReferenceType, err := helpers.GolangTypeForSDKObjectDefinition(*sdkField.ObjectDefinition.NestedItem, &apiResourcePackageName, nil, nil)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type for Sdk Model %q / Field %q Nested Object Definition: %+v", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, err)
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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *listVariableType, *listItemVariableReferenceType, schemaFieldTypeName, listItemVariableReferenceName)
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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *listVariableType, *listItemVariableReferenceType, schemaFieldTypeName, listItemVariableReferenceName)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *listVariableType, *listItemVariableReferenceType, schemaFieldTypeName, listItemVariableReferenceName)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingBetweenLocation(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, _ *assignmentConstantDetails, _ string) (*string, error) {
	if schemaField.Required {
		line := fmt.Sprintf("output.%[1]s = location.Normalize(input.%[2]s)", mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
		if sdkField.Optional {
			line = fmt.Sprintf("output.%[1]s = pointer.To(location.Normalize(input.%[2]s))", mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
	}

	// optional -> optional
	line := fmt.Sprintf("output.%[1]s = pointer.To(location.Normalize(input.%[2]s))", mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingBetweenTags(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, _ *assignmentConstantDetails, _ string) (*string, error) {
	if schemaField.Required {
		line := fmt.Sprintf("output.%[1]s = tags.Expand(input.%[2]s)", mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
		if sdkField.Optional {
			line = fmt.Sprintf("output.%[1]s = pointer.To(tags.Expand(input.%[2]s))", mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
	}

	// optional -> optional
	line := fmt.Sprintf("output.%[1]s = pointer.To(tags.Expand(input.%[2]s))", mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
	return &line, nil
}

func (d directAssignmentLine) schemaToSdkMappingRequiringTransform(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, _ *assignmentConstantDetails, _ string, transform directAssignmentTransform) (*string, error) {
	outputAssignment := fmt.Sprintf("output.%s", mapping.DirectAssignment.TerraformSchemaFieldName)
	outputVariable := sdkField.JsonName
	inputAssignment := fmt.Sprintf("input.%s", mapping.DirectAssignment.SDKFieldName)

	if schemaField.Required {
		transformLineFunc := transform.requiredExpandFuncBody()
		if sdkField.Optional {
			transformLineFunc = transform.optionalExpandFuncBody()
		}
		transformLine := transformLineFunc(outputAssignment, outputVariable, inputAssignment)
		return &transformLine, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
	}

	// optional -> optional
	transformLineFunc := transform.optionalExpandFuncBody()
	transformLine := transformLineFunc(outputAssignment, outputVariable, inputAssignment)
	return &transformLine, nil
}

func (d directAssignmentLine) sdkToSchemaMappingBetweenFieldAndBlock(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField) (*string, error) {
	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.Type), string(sdkField.ObjectDefinition.Type))
	}
	if v != sdkField.ObjectDefinition.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.Type), string(v), string(sdkField.ObjectDefinition.Type))
	}

	if schemaField.ObjectDefinition.ReferenceName == nil {
		return nil, fmt.Errorf("expected a schema reference name, but it was nil")
	}

	line := fmt.Sprintf(`tmp%[1]s := &%[3]s{}
	if err := r.map%[2]sTo%[3]s(input, tmp%[1]s); err != nil {
		return err
	} else {
		output.%[1]s = make([]%[3]s, 0)
		output.%[1]s = append(output.%[1]s, *tmp%[1]s)
	}`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.SDKModelName, *schemaField.ObjectDefinition.ReferenceName)
	return &line, nil
}

func (d directAssignmentLine) sdkToSchemaMappingBetweenFields(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, sdkConstant *assignmentConstantDetails) (*string, error) {
	if sdkConstant != nil {
		constantGoType, ok := directAssignmentConstantTypesToStrings[schemaField.ObjectDefinition.Type]
		if !ok {
			return nil, fmt.Errorf("missing mapping between Schema Field Type %q and Constant Type", string(schemaField.ObjectDefinition.Type))
		}
		if schemaField.Required {
			line := fmt.Sprintf("output.%[1]s = %[2]s(input.%[3]s)", mapping.DirectAssignment.TerraformSchemaFieldName, constantGoType, mapping.DirectAssignment.SDKFieldName)
			if sdkField.Optional {
				line = fmt.Sprintf("output.%[1]s = pointer.To(%[2]s(input.%[3]s))", mapping.DirectAssignment.TerraformSchemaFieldName, constantGoType, mapping.DirectAssignment.SDKFieldName)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
		}

		if schemaField.Computed && (!schemaField.Optional && !schemaField.Required) {
			line := fmt.Sprintf(`
	if input.%[3]s != nil {
		output.%[1]s = %[2]s(*input.%[3]s)
	}
	`, mapping.DirectAssignment.SDKFieldName, constantGoType, mapping.DirectAssignment.TerraformSchemaFieldName)
			return &line, nil
		}

		line := fmt.Sprintf(`
	if input.%[3]s != nil {
		output.%[1]s = %[2]s(*input.%[3]s)
	}
	`, mapping.DirectAssignment.SDKFieldName, constantGoType, mapping.DirectAssignment.TerraformSchemaFieldName)
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
		line := fmt.Sprintf("output.%[1]s = input.%[2]s", mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
		if sdkField.Optional {
			line = fmt.Sprintf(`
if input.%[2]s != nil {
	output.%[1]s = *input.%[2]s
}
`, mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
	}

	// optional -> optional
	line := fmt.Sprintf(`output.%[1]s = pointer.From(input.%[2]s)`, mapping.DirectAssignment.TerraformSchemaFieldName, mapping.DirectAssignment.SDKFieldName)
	return &line, nil
}

func (d directAssignmentLine) sdkToSchemaMappingBetweenListFields(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	if schemaField.ObjectDefinition.NestedObject == nil {
		return nil, fmt.Errorf("the Schema Model %q Field %q was a List with no NestedObject", mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
	}
	if sdkField.ObjectDefinition.NestedItem == nil {
		return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName)
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
`, mapping.DirectAssignment.SDKFieldName, constantGoType, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName)
			if sdkField.Optional {
				line = fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
for _, v := range input.%[3]s {
	%[4]s = append(%[4]s, %[2]s(v))
}
output.%[1]s = &%[4]s
`, mapping.DirectAssignment.SDKFieldName, constantGoType, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName)
			}
			return &line, nil
		}

		if sdkField.Required {
			// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
			// TODO: handle where it's defaulted?
			return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
		}

		line := fmt.Sprintf(`
%[4]s := make([]%[2]s, 0)
if input.%[3]s != nil {
	for _, v := range *input.%[3]s {
		%[4]s = append(%[4]s, %[2]s(v))
	}
}
output.%[1]s = &%[4]s
`, mapping.DirectAssignment.SDKFieldName, constantGoType, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName)
		return &line, nil
	}

	v, ok := directAssignmentTypes[schemaField.ObjectDefinition.NestedObject.Type]
	if !ok {
		return nil, fmt.Errorf("a DirectAssignment wasn't defined between %q and %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(sdkField.ObjectDefinition.NestedItem.Type))
	}
	if v != sdkField.ObjectDefinition.NestedItem.Type {
		return nil, fmt.Errorf("expected a DirectAssignment between %q and %q but got %q", string(schemaField.ObjectDefinition.NestedObject.Type), string(v), string(sdkField.ObjectDefinition.NestedItem.Type))
	}

	variableType, err := generatorHelpers.GolangFieldTypeFromObjectFieldDefinition(schemaField.ObjectDefinition)
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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *variableType)
		if sdkField.Optional {
			line = fmt.Sprintf(`
%[3]s := make(%[4]s, 0)
for _, v := range input.%[1]s {
    %[3]s = append(%[3]s, v)
}
output.%[2]s = &%[3]s
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *variableType)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, *variableType)
	return &line, nil
}

func (d directAssignmentLine) sdkToSchemaMappingBetweenListOfReferenceFields(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, apiResourcePackageName string) (*string, error) {
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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, sdkFieldTypeName, schemaFieldTypeName)

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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, sdkFieldTypeName, schemaFieldTypeName)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
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
`, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaFieldName, sdkField.JsonName, sdkFieldTypeName, schemaFieldTypeName)
	return &line, nil
}

func (d directAssignmentLine) sdkToSchemaMappingRequiringTransform(mapping models.TerraformDirectAssignmentFieldMappingDefinition, schemaField models.TerraformSchemaField, sdkField models.SDKField, _ *assignmentConstantDetails, _ string, transform directAssignmentTransform) (*string, error) {
	outputAssignment := fmt.Sprintf("output.%s", mapping.DirectAssignment.TerraformSchemaFieldName)
	outputVariable := sdkField.JsonName
	inputAssignment := fmt.Sprintf("input.%s", mapping.DirectAssignment.SDKFieldName)

	if schemaField.Required {
		transformFunc := transform.requiredFlattenFuncBody()
		if sdkField.Optional {
			transformFunc = transform.optionalFlattenFuncBody()
		}
		transformLine := transformFunc(outputAssignment, outputVariable, inputAssignment)
		return &transformLine, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.DirectAssignment.SDKModelName, mapping.DirectAssignment.SDKFieldName, mapping.DirectAssignment.TerraformSchemaModelName, mapping.DirectAssignment.TerraformSchemaFieldName)
	}

	// optional -> optional
	transformLineFunc := transform.optionalFlattenFuncBody()
	transformLine := transformLineFunc(outputAssignment, outputVariable, inputAssignment)
	return &transformLine, nil
}
