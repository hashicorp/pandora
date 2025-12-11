// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForImport(input generatorModels.ResourceInput) (*string, error) {
	resourceId, ok := input.ResourceIds[input.Details.ResourceIDName]
	if !ok {
		return nil, fmt.Errorf("resource ID %q is used but was not defined", input.Details.ResourceIDName)
	}

	resourceIdDescriptionLines := make([]string, 0)
	for _, value := range resourceId.Segments {
		if value.Type == models.ResourceProviderResourceIDSegmentType || value.Type == models.StaticResourceIDSegmentType {
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
`, input.Details.DisplayName, input.ProviderPrefix, input.ResourceLabel, resourceId.ExampleValue, strings.Join(resourceIdDescriptionLines, "\n"))
	output := strings.TrimSpace(strings.ReplaceAll(importsCode, "'", "`"))
	return &output, nil
}

func descriptionsForSegment(segment models.ResourceIDSegment, resourceId models.ResourceID, details models.TerraformResourceDefinition, constants map[string]models.SDKConstant) (*string, error) {
	if segment.Type == models.ResourceGroupResourceIDSegmentType {
		if isCommonResourceIdNamed("ResourceGroup", resourceId) {
			out := fmt.Sprintf("is the name of this %[1]s. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
			return &out, nil
		}

		out := fmt.Sprintf("is the name of Resource Group where this %[1]s exists. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
		return &out, nil
	}
	if segment.Type == models.SubscriptionIDResourceIDSegmentType {
		if isCommonResourceIdNamed("Subscription", resourceId) {
			out := fmt.Sprintf("is the ID of this %[1]s. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
			return &out, nil
		}

		out := fmt.Sprintf("is the ID of the Azure Subscription where the %[1]s exists. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
		return &out, nil
	}
	if segment.Type == models.ScopeResourceIDSegmentType {
		if isCommonResourceIdNamed("Scope", resourceId) {
			out := fmt.Sprintf("is the Azure Resource Scope under which this %[1]s exists. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
			return &out, nil
		}

		out := fmt.Sprintf("is the ID of the Azure Resource under which the %[1]s exists. For example '%[2]s'.", details.DisplayName, segment.ExampleValue)
		return &out, nil
	}

	description := fmt.Sprintf("is the name of the %s", wordifySegmentName(segment.Name))

	if segment.Type == models.ConstantResourceIDSegmentType {
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

	if segment.Type == models.UserSpecifiedResourceIDSegmentType {
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

func isCommonResourceIdNamed(name string, resourceId models.ResourceID) bool {
	return resourceId.CommonIDAlias != nil && *resourceId.CommonIDAlias == name
}
