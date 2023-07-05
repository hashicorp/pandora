package pipeline

import (
	"fmt"
	"regexp"
	"sort"
	"strings"
)

type ResourceIds []*ResourceId

type ResourceIdMatch struct {
	Id        *ResourceId
	Remainder *ResourceId
}

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
	Version  string
	Segments []ResourceIdSegment
}

func (r ResourceId) ID() string {
	segments := make([]string, len(r.Segments))
	for i, s := range r.Segments {
		segments[i] = s.Value
	}
	return "/" + strings.Join(segments, "/")
}

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

func (r ResourceId) FullyQualifiedResourceName() (*string, bool) {
	name := ""
	verb := ""
	for _, segment := range r.Segments {
		if segment.Type == SegmentAction || segment.Type == SegmentLabel || segment.Type == SegmentODataReference {
			newName := cleanName(segment.Value)
			shouldSingularize := false

			if segment.Type == SegmentLabel {
				shouldSingularize = true
			}

			if v, ok := verbs.match(newName); ok && verb == "" {
				verb = *v
				newName = newName[len(verb):]
				shouldSingularize = false
			}

			if shouldSingularize {
				newName = singularize(newName)
			}

			name = name + newName

		}
	}

	if verb != "" {
		name = verb + name
	}

	if name == "" {
		return nil, false
	}

	name = deDuplicateName(name)
	return &name, true
}

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

	for j := idx; j >= 0; j-- {
		segment := r.Segments[j]
		if segment.Type == SegmentAction || segment.Type == SegmentLabel || segment.Type == SegmentODataReference {
			r2.Segments = append([]ResourceIdSegment{segment}, r2.Segments...)

			// Hop over a SegmentUserValue if we only have an action or ref, to prevent unqualified resource names like "Stop" or "Ref"
			if (segment.Type == SegmentAction || segment.Type == SegmentODataReference) && j > 0 {
				if precedingSegment := r.Segments[j-1]; precedingSegment.Type == SegmentUserValue {
					j--
				}
			}

			// Hop over a SegmentUserValue if we only have an unqualified label describing a relationship (determined by a succeeding SegmentODataReference)
			if segment.Type == SegmentLabel && j > 0 && j+1 < len(r.Segments) {
				if precedingSegment := r.Segments[j-1]; precedingSegment.Type == SegmentUserValue {
					if succeedingSegment := r.Segments[j+1]; succeedingSegment.Type == SegmentODataReference {
						j--
					} else if j+2 < len(r.Segments) && succeedingSegment.Type == SegmentUserValue {
						if nextSucceedingSegment := r.Segments[j+2]; nextSucceedingSegment.Type == SegmentODataReference {
							j--
						}
					}
				}
			}

			continue
		}
		break
	}

	return r2.FullyQualifiedResourceName()
}

func (r ResourceId) FindResourceIdName() (*string, bool) {
	idName := ""
	if resourceName, ok := r.FindResourceName(); ok {
		idName = *resourceName
	}
	if idName != "" {
		//idName = idName + "Id"
		//idName = deDuplicate(idName)
		return &idName, true
	}
	return nil, false
}

func (r ResourceId) HasUserValue() bool {
	for _, s := range r.Segments {
		if s.Type == SegmentUserValue {
			return true
		}
	}
	return false
}

func (r ResourceId) LastLabel() *ResourceIdSegment {
	return r.LastLabelBeforeSegment(-1)
}

func (r ResourceId) LastLabelBeforeSegment(i int) *ResourceIdSegment {
	return r.LastSegmentOfTypeBeforeSegment([]ResourceIdSegmentType{SegmentLabel}, i)
}

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
	Field *string
}

type ResourceIdSegmentType uint

const (
	SegmentLabel ResourceIdSegmentType = iota
	SegmentUserValue
	SegmentODataReference
	SegmentAction
	SegmentCast
	SegmentFunction
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
		segment := ResourceIdSegment{}

		if strings.HasPrefix(s, "{") && strings.HasSuffix(s, "}") {
			value := s[1 : len(s)-1]
			value = strings.Title(strings.ReplaceAll(value, "-", " "))
			value = regexp.MustCompile("([^A-Za-z0-9])").ReplaceAllString(value, "")
			value = strings.ToLower(value[0:1]) + value[1:]
			field := strings.Title(value)
			segment = ResourceIdSegment{
				Type:  SegmentUserValue,
				Value: fmt.Sprintf("{%s}", value),
				Field: &field,
			}
		} else if strings.Contains(s, "(") {
			segment = ResourceIdSegment{
				Type:  SegmentFunction,
				Value: s,
				Field: nil,
			}
		} else if strings.HasPrefix(strings.ToLower(s), "microsoft.graph.") || strings.HasPrefix(strings.ToLower(s), "graph.") {
			if tagSuffix(".actions") {
				segment = ResourceIdSegment{
					Type:  SegmentAction,
					Value: s,
					Field: nil,
				}
			} else {
				segment = ResourceIdSegment{
					Type:  SegmentCast,
					Value: s,
					Field: nil,
				}
			}
		} else if strings.HasPrefix(s, "$") {
			segment = ResourceIdSegment{
				Type:  SegmentODataReference,
				Value: s,
				Field: nil,
			}
		} else if i == len(segments)-1 && tagSuffix(".actions") {
			segment = ResourceIdSegment{
				Type:  SegmentAction,
				Value: s,
				Field: nil,
			}
		} else if i == len(segments)-1 && tagSuffix(".functions") {
			segment = ResourceIdSegment{
				Type:  SegmentFunction,
				Value: s,
				Field: nil,
			}
		} else {
			segment = ResourceIdSegment{
				Type:  SegmentLabel,
				Value: s,
				Field: nil,
			}
		}

		id.Segments = append(id.Segments, segment)
	}

	return
}
