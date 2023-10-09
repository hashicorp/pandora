package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ResourceId struct {
	Name        string    `json:"Name"`
	CommonAlias string    `json:"CommonAlias,omitempty"`
	Id          string    `json:"Id"`
	Segments    []Segment `json:"Segments,omitempty"`
}

type Segment struct {
	Name  string `json:"Name"`
	Type  string `json:"Type"`
	Value string `json:"Value,omitempty"`
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

	data, err := json.MarshalIndent(resourceId, "", " ")
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
