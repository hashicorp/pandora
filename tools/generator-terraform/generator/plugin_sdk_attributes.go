package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type pluginSdkAttributesHelpers struct {
	schemaModels map[string]resourcemanager.TerraformSchemaModelDefinition
}

func (h pluginSdkAttributesHelpers) codeForModel(input resourcemanager.TerraformSchemaModelDefinition, isTopLevel bool) (*string, error) {
	lines := make([]string, 0)

	// fields should be sorted Required -> Optional -> Computed, and alphabetically within each category
	requiredFields := make([]string, 0)
	optionalFields := make([]string, 0)
	computedFields := make([]string, 0)
	for fieldName, details := range input.Fields {
		if details.Required {
			requiredFields = append(requiredFields, fieldName)
			continue
		}

		if details.Optional {
			optionalFields = append(optionalFields, fieldName)
			continue
		}

		if details.Computed {
			computedFields = append(computedFields, fieldName)
			continue
		}

		return nil, fmt.Errorf("field %q is neither required/optional/computed", fieldName)
	}
	sort.Strings(requiredFields)
	sort.Strings(optionalFields)
	sort.Strings(computedFields)

	// now that each of the fields has been sorted, build a canonical list so we don't C&P the next bit..
	sortedNames := make([]string, 0)
	sortedNames = append(sortedNames, requiredFields...)
	sortedNames = append(sortedNames, optionalFields...)

	if !isTopLevel {
		// if it's a top level schema model - don't output these fields since these should be output
		// in the Attributes method rather than the Arguments method
		sortedNames = append(sortedNames, computedFields...)
	}

	if len(sortedNames) == 0 {
		// TODO: this can be removed once the Data API is hooked up to real data
		out := "map[string]*pluginsdk.Schema{}"
		return &out, nil
	}

	for _, fieldName := range sortedNames {
		field := input.Fields[fieldName]
		line, err := h.codeForPluginSdkAttribute(fieldName, field)
		if err != nil {
			return nil, fmt.Errorf("building argument code for field %q: %+v", fieldName, err)
		}

		lines = append(lines, *line)
	}

	output := strings.TrimSpace(fmt.Sprintf(`
map[string]*pluginsdk.Schema{
	%[1]s,
}
`, strings.Join(lines, ",\n")))
	return &output, nil
}

func (h pluginSdkAttributesHelpers) codeForPluginSdkAttribute(fieldName string, field resourcemanager.TerraformSchemaFieldDefinition) (*string, error) {
	code, err := codeForPluginSdkCommonSchemaAttribute(field)
	if err != nil {
		return nil, fmt.Errorf("building common schema attribute code for field %q: %+v", fieldName, err)
	}
	if code != nil {
		out := fmt.Sprintf(`%[1]q: %[2]s`, fieldName, *code)
		return &out, nil
	}

	attributes := make([]string, 0)

	if field.Required {
		attributes = append(attributes, fmt.Sprintf("Required: %t", field.Required))
	}
	if field.Optional {
		attributes = append(attributes, fmt.Sprintf("Optional: %t", field.Optional))
	}
	if field.ForceNew {
		attributes = append(attributes, fmt.Sprintf("ForceNew: %t", field.ForceNew))
	}
	if field.Computed {
		attributes = append(attributes, fmt.Sprintf("Computed: %t", field.Computed))
	}

	switch field.ObjectDefinition.Type {
	case resourcemanager.TerraformSchemaFieldTypeBoolean:
		{
			attributes = append(attributes, "Type: pluginsdk.TypeBool")
		}
	// TODO: float
	case resourcemanager.TerraformSchemaFieldTypeInteger:
		{
			attributes = append(attributes, "Type: pluginsdk.TypeInt")
		}
	case resourcemanager.TerraformSchemaFieldTypeString:
		{
			attributes = append(attributes, "Type: pluginsdk.TypeString")
		}

	case resourcemanager.TerraformSchemaFieldTypeReference:
		{
			if field.ObjectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("missing name for reference")
			}
			reference, ok := h.schemaModels[*field.ObjectDefinition.ReferenceName]
			if !ok {
				return nil, fmt.Errorf("schema model %q was not found", *field.ObjectDefinition.ReferenceName)
			}

			codeForModel, err := h.codeForModel(reference, false)
			if err != nil {
				return nil, fmt.Errorf("building code for nested model %q for field %q: %+v", *field.ObjectDefinition.ReferenceName, fieldName, err)
			}

			// references are output as a List with `MaxItems: 1` for now
			attributes = append(attributes, "Type: pluginsdk.TypeList")
			attributes = append(attributes, "MaxItems: 1")
			attributes = append(attributes, strings.TrimSpace(fmt.Sprintf(`
Elem: &pluginsdk.Resource{
	Schema: %[1]s,
}
`, *codeForModel)))
		}

	default:
		{
			return nil, fmt.Errorf("internal-error: unimplemented schema field definition type %q", string(field.ObjectDefinition.Type))
		}
	}

	sort.Strings(attributes)
	output := strings.TrimSpace(fmt.Sprintf(`
%[1]q: {
	%[2]s,
}
`, fieldName, strings.Join(attributes, ",\n")))

	return &output, nil
}

func codeForPluginSdkCommonSchemaAttribute(field resourcemanager.TerraformSchemaFieldDefinition) (*string, error) {
	commonSchemaTypes := map[resourcemanager.TerraformSchemaFieldType]struct{}{
		resourcemanager.TerraformSchemaFieldTypeEdgeZone: {},
		resourcemanager.TerraformSchemaFieldTypeLocation: {},
		resourcemanager.TerraformSchemaFieldTypeTags:     {},
	}
	if _, ok := commonSchemaTypes[field.ObjectDefinition.Type]; !ok {
		return nil, nil
	}

	out := ""
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeEdgeZone {
		if field.Required {
			return nil, fmt.Errorf("not supported: edge zone cannot be required")
		}
		if field.Optional {
			out = "commonschema.EdgeZoneOptional()"
			if field.ForceNew {
				out = "commonschema.EdgeZoneOptionalForceNew()"
			}
		}
		if field.Computed {
			if field.Optional {
				return nil, fmt.Errorf("not supported: edge zone cannot be optional & computed")
			}
			if field.ForceNew {
				return nil, fmt.Errorf("not supported: edge zone cannot be ForceNew & computed")
			}
			out = "commonschema.EdgeZoneComputed()"
		}
	}
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeLocation {
		if field.Required {
			out = "commonschema.Location()"
			if !field.ForceNew {
				out = "commonschema.LocationWithoutForceNew()"
			}
		}
		if field.Optional {
			if !field.ForceNew {
				return nil, fmt.Errorf("unimplemented: Optional Location w/o ForceNew")
			}
			out = "commonschema.LocationOptional()"
		}
		if field.Computed {
			if field.Required {
				return nil, fmt.Errorf("not supported: Required/Computed Location - this should be Required not Computed")
			}
			if field.Optional {
				return nil, fmt.Errorf("not supported: Optional/Computed Location - this should be Optional not Computed")
			}
			if field.ForceNew {
				return nil, fmt.Errorf("not supported: ForceNew/Computed Location - this should be Computed and not ForceNew")
			}
			out = "commonschema.LocationComputed()"
		}
	}
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeTags {
		if field.Required {
			return nil, fmt.Errorf("unimplemented: Required Tags")
		}
		if field.Optional {
			if field.Computed {
				return nil, fmt.Errorf("internal-error: tags shouldn't be Optional/Computed")
			}

			out = "commonschema.Tags()"
			if field.ForceNew {
				out = "commonschema.TagsForceNew()"
			}
		}
		if field.Computed {
			out = "commonschema.TagsDataSource()"
		}
	}

	if out == "" {
		return nil, fmt.Errorf("internal-error: common schema not implemented")
	}
	return &out, nil
}
