package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForResourceID(namespace string, resourceIdName string, resourceIdValue models.ParsedResourceId) (*string, error) {
	segmentsCode := make([]string, 0)
	for _, segment := range resourceIdValue.Segments {
		code, err := g.codeForResourceIDSegment(segment)
		if err != nil {
			return nil, fmt.Errorf("generating segment %q: %+v", segment.Name, err)
		}
		segmentsCode = append(segmentsCode, *code)
	}

	commonAlias := "null"
	if resourceIdValue.CommonAlias != nil {
		commonAlias = fmt.Sprintf("%q", *resourceIdValue.CommonAlias)
	}

	code := fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace %[1]s
{
	internal class %[2]s : ResourceID
	{
		public string? CommonAlias => %[3]s;

		public string ID => "%[4]s";

		public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
		{
%[5]s
		};
	}
}
`, namespace, resourceIdName, commonAlias, resourceIdValue.String(), strings.Join(segmentsCode, "\n"))
	return &code, nil
}

func (g PandoraDefinitionGenerator) codeForResourceIDSegment(input models.ResourceIdSegment) (*string, error) {
	typeName, err := g.codeForResourceIDSegmentType(input.Type)
	if err != nil {
		return nil, err
	}

	indent := "                    "
	lines := []string{
		fmt.Sprintf("%sName = %q", indent, input.Name),
		fmt.Sprintf("%sType = %s", indent, *typeName),
	}

	if input.ConstantReference != nil {
		lines = append(lines, fmt.Sprintf("%sConstantReference = typeof(%sConstant)", indent, *input.ConstantReference))
	}
	if input.FixedValue != nil {
		lines = append(lines, fmt.Sprintf("%sFixedValue = %q", indent, *input.FixedValue))
	}

	output := fmt.Sprintf(`                new()
                {
%[1]s
                },
`, strings.Join(lines, ",\n"))
	return &output, nil
}

func (g PandoraDefinitionGenerator) codeForResourceIDSegmentType(input models.SegmentType) (*string, error) {
	var out = func(in string) (*string, error) {
		return &in, nil
	}

	switch input {
	case models.ConstantSegment:
		return out("ResourceIDSegmentType.Constant")

	case models.ResourceGroupSegment:
		return out("ResourceIDSegmentType.ResourceGroup")

	case models.ResourceProviderSegment:
		return out("ResourceIDSegmentType.ResourceProvider")

	case models.ScopeSegment:
		return out("ResourceIDSegmentType.Scope")

	case models.StaticSegment:
		return out("ResourceIDSegmentType.Static")

	case models.SubscriptionIdSegment:
		return out("ResourceIDSegmentType.SubscriptionId")

	case models.UserSpecifiedSegment:
		return out("ResourceIDSegmentType.UserSpecified")

	default:
		return nil, fmt.Errorf("unimplemented Resource ID Segment Type %q", string(input))
	}
}
