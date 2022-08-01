package docs

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForImport(input models.ResourceInput) (*string, error) {
	resourceId, ok := input.ResourceIds[input.Details.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("resource ID %q is used but was not defined", input.Details.ResourceIdName)
	}

	resourceIdDescriptionLines := make([]string, 0)
	for _, value := range resourceId.Segments {
		if value.Type == resourcemanager.ResourceProviderSegment || value.Type == resourcemanager.StaticSegment {
			continue
		}

		description, err := descriptionsForSegment(value, resourceId, input.Details, input.Constants)
		if err != nil {
			return nil, fmt.Errorf("building description for segment %q: %+v", value.Name, err)
		}
		line := fmt.Sprintf(`
* Where '{%[1]s}' %[2]s
`, value.Name, *description)
		resourceIdDescriptionLines = append(resourceIdDescriptionLines, strings.TrimSpace(strings.ReplaceAll(line, "'", "`")))
	}

	importsCode := fmt.Sprintf(`
## Import

An existing %[1]s can be imported into Terraform using the 'resource id', e.g.

'''shell
terraform import %[2]s_%[3]s.example %[4]s
'''

%[5]s
`, input.Details.DisplayName, input.ProviderPrefix, input.ResourceLabel, resourceId.Id, strings.Join(resourceIdDescriptionLines, "\n"))
	output := strings.TrimSpace(strings.ReplaceAll(importsCode, "'", "`"))
	return &output, nil
}

func descriptionsForSegment(segment resourcemanager.ResourceIdSegment, resourceId resourcemanager.ResourceIdDefinition, details resourcemanager.TerraformResourceDetails, constants map[string]resourcemanager.ConstantDetails) (*string, error) {
	if segment.Type == resourcemanager.ResourceGroupSegment {
		if isCommonResourceIdNamed("ResourceGroup", resourceId) {
			out := fmt.Sprintf("is the name of this %[1]s. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
			return &out, nil
		}

		out := fmt.Sprintf("is the name of Resource Group where this %[1]s exists. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
		return &out, nil
	}
	if segment.Type == resourcemanager.SubscriptionIdSegment {
		if isCommonResourceIdNamed("Subscription", resourceId) {
			out := fmt.Sprintf("is the ID of this %[1]s. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
			return &out, nil
		}

		out := fmt.Sprintf("is the ID of the Azure Subscription where the %[1]s exists. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
		return &out, nil
	}
	if segment.Type == resourcemanager.ScopeSegment {
		if isCommonResourceIdNamed("Scope", resourceId) {
			out := fmt.Sprintf("is the Azure Resource Scope under which this %[1]s exists. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
			return &out, nil
		}

		out := fmt.Sprintf("is the ID of the Azure Resource under which the %[1]s exists. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
		return &out, nil
	}

	description := fmt.Sprintf("is the name of the %s", wordifySegmentName(segment.Name))

	if segment.Type == resourcemanager.ConstantSegment {
		if segment.ConstantReference == nil {
			return nil, fmt.Errorf("segment is a constant without a reference")
		}
		constant, ok := constants[*segment.ConstantReference]
		if !ok {
			return nil, fmt.Errorf("segment referenced constant %q but it was not found", *segment.ConstantReference)
		}

		possibleValues := wordifyConstantValues(constant.Values)
		description = fmt.Sprintf("%s. %s.", description, possibleValues)
	}

	if segment.Type == resourcemanager.UserSpecifiedSegment {
		description = fmt.Sprintf("%s. For example `%s`.", description, segment.ExampleValue)
	}

	return &description, nil
}

func wordifyConstantValues(values map[string]string) string {
	components := make([]string, 0)
	for _, v := range values {
		components = append(components, fmt.Sprintf("`%s`", v))
	}
	sort.Strings(components)

	return fmt.Sprintf("Possible values are %s and %s", strings.Join(components[0:len(components)-1], ", "), components[len(components)-1])
}

func isCommonResourceIdNamed(name string, resourceId resourcemanager.ResourceIdDefinition) bool {
	return resourceId.CommonAlias != nil && *resourceId.CommonAlias == name
}
