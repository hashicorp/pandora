package pipeline

import (
	"fmt"
	"regexp"
	"strings"
)

type ResourceId struct {
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

func (r ResourceId) FindResource() *ResourceIdSegment {
	for i := len(r.Segments) - 1; i > 0; i-- {
		if segment := r.Segments[i]; segment.Type == SegmentUserValue {
			return r.LastLabelBeforeSegment(i)
		}
	}
	return r.LastLabel()
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
