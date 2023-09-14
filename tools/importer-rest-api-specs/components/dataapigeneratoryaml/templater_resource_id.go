package dataapigeneratoryaml

import (
	"fmt"

	"github.com/go-yaml/yaml"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ResourceId struct {
	Name        string    `yaml:"Name"`
	CommonAlias string    `yaml:"CommonAlias,omitempty"`
	Id          string    `yaml:"Id"`
	Segments    []Segment `yaml:"Segments,omitempty"`
}

type Segment struct {
	Type  string `yaml:"Type"`
	Name  string `yaml:"Name"`
	Value string `yaml:"Value,omitempty"`
}

func codeForResourceID(resourceIdName string, resourceIdValue models.ParsedResourceId) ([]byte, error) {
	segments := make([]Segment, 0)
	for _, segment := range resourceIdValue.Segments {
		s, err := codeForResourceIDSegment(segment)
		if err != nil {
			return nil, fmt.Errorf("generating segment %q: %+v", segment.Name, err)
		}
		segments = append(segments, *s)
	}

	commonAlias := ""
	if resourceIdValue.CommonAlias != nil {
		commonAlias = fmt.Sprintf("%q", *resourceIdValue.CommonAlias)
	}

	resourceId := ResourceId{
		Name:        resourceIdName,
		CommonAlias: commonAlias,
		Id:          resourceIdValue.String(),
		Segments:    segments,
	}

	data, err := yaml.Marshal(resourceId)
	if err != nil {
		return nil, err
	}

	return data, nil
}

func codeForResourceIDSegment(input resourcemanager.ResourceIdSegment) (*Segment, error) {
	segment := Segment{}

	switch input.Type {
	case resourcemanager.ConstantSegment:
		{
			if input.ConstantReference == nil {
				return nil, fmt.Errorf("constant segment type with missing constant reference: %+v", input)
			}

			segment.Type = "Constant"
			segment.Name = input.Name
			segment.Value = *input.ConstantReference
			return &segment, nil
		}

	case resourcemanager.ResourceGroupSegment:
		{
			segment.Type = "ResourceGroup"
			segment.Name = "resourceGroupName"
			return &segment, nil
		}

	case resourcemanager.ResourceProviderSegment:
		{
			if input.FixedValue == nil {
				return nil, fmt.Errorf("resource provider segment type with missing fixed value: %+v", input)
			}

			segment.Type = "ResourceProvider"
			segment.Name = input.Name
			segment.Value = *input.FixedValue
			return &segment, nil
		}

	case resourcemanager.ScopeSegment:
		{
			segment.Type = "Scope"
			segment.Name = input.Name
			return &segment, nil
		}

	case resourcemanager.StaticSegment:
		{
			if input.FixedValue == nil {
				return nil, fmt.Errorf("static segment type with missing fixed value: %+v", input)
			}

			segment.Type = "Static"
			segment.Name = input.Name
			segment.Value = *input.FixedValue
			return &segment, nil
		}

	case resourcemanager.SubscriptionIdSegment:
		{
			segment.Type = "SubscriptionId"
			segment.Name = input.Name
			return &segment, nil
		}

	case resourcemanager.UserSpecifiedSegment:
		{
			segment.Type = "UserSpecified"
			segment.Name = input.Name
			return &segment, nil
		}
	}

	return nil, fmt.Errorf("internal-error: unimplemented segment type %q", string(input.Type))
}
