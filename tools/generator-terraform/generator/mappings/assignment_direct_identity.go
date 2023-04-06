package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// handle all kind of identity block transform: expand and flatten

type transformer struct {
	expandFn    string
	flattenFn   string
	packageName string
}

type sdkFieldType = resourcemanager.ApiObjectDefinitionType

// transform from sdk identity block to schema identity block, or reverse
// N sdk model : 1 schema model, say there are 7 sdk identity types, but only 4 schema identity types
var identityTransformers = map[sdkFieldType]transformer{
	resourcemanager.LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType: {
		expandFn:    "ExpandLegacySystemAndUserAssignedMapFromModel",
		flattenFn:   "FlattenLegacySystemAndUserAssignedMapToModel",
		packageName: "identity",
	},
}

// we can get schema type from mapping, so only the sdk type is needed
// isExpand: true for expandFromModel, false for flattenToModel
func patchIdentityTransform(sdkType sdkFieldType, isExpand bool, mapping resourcemanager.FieldMappingDefinition, sdkFieldName string) (code string, ok bool) {
	transform, exists := identityTransformers[sdkType]
	if !exists {
		return "", false
	}
	// default as flatten: input sdk => output schema
	inputAssignment := fmt.Sprintf("input.%s", mapping.DirectAssignment.SdkFieldPath)
	outputAssignment := fmt.Sprintf("output.%s", mapping.DirectAssignment.SchemaFieldPath)
	outputVariable := sdkFieldName

	fn := transform.flattenFn
	hint := "flattening"
	if isExpand {
		fn = transform.expandFn
		hint = "expanding"
		inputAssignment = fmt.Sprintf("input.%s", mapping.DirectAssignment.SchemaFieldPath)
		outputAssignment = fmt.Sprintf("output.%s", mapping.DirectAssignment.SdkFieldPath)
	}
	code = fmt.Sprintf(`
	%[1]s, err := %[6]s.%[4]s(%[2]s)
	if err != nil {
		return fmt.Errorf("%[5]s call %[4]s: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariable, inputAssignment, outputAssignment, fn, hint, transform.packageName)

	return code, true
}
