package pipeline

import (
	"fmt"
	"regexp"
	"sort"
	"strings"
)

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

func (r ResourceId) Match(r2 ResourceId) (ResourceId, bool) {
	var i int
	for i = 0; i < len(r.Segments); i++ {
		if i < len(r2.Segments) {
			s := r.Segments[i]
			if s2 := r2.Segments[i]; s.Type == s2.Type && s.Value == s2.Value {
				continue
			}
		}
		return r2, false
	}
	if len(r2.Segments) >= i {
		return ResourceId{Segments: r2.Segments[i:]}, true
	} else {
		return ResourceId{Segments: make([]ResourceIdSegment, 0)}, true
	}
}

func (r ResourceId) FindResourceName() *string {
	slugs := make([]ResourceIdSegment, 0)
	idx := len(r.Segments) - 1
	for i := idx; i >= 0; i-- {
		if idSegment := r.Segments[i]; idSegment.Type == SegmentAction || idSegment.Type == SegmentLabel {
			idx = i
			break
		}
	}
	for j := idx; j >= 0; j-- {
		segment := r.Segments[j]
		if segment.Type == SegmentAction || segment.Type == SegmentLabel {
			slugs = append(slugs, segment)

			// Hop over a SegmentUserValue if we only have an action, to prevent unqualified resource names like "Stop"
			if segment.Type == SegmentAction && j > 0 {
				if preceedingSegment := r.Segments[j-1]; preceedingSegment.Type == SegmentUserValue {
					j--
				}
			}

			// Hop over a SegmentUserValue if we only have an unqualified label describing a relationship (determined by a succeeding SegmentODataReference)
			if segment.Type == SegmentLabel && j > 0 && j+1 < len(r.Segments) {
				if preceedingSegment := r.Segments[j-1]; preceedingSegment.Type == SegmentUserValue {
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
	if len(slugs) > 0 {
		name := ""
		for _, slug := range slugs {
			newName := cleanName(slug.Value)
			if slug.Type == SegmentLabel {
				newName = singularize(newName)
			}
			name = newName + name
		}
		return &name
	}

	return nil
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

type ResourceIdSegment struct {
	Type  ResourceIdSegmentType
	Value string
	Field *string
}

type ResourceIdSegmentType uint

const (
	SegmentLabel ResourceIdSegmentType = iota
	SegmentAction
	SegmentUserValue
	SegmentCast
	SegmentFunction
	SegmentODataReference
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
			segment = ResourceIdSegment{SegmentUserValue, fmt.Sprintf("{%s}", value), &field}
		} else if strings.Contains(s, "(") {
			segment = ResourceIdSegment{SegmentFunction, s, nil}
		} else if strings.HasPrefix(strings.ToLower(s), "microsoft.graph.") || strings.HasPrefix(strings.ToLower(s), "graph.") {
			if tagSuffix(".actions") {
				segment = ResourceIdSegment{SegmentAction, s, nil}
			} else {
				segment = ResourceIdSegment{SegmentCast, s, nil}
			}
		} else if strings.HasPrefix(strings.ToLower(s), "$") {
			segment = ResourceIdSegment{SegmentODataReference, s, nil}
		} else if i == len(segments)-1 && tagSuffix(".actions") {
			segment = ResourceIdSegment{SegmentAction, s, nil}
		} else if i == len(segments)-1 && tagSuffix(".functions") {
			segment = ResourceIdSegment{SegmentFunction, s, nil}
		} else {
			segment = ResourceIdSegment{SegmentLabel, s, nil}
		}
		id.Segments = append(id.Segments, segment)
	}
	return
}

type ResourceIds []*ResourceId

type ResourceIdMatch struct {
	Id        *ResourceId
	Remainder *ResourceId
}

func (ri ResourceIds) MatchIdOrParent(r2 ResourceId) (*ResourceIdMatch, bool) {
	matches := make([]ResourceIdMatch, 0)
	for _, r1 := range ri {
		if r1 == nil {
			continue
		}
		if remainder, ok := r1.Match(r2); ok {
			matches = append(matches, ResourceIdMatch{r1, &remainder})
		}
	}
	if len(matches) > 0 {
		sort.SliceStable(matches, func(i int, j int) bool {
			return len(matches[i].Id.Segments) > len(matches[j].Id.Segments)
		})
		return &matches[0], true
	}
	return nil, false
}
