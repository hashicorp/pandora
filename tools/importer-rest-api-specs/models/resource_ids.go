package models

import (
	"fmt"
	"strings"
)

type ParsedResourceId struct {
	// Constants are a map[Name]ConstantDetails for the Constants used in this Resource ID
	Constants map[string]ConstantDetails

	// Segments are an ordered list of segments which comprise this Resource ID
	Segments []ResourceIdSegment
}

func (pri ParsedResourceId) String() string {
	// only used for debug purposes
	return normalizedResourceId(pri.Segments)
}

func (pri ParsedResourceId) UserSpecifiableSegmentNames() []string {
	output := make([]string, 0)

	for _, segment := range pri.Segments {
		if segment.Type == ConstantSegment || segment.Type == ResourceGroupSegment || segment.Type == ScopeSegment || segment.Type == SubscriptionIdSegment || segment.Type == UserSpecifiedSegment {
			output = append(output, segment.Name)
		}
	}

	return output
}

func (pri ParsedResourceId) NormalizedResourceManagerResourceId() string {
	segments := pri.Segments
	lastUserValueSegment := -1
	for i, segment := range segments {
		// everything else technically is a user configurable component
		if segment.Type != StaticSegment {
			lastUserValueSegment = i
		}
	}
	if lastUserValueSegment >= 0 && len(segments) > lastUserValueSegment+1 {
		// remove any URI Suffix since this isn't relevant for the ID's
		segments = segments[0 : lastUserValueSegment+1]
	}

	return normalizedResourceId(segments)
}

func (pri ParsedResourceId) NormalizedResourceId() string {
	return normalizedResourceId(pri.Segments)
}

func normalizedResourceId(segments []ResourceIdSegment) string {
	components := make([]string, 0)
	for _, segment := range segments {
		switch segment.Type {
		case StaticSegment:
			{
				components = append(components, *segment.FixedValue)
				continue
			}
			
		case ConstantSegment, ResourceGroupSegment, ScopeSegment, SubscriptionIdSegment, UserSpecifiedSegment:
			// e.g. {example}
			components = append(components, fmt.Sprintf("{%s}", segment.Name))
			continue

		default:
			panic(fmt.Sprintf("unimplemented segment type %q", string(segment.Type)))
		}
	}

	return fmt.Sprintf("/%s", strings.Join(components, "/"))
}

type ResourceIdSegment struct {
	// Type specifies the Segment Type, such as a Constant/UserSpecified
	Type SegmentType

	// ConstantReference is the name of the Constant that this Segment uses - if Type is `Constant`
	ConstantReference *string

	// FixedValue is a fixed/static value for this segment when Type is `Static`
	FixedValue *string

	// Name is the name of this segment, for example `ResourceGroups` or `VirtualMachine` in Title Case.
	Name string
}

type SegmentType string

const (
	StaticSegment         SegmentType = "static"
	ConstantSegment       SegmentType = "constant"
	ResourceGroupSegment  SegmentType = "resource-group"
	SubscriptionIdSegment SegmentType = "subscription-id"
	ScopeSegment          SegmentType = "scope"
	UserSpecifiedSegment  SegmentType = "user-specified"
)
