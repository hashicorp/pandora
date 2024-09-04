// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"sort"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/normalize"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/tags"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

const (
	ResourceSuffix   = ""
	ResourceIdSuffix = "Id"
)

type ResourceIds map[string]*ResourceId

type ResourceIdMatch struct {
	Id        *ResourceId
	Remainder *ResourceId
}

// MatchIdOrAncestor returns a ResourceIdMatch containing a matching/ancestor ResourceId and/or a remainder value, or nil if no
// match/ancestor was found. A match is a ResourceId that represents the same path, and an ancestor is any ResourceId that
// represents a shorter matching path. Where multiple ancestors are found, the most granular (i.e. the longest) ancestor is returned.
//
// Example 1:
// If resourceId represents `/users/{userId}`
// The returned ResourceIdMatch is likely to represent `/users/{userId}` (a match) with no remainder.
//
// Example 2:
// If resourceId represents `/applications/{applicationId}/owners`
// The returned ResourceIdMatch is likely to represent `/applications/{applicationId}` with a remainder of `/owners`
func (ri ResourceIds) MatchIdOrAncestor(resourceId ResourceId) (*ResourceIdMatch, bool) {
	matches := make([]ResourceIdMatch, 0)

	for _, potentialMatchingOrParentId := range ri {
		if potentialMatchingOrParentId == nil {
			continue
		}
		if remainder, ok := potentialMatchingOrParentId.IsMatchOrAncestor(resourceId); ok {
			matches = append(matches, ResourceIdMatch{potentialMatchingOrParentId, &remainder})
		}
	}

	// Select the matching ID with most segments, assume this is the most granular match
	if len(matches) > 0 {
		sort.SliceStable(matches, func(i int, j int) bool {
			return len(matches[i].Id.Segments) > len(matches[j].Id.Segments)
		})
		return &matches[0], true
	}

	return nil, false
}

type ResourceId struct {
	Name     string
	Service  string
	Segments []ResourceIdSegment
}

func (r ResourceId) ID() string {
	segments := make([]string, len(r.Segments))
	for i, s := range r.Segments {
		segments[i] = s.Value
	}
	return "/" + strings.Join(segments, "/")
}

func (r ResourceId) DataApiSdkResourceId() (*sdkModels.ResourceID, error) {
	sdkSegments := make([]sdkModels.ResourceIDSegment, 0, len(r.Segments))

	for i, segment := range r.Segments {
		switch segment.Type {
		case SegmentAction, SegmentCast, SegmentFunction, SegmentLabel, SegmentODataReference:
			sdkSegments = append(sdkSegments, sdkModels.NewStaticValueResourceIDSegment(segment.Value, segment.Value))
		case SegmentUserValue:
			sdkSegments = append(sdkSegments, sdkModels.NewUserSpecifiedResourceIDSegment(normalize.CleanNameCamel(*segment.field), segment.Value))
		default:
			return nil, fmt.Errorf("unknown segment type %q at index %d for resource ID: %q", segment.Type, i, r.Name)
		}
	}

	return &sdkModels.ResourceID{
		CommonIDAlias: nil,
		ConstantNames: nil,
		Constants:     nil,
		ExampleValue:  r.ID(),
		Segments:      sdkSegments,
	}, nil
}

// IsMatchOrAncestor compares the provided ResourceId (r2) against the current ResourceId and returns true if the
// two resource IDs match, or if this ResourceId is an ancestor of the provided ResourceId.
func (r ResourceId) IsMatchOrAncestor(r2 ResourceId) (ResourceId, bool) {
	rLen := len(r.Segments)
	r2Len := len(r2.Segments)

	if rLen > r2Len {
		// The candidate ID is longer than the provided ID, so it cannot be a match nor an ancestor
		return r2, false
	}

	for i := range r.Segments {
		s := r.Segments[i]
		s2 := r2.Segments[i]

		if s.Type != s2.Type || s.Value != s2.Value {
			// A non-matching segment was reached, so it cannot be a match or an ancestor
			return r2, false
		}
	}

	if r2Len > rLen {
		// A match was found but this candidate is shorter, ergo it must be an ancestor, so return the remainder
		return ResourceId{Segments: r2.Segments[rLen:]}, true
	}

	// This candidate matches the provided ID
	return ResourceId{Segments: make([]ResourceIdSegment, 0)}, true
}

// FullyQualifiedResourceName returns a human-readable name for the ResourceId, using all segments, each segment singularized
// except when the following segment is an OData reference or plural function, or the first known verb is encountered.
// e.g.
// if r represents `/applications/{applicationId}/synchronization/jobs/{synchronizationJobId}/schema`, the returned name
// will be `ApplicationSynchronizationJob`
func (r ResourceId) FullyQualifiedResourceName(suffixQualification *string) (*string, bool) {
	name := ""
	verb := ""
	for i, segment := range r.Segments {
		if segment.Type == SegmentAction || segment.Type == SegmentLabel || segment.Type == SegmentODataReference {
			newName := normalize.CleanName(segment.Value)
			shouldSingularize := false

			if segment.Type == SegmentLabel {
				// Singularize all labels by default
				shouldSingularize = true

				if i == len(r.Segments)+1 {
					// Don't singularize the final segment, so it can still be reliably verb-matched when parsing operations later
					shouldSingularize = false
				}

				if len(r.Segments) > i+1 && r.Segments[i+1].Type != SegmentUserValue {
					// Look for a verb match in the next segment, if it exists and is not a SegmentUserValue
					// Example: in the following ID, we want to _not_ singularize the `jobs` label
					//          /applications/{applicationId}/synchronization/jobs/validateCredentials
					if _, ok := normalize.Verbs.Match(normalize.CleanName(r.Segments[i+1].Value)); ok {
						shouldSingularize = false
					}
				}

				if len(r.Segments) > i+1 && r.Segments[i+1].Type == SegmentODataReference && (r.Segments[i+1].Value == "$count") {
					// $count indicates a plural entity (noting that this only applies when the current
					// segment is a label and not user-specified).
					shouldSingularize = false
				}
			}

			// Explicitly pluralize a $ref segment when the previous segment was a label and plural
			if segment.Type == SegmentODataReference && segment.Value == "$ref" && r.Segments[i-1].plural {
				newName = normalize.Pluralize(newName)
			}

			// Note we intentionally match verbs on any segment type, not just SegmentTypeAction
			if v, ok := normalize.Verbs.Match(newName); ok && verb == "" {
				verb = *v
				newName = newName[len(verb):]
				shouldSingularize = false
			}

			if shouldSingularize {
				newName = normalize.Singularize(newName)
			}

			name = name + newName
		} else if segment.Type == SegmentUserValue && suffixQualification != nil {
			name = name + *suffixQualification
		}
	}

	if verb != "" {
		name = verb + name
	}

	if name == "" {
		return nil, false
	}

	// TODO: it would be nice to do this but it's causing some clobbering issues
	//name = normalize.DeDuplicateName(name)

	return &name, true
}

// FindResourceName returns a short resource name based on the last significant segments of the ResourceId. Singularization
// follows the same rules as FullyQualifiedResourceName.
// e.g.
// if r represents `/applications/{applicationId}/synchronization/jobs/{synchronizationJobId}/schema`, the (shortened)
// returned name will be `SynchronizationJob`.
func (r ResourceId) FindResourceName() (*string, bool) {
	r2 := ResourceId{
		Segments: make([]ResourceIdSegment, 0),
	}
	idx := len(r.Segments) - 1

	for i := idx; i >= 0; i-- {
		if idSegment := r.Segments[i]; idSegment.Type == SegmentAction || idSegment.Type == SegmentLabel || idSegment.Type == SegmentODataReference {
			idx = i
			break
		}
	}

	// Note we're working backwards through the segments, starting at the end
	for j := idx; j >= 0; j-- {
		segment := r.Segments[j]
		if segment.Type == SegmentAction || segment.Type == SegmentLabel || segment.Type == SegmentODataReference {
			r2.Segments = append([]ResourceIdSegment{segment}, r2.Segments...)

			// Hop over a SegmentUserValue if we only have an action or ref, to prevent unqualified resource names like "Stop" or "Ref",
			// however also include the SegmentUserValue in the shortened ResourceId so that FullyQualifiedResourceName() can determine plurality
			// Example: /applications/{applicationId}/synchronization/jobs/{synchronizationJobId}/validateCredentials
			if (segment.Type == SegmentAction || segment.Type == SegmentODataReference) && j > 0 {
				if precedingSegment := r.Segments[j-1]; precedingSegment.Type == SegmentUserValue {
					r2.Segments = append([]ResourceIdSegment{precedingSegment}, r2.Segments...)
					j--
				}
			}

			// Hop over a SegmentUserValue if we only have an unqualified label describing a relationship (determined by a succeeding SegmentODataReference)
			if segment.Type == SegmentLabel && j > 0 {
				if j+1 == len(r.Segments) {
					if precedingSegment := r.Segments[j-1]; precedingSegment.Type == SegmentUserValue {
						// Example: /agreements/{agreementId}/file
						j--
					}
				} else {
					if precedingSegment := r.Segments[j-1]; precedingSegment.Type == SegmentUserValue {
						if succeedingSegment := r.Segments[j+1]; succeedingSegment.Type == SegmentODataReference {
							// Example: /applications/{applicationId}/owners/$ref
							j--
						} else if j+2 < len(r.Segments) && succeedingSegment.Type == SegmentUserValue {
							if nextSucceedingSegment := r.Segments[j+2]; nextSucceedingSegment.Type == SegmentODataReference {
								// Example: /applications/{applicationId}/owners/{ownerId}/$ref
								j--
							}
						}
					}
				}
			}

			continue
		}
		break
	}

	return r2.FullyQualifiedResourceName(pointer.To(ResourceSuffix))
}

// FindResourceIdName returns a short name for the ResourceId. This currently has the same behavior as FindResourceName
// but may be changed in future if the ResourceId needs to be distinctly named.
func (r ResourceId) FindResourceIdName() (*string, bool) {
	name, ok := r.FullyQualifiedResourceName(pointer.To(ResourceIdSuffix))
	return name, ok
}

func (r ResourceId) HasUserValue() bool {
	for _, s := range r.Segments {
		if s.Type == SegmentUserValue {
			return true
		}
	}
	return false
}

// LastLabel returns the last label segment from the ResourceId
func (r ResourceId) LastLabel() *ResourceIdSegment {
	return r.LastLabelBeforeSegment(-1)
}

// LastLabelBeforeSegment returns the last label segment from the ResourceId that precedes the provided segment index
func (r ResourceId) LastLabelBeforeSegment(i int) *ResourceIdSegment {
	return r.LastSegmentOfTypeBeforeSegment([]ResourceIdSegmentType{SegmentLabel}, i)
}

// LastSegmentOfTypeBeforeSegment returns the last segment of the specified type from the ResourceId that precedes the
// provided segment index
func (r ResourceId) LastSegmentOfTypeBeforeSegment(types []ResourceIdSegmentType, i int) *ResourceIdSegment {
	if segmentsLen := len(r.Segments); i < 0 || i > segmentsLen {
		i = segmentsLen
	}
	for i > 0 {
		i--
		segment := r.Segments[i]
		for _, segmentType := range types {
			if segment.Type == segmentType {
				return &segment
			}
		}
	}
	return nil
}

// TruncateToLastSegmentOfTypeBeforeSegment returns a new ResourceId, truncating this ResourceId to the last segment of
// the specified type from the ResourceId that precedes the provided segment index
func (r ResourceId) TruncateToLastSegmentOfTypeBeforeSegment(types []ResourceIdSegmentType, i int) *ResourceId {
	ret := r
	if segmentsLen := len(r.Segments); i < 0 || i > segmentsLen {
		i = segmentsLen
	}
	for i > 0 {
		i--
		segment := r.Segments[i]
		if len(types) == 0 {
			ret.Segments = r.Segments[:i+1]
			return &ret
		}
		for _, segmentType := range types {
			if segment.Type == segmentType {
				ret.Segments = r.Segments[:i+1]
				return &ret
			}
		}
	}
	return nil
}

type ResourceIdSegment struct {
	Type  ResourceIdSegmentType
	Value string

	// indicates the name to use when converting a SegmentUserValue to an sdkModels.ResourceIDSegment
	field *string

	// indicates whether the original value for a SegmentLabel was a plural
	plural bool
}

type ResourceIdSegmentType string

const (
	SegmentLabel          ResourceIdSegmentType = "Label"
	SegmentUserValue      ResourceIdSegmentType = "UserValue"
	SegmentODataReference ResourceIdSegmentType = "ODataReference"
	SegmentAction         ResourceIdSegmentType = "Action"
	SegmentCast           ResourceIdSegmentType = "Cast"
	SegmentFunction       ResourceIdSegmentType = "Function"
)

func NewResourceId(path string, tags []string) (id ResourceId) {
	tagSuffix := func(suffix string) bool {
		for _, t := range tags {
			if strings.HasSuffix(strings.ToLower(t), suffix) {
				return true
			}
		}
		return false
	}

	segments := strings.FieldsFunc(path, func(c rune) bool { return c == '/' })
	id.Segments = make([]ResourceIdSegment, 0, len(segments))

	for i, s := range segments {
		var segment ResourceIdSegment

		if strings.HasPrefix(s, "{") && strings.HasSuffix(s, "}") {
			value := s[1 : len(s)-1]
			value = normalize.CleanName(value)
			field := value
			value = strings.ToLower(value[0:1]) + value[1:]
			segment = ResourceIdSegment{
				Type:  SegmentUserValue,
				Value: fmt.Sprintf("{%s}", value),
				field: &field,
			}
		} else if strings.Contains(s, "(") {
			segment = ResourceIdSegment{
				Type:  SegmentFunction,
				Value: s,
				field: nil,
			}
		} else if strings.HasPrefix(strings.ToLower(s), "microsoft.graph.") || strings.HasPrefix(strings.ToLower(s), "graph.") {
			if tagSuffix(".actions") {
				value := s
				if strings.HasPrefix(strings.ToLower(value), "microsoft.graph.") {
					value = value[16:]
				}
				if strings.HasPrefix(strings.ToLower(value), "graph.") {
					value = value[6:]
				}
				if value == "" {
					value = s
				}
				segment = ResourceIdSegment{
					Type:  SegmentAction,
					Value: value,
					field: nil,
				}
			} else {
				segment = ResourceIdSegment{
					Type:  SegmentCast,
					Value: s,
					field: nil,
				}
			}
		} else if strings.HasPrefix(s, "$") {
			segment = ResourceIdSegment{
				Type:  SegmentODataReference,
				Value: s,
				field: nil,
			}
		} else if i == len(segments)-1 && tagSuffix(".actions") {
			segment = ResourceIdSegment{
				Type:  SegmentAction,
				Value: s,
				field: nil,
			}
		} else if i == len(segments)-1 && tagSuffix(".functions") {
			segment = ResourceIdSegment{
				Type:  SegmentFunction,
				Value: s,
				field: nil,
			}
		} else {
			segment = ResourceIdSegment{
				Type:   SegmentLabel,
				Value:  s,
				field:  nil,
				plural: normalize.Pluralize(s) == s,
			}
		}

		id.Segments = append(id.Segments, segment)
	}

	return
}

func ParseResourceIDs(paths openapi3.Paths, serviceName *string) (resourceIds ResourceIds, err error) {
	resourceIds = make(ResourceIds)
	for path, item := range paths {
		operations := item.Operations()
		operationTags := make([]string, 0)

		if serviceName != nil {
			// Check tags and skip
			skip := true
			for _, operation := range operations {
				if tags.Matches(*serviceName, operation.Tags) {
					operationTags = append(operationTags, operation.Tags...)
					skip = false
					break
				}
			}
			if skip {
				continue
			}
		}

		id := NewResourceId(path, operationTags)
		if len(id.Segments) == 0 {
			continue
		}
		segmentsLastIndex := len(id.Segments) - 1

		lastSegment := id.Segments[segmentsLastIndex]
		if lastSegment.Type == SegmentODataReference {
			lastSegment = id.Segments[segmentsLastIndex-1]
			truncated := id.TruncateToLastSegmentOfTypeBeforeSegment([]ResourceIdSegmentType{}, segmentsLastIndex)
			if truncated == nil {
				err = fmt.Errorf("unable to truncate resource ID with OData Reference: %q", id.ID())
				return
			}
			id = *truncated
		}
		if lastSegment.Type != SegmentUserValue {
			continue
		}

		resourceIdName := ""
		if r, ok := id.FindResourceIdName(); ok {
			resourceIdName = normalize.Singularize(normalize.CleanName(*r))
		}

		if resourceIdName != "" {
			logging.Infof(fmt.Sprintf("Found resource ID %q", resourceIdName))

			id.Name = resourceIdName

			if serviceName != nil {
				id.Service = normalize.CleanName(*serviceName)
			}

			resourceIds[resourceIdName] = &id
		}
	}

	return

}
