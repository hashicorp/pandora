package pluginsdkattributes

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type PluginSdkAttributesHelpers struct {
	SchemaModels map[string]resourcemanager.TerraformSchemaModelDefinition
}

func (h PluginSdkAttributesHelpers) CodeForModel(input resourcemanager.TerraformSchemaModelDefinition, isTopLevel bool) (*string, error) {
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
		line, err := h.codeForPluginSdkAttribute(field)
		if err != nil {
			return nil, fmt.Errorf("building argument code for field %q: %+v", fieldName, err)
		}

		lines = append(lines, fmt.Sprintf(`%[1]q: %[2]s`, field.HclName, *line))
	}

	output := strings.TrimSpace(fmt.Sprintf(`
map[string]*pluginsdk.Schema{
	%[1]s,
}
`, strings.Join(lines, ",\n")))
	return &output, nil
}

func (h PluginSdkAttributesHelpers) CodeForModelAttributesOnly(input resourcemanager.TerraformSchemaModelDefinition) (*string, error) {
	lines := make([]string, 0)

	// pull out a list of Computed-only fields and then sort those alphabetically
	// this function is only used for top-level types, nested items output the full model
	computedFields := make([]string, 0)
	for fieldName, details := range input.Fields {
		// we only want top-level fields which are Computed
		if details.Computed && !details.Optional && !details.Required && !details.ForceNew {
			computedFields = append(computedFields, fieldName)
			continue
		}
	}
	sort.Strings(computedFields)

	if len(computedFields) == 0 {
		out := "map[string]*pluginsdk.Schema{}"
		return &out, nil
	}

	for _, fieldName := range computedFields {
		field := input.Fields[fieldName]
		line, err := h.codeForPluginSdkAttribute(field)
		if err != nil {
			return nil, fmt.Errorf("building argument code for field %q: %+v", fieldName, err)
		}

		lines = append(lines, fmt.Sprintf(`%[1]q: %[2]s`, field.HclName, *line))
	}

	output := strings.TrimSpace(fmt.Sprintf(`
map[string]*pluginsdk.Schema{
	%[1]s,
}
`, strings.Join(lines, ",\n")))
	return &output, nil
}

func (h PluginSdkAttributesHelpers) codeForPluginSdkAttribute(field resourcemanager.TerraformSchemaFieldDefinition) (*string, error) {
	code, err := codeForPluginSdkCommonSchemaAttribute(field)
	if err != nil {
		return nil, fmt.Errorf("building common schema attribute code: %+v", err)
	}
	if code != nil {
		return code, nil
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

	codeForObjectDefinition, err := h.attributesForObjectDefinition(field.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("building attributes for object definition: %+v", err)
	}
	attributes = append(attributes, *codeForObjectDefinition...)

	sort.Strings(attributes)
	output := strings.TrimSpace(fmt.Sprintf(`
{
	%[1]s,
}
`, strings.Join(attributes, ",\n")))

	return &output, nil
}

func (h PluginSdkAttributesHelpers) attributesForObjectDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition) (*[]string, error) {
	attributes := make([]string, 0)
	switch input.Type {
	case resourcemanager.TerraformSchemaFieldTypeBoolean:
		{
			attributes = append(attributes, "Type: pluginsdk.TypeBool")
		}
	case resourcemanager.TerraformSchemaFieldTypeDateTime:
		{
			// TODO: should/can we also output validation for this?
			attributes = append(attributes, "Type: pluginsdk.TypeString")
		}
	case resourcemanager.TerraformSchemaFieldTypeFloat:
		{
			attributes = append(attributes, "Type: pluginsdk.TypeFloat")
		}
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
			if input.ReferenceName == nil {
				return nil, fmt.Errorf("missing name for reference")
			}
			reference, ok := h.SchemaModels[*input.ReferenceName]
			if !ok {
				return nil, fmt.Errorf("schema model %q was not found", *input.ReferenceName)
			}

			codeForModel, err := h.CodeForModel(reference, false)
			if err != nil {
				return nil, fmt.Errorf("building code for nested model %q: %+v", *input.ReferenceName, err)
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

	case resourcemanager.TerraformSchemaFieldTypeList, resourcemanager.TerraformSchemaFieldTypeSet:
		{
			if input.NestedObject == nil {
				return nil, fmt.Errorf("internal-error: list/set type with no nested object")
			}

			if input.Type == resourcemanager.TerraformSchemaFieldTypeList {
				attributes = append(attributes, "Type: pluginsdk.TypeList")
			} else {
				attributes = append(attributes, "Type: pluginsdk.TypeSet")
			}
			if input.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeReference {
				if input.NestedObject.ReferenceName == nil {
					return nil, fmt.Errorf("missing name for reference")
				}
				reference, ok := h.SchemaModels[*input.NestedObject.ReferenceName]
				if !ok {
					return nil, fmt.Errorf("schema model %q was not found", *input.ReferenceName)
				}

				codeForModel, err := h.CodeForModel(reference, false)
				if err != nil {
					return nil, fmt.Errorf("building code for nested model %q: %+v", *input.NestedObject.ReferenceName, err)
				}

				attributes = append(attributes, strings.TrimSpace(fmt.Sprintf(`
Elem: &pluginsdk.Resource{
	Schema: %[1]s,
}
`, *codeForModel)))
			} else {
				nestedAttributes, err := h.attributesForObjectDefinition(*input.NestedObject)
				if err != nil {
					return nil, fmt.Errorf("building attributes for nested object definition: %+v", err)
				}
				attributes = append(attributes, strings.TrimSpace(fmt.Sprintf(`
Elem: &pluginsdk.Schema{
	%[1]s,
}
`, strings.Join(*nestedAttributes, ",\n"))))
			}
		}

	default:
		{
			return nil, fmt.Errorf("internal-error: unimplemented schema field definition type %q", string(input.Type))
		}
	}

	return &attributes, nil
}

func codeForPluginSdkCommonSchemaAttribute(field resourcemanager.TerraformSchemaFieldDefinition) (*string, error) {
	commonSchemaTypes := map[resourcemanager.TerraformSchemaFieldType]struct{}{
		resourcemanager.TerraformSchemaFieldTypeEdgeZone:                      {},
		resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        {},
		resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: {},
		resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  {},
		resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          {},
		resourcemanager.TerraformSchemaFieldTypeLocation:                      {},
		resourcemanager.TerraformSchemaFieldTypeResourceGroup:                 {},
		resourcemanager.TerraformSchemaFieldTypeTags:                          {},
		resourcemanager.TerraformSchemaFieldTypeZone:                          {},
		resourcemanager.TerraformSchemaFieldTypeZones:                         {},
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
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned {
		if field.Required {
			out = "commonschema.SystemAssignedIdentityRequired()"
			if field.ForceNew {
				out = "commonschema.SystemAssignedIdentityRequiredForceNew()"
			}
		}
		if field.Optional {
			out = "commonschema.SystemAssignedIdentityOptional()"
			if field.ForceNew {
				out = "commonschema.SystemAssignedIdentityOptionalForceNew()"
			}
			if field.Computed {
				return nil, fmt.Errorf("not-supported: Optional/Computed System Assigned Identities are not supported, should be Optional only")
			}
		}
		if field.Computed {
			out = "commonschema.SystemAssignedIdentityComputed()"
		}
	}
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned {
		if field.Required {
			out = "commonschema.SystemAssignedUserAssignedIdentityRequired()"
			if field.ForceNew {
				out = "commonschema.SystemAssignedUserAssignedIdentityRequiredForceNew()"
			}
		}
		if field.Optional {
			out = "commonschema.SystemAssignedUserAssignedIdentityOptional()"
			if field.ForceNew {
				out = "commonschema.SystemAssignedUserAssignedIdentityOptionalForceNew()"
			}
			if field.Computed {
				return nil, fmt.Errorf("not-supported: Optional/Computed System Assigned and User Assigned Identities are not supported, should be Optional only")
			}
		}
		if field.Computed {
			out = "commonschema.SystemAssignedUserAssignedIdentityComputed()"
		}
	}
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned {
		if field.Required {
			out = "commonschema.SystemOrUserAssignedIdentityRequired()"
			if field.ForceNew {
				out = "commonschema.SystemOrUserAssignedIdentityRequiredForceNew()"
			}
		}
		if field.Optional {
			out = "commonschema.SystemOrUserAssignedIdentityOptional()"
			if field.ForceNew {
				out = "commonschema.SystemOrUserAssignedIdentityOptionalForceNew()"
			}
			if field.Computed {
				return nil, fmt.Errorf("not-supported: Optional/Computed System Assigned or User Assigned Identities are not supported, should be Optional only")
			}
		}
		if field.Computed {
			out = "commonschema.SystemOrUserAssignedIdentityComputed()"
		}
	}
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned {
		if field.Required {
			out = "commonschema.UserAssignedIdentityRequired()"
			if field.ForceNew {
				out = "commonschema.UserAssignedIdentityRequiredForceNew()"
			}
		}
		if field.Optional {
			out = "commonschema.UserAssignedIdentityOptional()"
			if field.ForceNew {
				out = "commonschema.UserAssignedIdentityOptionalForceNew()"
			}
			if field.Computed {
				return nil, fmt.Errorf("not-supported: Optional/Computed User Assigned Identities are not supported, should be Optional only")
			}
		}
		if field.Computed {
			out = "commonschema.UserAssignedIdentityComputed()"
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
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeResourceGroup {
		if field.Required {
			out = "commonschema.ResourceGroupNameForDataSource()"
			if field.ForceNew {
				out = "commonschema.ResourceGroupName()"
			}
		}
		if field.Optional {
			out = "commonschema.ResourceGroupNameOptional()"
			if field.ForceNew {
				if !field.Computed {
					// TODO: this needs implementing in go-azure-helpers
					return nil, fmt.Errorf("not-implemented: Optional & ForceNew & !Computed for Resource Group")
				}

				out = "commonschema.ResourceGroupNameOptionalComputed()"
			}
		}
		if field.Computed && !field.Optional && !field.ForceNew {
			return nil, fmt.Errorf("not-supported: Computed & !Optional & !ForceNew is not supported for Resource Group")
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
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeZone {
		if field.Required {
			out = "commonschema.ZoneSingleRequired()"
			if field.ForceNew {
				out = "commonschema.ZoneSingleRequiredForceNew()"
			}
		}
		if field.Optional {
			if field.Computed {
				return nil, fmt.Errorf("internal-error: Single Zone shouldn't be Optional/Computed")
			}

			out = "commonschema.ZoneSingleOptional()"
			if field.ForceNew {
				out = "commonschema.ZoneSingleOptionalForceNew()"
			}
		}
		if field.Computed {
			if field.Optional || field.ForceNew {
				return nil, fmt.Errorf("internal-error: Single Zone shouldn't be Computed and Optional or ForceNew")
			}

			out = "commonschema.ZoneSingleComputed()"
		}
	}
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeZones {
		if field.Required {
			out = "commonschema.ZonesMultipleRequired()"
			if field.ForceNew {
				out = "commonschema.ZonesMultipleRequiredForceNew()"
			}
		}
		if field.Optional {
			if field.Computed {
				return nil, fmt.Errorf("internal-error: Multiple Zones shouldn't be Optional/Computed")
			}

			out = "commonschema.ZonesMultipleOptional()"
			if field.ForceNew {
				out = "commonschema.ZonesMultipleOptionalForceNew()"
			}
		}
		if field.Computed {
			if field.Optional || field.ForceNew {
				return nil, fmt.Errorf("internal-error: Multiple Zones shouldn't be Computed and Optional or ForceNew")
			}

			out = "commonschema.ZonesMultipleComputed()"
		}
	}

	if out == "" {
		return nil, fmt.Errorf("internal-error: common schema not implemented")
	}
	return &out, nil
}
