package generator

import (
	"fmt"
	"sort"
	"strings"
)

func schemaForFields(input map[string]FieldDefinition, objects *Objects, isDataSource bool) (*string, error) {
	sortedFields := sortSchemaFields(input)

	fields := make([]string, 0)
	for _, val := range sortedFields {
		if val.Type == FieldTypeDefinitionLocation {
			fields = append(fields, schemaForLocationField(val, isDataSource))
			continue
		}
		if val.Type == FieldTypeDefinitionJson {
			fields = append(fields, schemaForJsonField(val))
			continue
		}
		if val.Type == FieldTypeDefinitionResourceGroup {
			fields = append(fields, schemaForResourceGroupField(val, isDataSource))
			continue
		}
		if val.Type == FieldTypeDefinitionTags {
			fields = append(fields, schemaForTagsField(val, isDataSource))
			continue
		}

		lines := make([]string, 0)
		schemaType := terraformSchemaName(val.Type)
		lines = append(lines, fmt.Sprintf("Type: pluginsdk.%s", schemaType))

		if val.Required {
			lines = append(lines, "Required: true")
		}
		if val.Optional {
			lines = append(lines, "Optional: true")
		}
		if val.Computed {
			lines = append(lines, "Computed: true")
		}
		if val.ForceNew {
			lines = append(lines, "ForceNew: true")
		}
		if val.Sensitive {
			lines = append(lines, "Sensitive: true")
		}
		if val.Default != nil {
			v := *val.Default
			if str, ok := v.(string); ok {
				lines = append(lines, fmt.Sprintf("Default: %q", str))
			} else {
				lines = append(lines, fmt.Sprintf("Default: %+v", v))
			}
		}

		if val.MinItems != nil {
			lines = append(lines, fmt.Sprintf("MinItems: %d", *val.MinItems))
		}
		if val.MaxItems != nil {
			lines = append(lines, fmt.Sprintf("MaxItems: %d", *val.MaxItems))
		}

		if val.ConstantReference != nil {
			if objects == nil {
				return nil, fmt.Errorf("no objects were defined")
			}
			constant, ok := objects.Constants[*val.ConstantReference]
			if !ok {
				return nil, fmt.Errorf("a constant was not found with the name %q", *val.ConstantReference)
			}
			vals := make([]string, 0)
			for k := range constant.Values {
				vals = append(vals, fmt.Sprintf("string(gosdk.%[1]s)", k))
			}

			// TODO: we can do validation for it
			lines = append(lines, fmt.Sprintf(`
				ValidateFunc: validation.StringInSlice([]string{
%[1]s
				}, false)
`, strings.Join(vals, ",\n")))
		}
		if val.ModelReference != nil {
			if objects == nil {
				return nil, fmt.Errorf("no objects were defined")
			}
			model, ok := objects.Models[*val.ModelReference]
			if !ok {
				return nil, fmt.Errorf("a model was not found with the name %q", *val.ModelReference)
			}
			nestedLines, err := schemaForFields(model.Fields, objects, isDataSource)
			if err != nil {
				return nil, fmt.Errorf("building nested schema for %q: %+v", *val.ModelReference, err)
			}

			lines = append(lines, fmt.Sprintf(`Elem: &pluginsdk.Resource{
					Schema: %[1]s,
}`, *nestedLines))
		}
		if val.Type == FieldTypeDefinitionMap {
			lines = append(lines, fmt.Sprintf(`Elem: &pluginsdk.Schema{
					Type: pluginsdk.TypeString,
				}`))
		}

		fields = append(fields, fmt.Sprintf(`%[1]q: {
%[2]s,
}`, val.HclLabel, strings.Join(lines, ",\n")))
	}

	content := fmt.Sprintf(`map[string]*pluginsdk.Schema{
%[1]s,
}`, strings.Join(fields, ",\n"))
	if len(fields) == 0 {
		content = "map[string]*pluginsdk.Schema{}"
	}
	return &content, nil
}

func schemaForLocationField(input FieldDefinition, isDataSource bool) string {
	// TODO: move these into a common package
	if isDataSource || input.Computed {
		return schemaForField(input, "location.SchemaComputed()")
	}

	if input.Optional {
		return schemaForField(input, "location.SchemaOptional()")
	}

	if !input.ForceNew {
		return schemaForField(input, "location.SchemaWithoutForceNew()")
	}

	return schemaForField(input, "location.Schema()")
}

func schemaForJsonField(input FieldDefinition) string {
	// TODO: we should add definitions for these
	lines := []string{
		"Type: pluginsdk.TypeString",
		"StateFunc: utils.NormalizeJson",
	}
	if input.Computed {
		lines = append(lines, "Computed: true")
	}
	if input.Deprecated {
		lines = append(lines, "Deprecated: true")
	}
	if input.ForceNew {
		lines = append(lines, "ForceNew: true")
	}
	if input.Optional {
		lines = append(lines, "Optional: true")
	}
	if input.Required {
		lines = append(lines, "Required: true")
	}

	out := fmt.Sprintf("{%s}", strings.Join(lines, ",\n"))
	return schemaForField(input, out)
}

func schemaForResourceGroupField(input FieldDefinition, isDataSource bool) string {
	// TODO: these definitions should be moved elsewhere
	if isDataSource {
		return schemaForField(input, "azure.SchemaResourceGroupNameForDataSource()")
	}

	if input.Deprecated {
		if input.Computed {
			return schemaForField(input, "azure.SchemaResourceGroupNameDeprecatedComputed()")
		}
		return schemaForField(input, "azure.SchemaResourceGroupNameDeprecated()")
	}

	if input.Optional {
		if input.Computed {
			return schemaForField(input, "azure.SchemaResourceGroupNameOptionalComputed()")
		}

		return schemaForField(input, "azure.SchemaResourceGroupNameOptional()")
	}

	return schemaForField(input, "azure.SchemaResourceGroupName()")
}

func schemaForTagsField(input FieldDefinition, isDataSource bool) string {
	// TODO: move these to a common location
	if isDataSource || (input.Computed && (!input.Optional || !input.Computed)) {
		return schemaForField(input, "tags.SchemaDataSource()")
	}

	if input.ForceNew {
		return schemaForField(input, "tags.ForceNewSchema()")
	}

	return schemaForField(input, "tags.Schema()")
}

func schemaForField(input FieldDefinition, body string) string {
	return fmt.Sprintf("%q: %s", input.HclLabel, body)
}

func terraformSchemaName(input FieldTypeDefinition) string {
	// TODO: implement me
	return "string"
}

func sortSchemaFields(input map[string]FieldDefinition) []FieldDefinition {
	fieldsByHclName := make(map[string]FieldDefinition, len(input))
	for _, v := range input {
		fieldsByHclName[v.HclLabel] = v
	}

	requiredFieldNames := make([]string, 0)
	optionalFieldNames := make([]string, 0)
	computedFieldNames := make([]string, 0)
	for name, value := range fieldsByHclName {
		if value.Required {
			requiredFieldNames = append(requiredFieldNames, name)
			continue
		}

		if value.Optional {
			optionalFieldNames = append(optionalFieldNames, name)
			continue
		}

		computedFieldNames = append(computedFieldNames, name)
	}
	sort.Strings(requiredFieldNames)
	sort.Strings(optionalFieldNames)
	sort.Strings(computedFieldNames)

	output := make([]FieldDefinition, 0)
	for _, name := range requiredFieldNames {
		field := fieldsByHclName[name]
		output = append(output, field)
	}
	for _, name := range optionalFieldNames {
		field := fieldsByHclName[name]
		output = append(output, field)
	}
	for _, name := range computedFieldNames {
		field := fieldsByHclName[name]
		output = append(output, field)
	}

	return output
}
