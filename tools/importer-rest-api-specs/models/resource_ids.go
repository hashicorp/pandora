package models

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
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

func (pri ParsedResourceId) SegmentsAvailableForNaming() []string {
	// first reverse the segments, since we want to take from right -> left
	reversedSegments := make([]ResourceIdSegment, 0)
	for i := len(pri.Segments); i > 0; i-- {
		segment := pri.Segments[i-1]
		reversedSegments = append(reversedSegments, segment)
	}

	segmentsWithoutScope := make([]ResourceIdSegment, 0)
	for _, segment := range reversedSegments {
		if segment.Type == ScopeSegment {
			continue
		}

		segmentsWithoutScope = append(segmentsWithoutScope, segment)
	}

	// if it's an Azure Resource ID (e.g. key-value pairs) (and not just a scope)
	if len(segmentsWithoutScope)%2 == 0 && len(segmentsWithoutScope) > 0 {
		availableSegments := make([]string, 0)
		for _, segment := range segmentsWithoutScope {
			if segment.Type == ConstantSegment || segment.Type == StaticSegment {
				normalized := cleanup.NormalizeSegmentName(segment.Name)
				availableSegments = append(availableSegments, normalized)
			}
		}

		return availableSegments
	}

	availableSegments := make([]string, 0)
	for _, segment := range reversedSegments {
		if segment.Type != UserSpecifiedSegment {
			continue
		}

		// otherwise use the names of any user specifiable segments
		normalized := cleanup.NormalizeSegmentName(segment.Name)
		availableSegments = append(availableSegments, normalized)
	}

	// if it's just a Scope for example, take whatever we've got
	if len(availableSegments) == 0 {
		for _, segment := range reversedSegments {
			normalized := cleanup.NormalizeSegmentName(segment.Name)
			availableSegments = append(availableSegments, normalized)
		}
	}

	return availableSegments
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
				normalizedSegment := cleanup.NormalizeSegment(*segment.FixedValue, true)
				components = append(components, normalizedSegment)
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
