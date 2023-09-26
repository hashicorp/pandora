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
	Name  string `yaml:"Name"`
	Type  string `yaml:"Type"`
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
	switch input.Type {
	case resourcemanager.ConstantSegment:
		{
			if input.ConstantReference == nil {
				return nil, fmt.Errorf("constant segment type with missing constant reference: %+v", input)
			}
			return &Segment{
				Type:  "Constant",
				Name:  input.Name,
				Value: *input.ConstantReference,
			}, nil
		}
	case resourcemanager.ResourceGroupSegment:
		{
			return &Segment{
				Type: "ResourceGroup",
				Name: "resourceGroupName",
			}, nil
		}
	case resourcemanager.ResourceProviderSegment:
		{
			if input.FixedValue == nil {
				return nil, fmt.Errorf("resource provider segment type with missing fixed value: %+v", input)
			}
			return &Segment{
				Type:  "ResourceProvider",
				Name:  input.Name,
				Value: *input.FixedValue,
			}, nil
		}
	case resourcemanager.ScopeSegment:
		{
			return &Segment{
				Type: "Scope",
				Name: input.Name,
			}, nil
		}
	case resourcemanager.StaticSegment:
		{
			if input.FixedValue == nil {
				return nil, fmt.Errorf("static segment type with missing fixed value: %+v", input)
			}
			return &Segment{
				Type:  "Static",
				Name:  input.Name,
				Value: *input.FixedValue,
			}, nil
		}
	case resourcemanager.SubscriptionIdSegment:
		{
			return &Segment{
				Type: "SubscriptionId",
				Name: input.Name,
			}, nil
		}
	case resourcemanager.UserSpecifiedSegment:
		{
			return &Segment{
				Type: "UserSpecified",
				Name: input.Name,
			}, nil
		}
	}

	return nil, fmt.Errorf("internal-error: unimplemented segment type %q", string(input.Type))
}
