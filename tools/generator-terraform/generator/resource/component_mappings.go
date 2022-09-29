package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForMappings(input models.ResourceInput) (*string, error) {
	lines := make([]string, 0)

	// TODO: we need Model to Model mappings threaded through, but for now let's go through and fake that
	lines = append(lines, modelToModelMappings(input)...)

	output := strings.Join(lines, "\n")
	return &output, nil
}

func modelToModelMappings(input models.ResourceInput) []string {
	lines := make([]string, 0)

	// give us a unique list of model names
	placeholder := make(map[string][]resourcemanager.FieldMappingDefinition)
	for _, v := range input.Details.Mappings.Fields {
		key := fmt.Sprintf("%s-%s", v.DirectAssignment.SchemaModelName, v.DirectAssignment.SdkModelName)
		mappings, ok := placeholder[key]
		if !ok {
			mappings = make([]resourcemanager.FieldMappingDefinition, 0)
		}
		mappings = append(mappings, v)
		placeholder[key] = mappings
	}

	// then based on that go ahead and find pull out information about both
	for key, mappings := range placeholder {
		split := strings.Split(key, "-")
		schemaModelName := split[0]
		sdkModelName := split[1]

		// TODO: handle the Create/Read/Update being different
		//if schemaModelName == input.SchemaModelName {
		//	continue
		//}

		// TODO: switch this out to something that differs by type
		mappingLinesToSdk := make([]string, 0)
		mappingLinesToSchema := make([]string, 0)
		for _, item := range mappings {
			mappingLinesToSdk = append(mappingLinesToSdk, fmt.Sprintf(`// TODO: Map Schema Field %q to SDK Field %q`, item.DirectAssignment.SchemaFieldPath, item.DirectAssignment.SdkFieldPath))
			mappingLinesToSchema = append(mappingLinesToSchema, fmt.Sprintf(`// TODO: Map SDK Field %q to Schema Field %q`, item.DirectAssignment.SdkFieldPath, item.DirectAssignment.SchemaFieldPath))
		}

		// Schema -> SDK
		lines = append(lines, fmt.Sprintf(`
func (r %[1]sResource) map%[2]sTo%[3]s(input %[2]s, output *%[4]s.%[3]s) error {
	// TODO: implement this
	%[5]s
	return nil
}
`, input.Details.ResourceName, schemaModelName, sdkModelName, strings.ToLower(input.SdkResourceName), strings.Join(mappingLinesToSdk, "\n")))

		// SDK -> Schema
		lines = append(lines, fmt.Sprintf(`
func (r %[1]sResource) map%[2]sTo%[3]s(input %[4]s.%[2]s, output *%[3]s) error {
	// TODO: implement this
	%[5]s
	return nil
}
`, input.Details.ResourceName, sdkModelName, schemaModelName, strings.ToLower(input.SdkResourceName), strings.Join(mappingLinesToSdk, "\n")))
	}

	return lines
}
