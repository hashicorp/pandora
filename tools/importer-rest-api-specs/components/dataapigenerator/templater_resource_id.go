package dataapigenerator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func codeForResourceID(namespace string, resourceIdName string, resourceIdValue models.ParsedResourceId) (*string, error) {
	segmentsCode := make([]string, 0)
	for _, segment := range resourceIdValue.Segments {
		code, err := codeForResourceIDSegment(segment)
		if err != nil {
			return nil, fmt.Errorf("generating segment %q: %+v", segment.Name, err)
		}
		segmentsCode = append(segmentsCode, fmt.Sprintf("\t\t%s,", *code))
	}

	commonAlias := "null"
	if resourceIdValue.CommonAlias != nil {
		commonAlias = fmt.Sprintf("%q", *resourceIdValue.CommonAlias)
	}

	code := fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

%[6]s

namespace %[1]s;

internal class %[2]s : ResourceID
{
	public string? CommonAlias => %[3]s;

	public string ID => "%[4]s";

	public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
	{
%[5]s
	};
}
`, namespace, resourceIdName, commonAlias, resourceIdValue.String(), strings.Join(segmentsCode, "\n"), restApiSpecsLicence)
	return &code, nil
}

func codeForResourceIDSegment(input models.ResourceIdSegment) (*string, error) {
	switch input.Type {
	case resourcemanager.ConstantSegment:
		{
			if input.ConstantReference == nil {
				return nil, fmt.Errorf("constant segment type with missing constant reference: %+v", input)
			}

			out := fmt.Sprintf("ResourceIDSegment.Constant(%[1]q, typeof(%[2]sConstant))", input.Name, *input.ConstantReference)
			return &out, nil
		}

	case resourcemanager.ResourceGroupSegment:
		{
			out := fmt.Sprintf("ResourceIDSegment.ResourceGroup(%[1]q)", input.Name)
			return &out, nil
		}

	case resourcemanager.ResourceProviderSegment:
		{
			if input.FixedValue == nil {
				return nil, fmt.Errorf("resource provider segment type with missing fixed value: %+v", input)
			}

			out := fmt.Sprintf("ResourceIDSegment.ResourceProvider(%[1]q, %[2]q)", input.Name, *input.FixedValue)
			return &out, nil
		}

	case models.ScopeSegment:
		{
			out := fmt.Sprintf("ResourceIDSegment.Scope(%[1]q)", input.Name)
			return &out, nil
		}

	case resourcemanager.StaticSegment:
		{
			if input.FixedValue == nil {
				return nil, fmt.Errorf("static segment type with missing fixed value: %+v", input)
			}

			out := fmt.Sprintf("ResourceIDSegment.Static(%[1]q, %[2]q)", input.Name, *input.FixedValue)
			return &out, nil
		}

	case resourcemanager.SubscriptionIdSegment:
		{
			out := fmt.Sprintf("ResourceIDSegment.SubscriptionId(%[1]q)", input.Name)
			return &out, nil
		}

	case resourcemanager.UserSpecifiedSegment:
		{
			out := fmt.Sprintf("ResourceIDSegment.UserSpecified(%[1]q)", input.Name)
			return &out, nil
		}
	}

	return nil, fmt.Errorf("internal-error: unimplemented segment type %q", string(input.Type))
}
