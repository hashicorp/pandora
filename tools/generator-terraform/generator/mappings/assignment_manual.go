package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ assignmentType = manualAssignmentLine{}

type manualAssignmentLine struct{}

// TODO: support for when Mapping is Computed

func (m manualAssignmentLine) assignmentForCreateUpdateMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if mapping.Manual == nil {
		return nil, fmt.Errorf("manual mapping had no manual definition")
	}

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

	if schemaField.Required {
		line := fmt.Sprintf(`
%[1]s, err := %[4]s(input.%[2]s)
if err != nil {
		return fmt.Errorf("flattening %[2]q: %%+v", err)
}
out.%[3]s = %[1]s
`, sdkField.JsonName, mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath, mapping.Manual.MethodName)
		if sdkField.Optional {
			line = fmt.Sprintf(`
%[1]s, err := %[4]s(input.%[2]s)
if err != nil {
	return fmt.Errorf("flattening %[2]q: %%+v", err)
}
out.%[3]s = &%[1]s
`, sdkField.JsonName, mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath, mapping.Manual.MethodName)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
	}

	// Optional -> Optional
	line := fmt.Sprintf(`
if input.%[2]s != nil {
	%[1]s, err := %[4]s(*input.%[2]s)
	if err != nil {
		return fmt.Errorf("flattening %[2]q: %%+v", err)
	}
	out.%[3]s = &%[1]s
}
`, sdkField.JsonName, mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath, mapping.Manual.MethodName)
	return &line, nil
}

func (m manualAssignmentLine) assignmentForReadMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails) (*string, error) {
	if mapping.Manual == nil {
		return nil, fmt.Errorf("manual mapping had no manual definition")
	}

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

	if schemaField.Required {
		line := fmt.Sprintf(`
%[1]s, err := %[4]s(input.%[3]s)
if err != nil {
		return fmt.Errorf("flattening %[3]q: %%+v", err)
}
out.%[2]s = %[1]s
`, sdkField.JsonName, mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath, mapping.Manual.MethodName)
		if sdkField.Optional {
			line = fmt.Sprintf(`
if input.%[3]s != nil {
	%[1]s, err := %[4]s(*input.%[3]s)
	if err != nil {
		return fmt.Errorf("flattening %[3]q: %%+v", err)
	}
	out.%[2]s = %[1]s
}
`, sdkField.JsonName, mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath, mapping.Manual.MethodName)
		}
		return &line, nil
	}

	if sdkField.Required {
		// if the SDK Field is Required but the Schema Field is Optional this is a Data Issue
		// TODO: handle where it's defaulted?
		return nil, fmt.Errorf("the Sdk Model %q Field %q was Required but Schema Model %q Field %q was Optional but must be Required", mapping.To.SdkModelName, mapping.To.SdkFieldPath, mapping.From.SchemaModelName, mapping.From.SchemaFieldPath)
	}

	// Optional -> Optional
	line := fmt.Sprintf(`
if input.%[3]s != nil {
	%[1]s, err := %[4]s(*input.%[3]s)
	if err != nil {
		return fmt.Errorf("flattening %[3]q: %%+v", err)
	}
	out.%[2]s = &%[1]s
}
`, sdkField.JsonName, mapping.From.SchemaFieldPath, mapping.To.SdkFieldPath, mapping.Manual.MethodName)
	return &line, nil
}
