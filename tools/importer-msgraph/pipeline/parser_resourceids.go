package pipeline

import (
	"regexp"
	"strings"
)

type ResourceId struct {
	segments []ResourceIdSegment
}

func (r ResourceId) ID() string {
	segments := make([]string, len(r.segments))
	for i, s := range r.segments {
		segments[i] = s.Value
	}
	return "/" + strings.Join(segments, "/")
}

func (r ResourceId) IDf() string {
	segments := make([]string, len(r.segments))
	for i, s := range r.segments {
		if s.Type == SegmentUserValue {
			segments[i] = "%s"
		} else {
			segments[i] = s.Value
		}
	}
	return "/" + strings.Join(segments, "/")
}

func (r ResourceId) LastLabel() *ResourceIdSegment {
	for i := len(r.segments) - 1; i > 0; i-- {
		if segment := r.segments[i]; segment.Type == SegmentLabel && regexp.MustCompile("^[a-zA-Z]+$").MatchString(segment.Value) {
			return &segment
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
	id.segments = make([]ResourceIdSegment, 0)

	segments := strings.FieldsFunc(path, func(c rune) bool { return c == '/' })
	for _, s := range segments {
		segment := ResourceIdSegment{}
		if field := normalizeFieldName(s); field != "" {
			segment = ResourceIdSegment{SegmentUserValue, s, &field}
		} else {
			if strings.HasPrefix(strings.ToLower(s), "microsoft.graph.") {
				if strings.Contains(s, "(") {
					segment = ResourceIdSegment{SegmentFunction, s, nil}
				} else if tagSuffix(".actions") {
					segment = ResourceIdSegment{SegmentAction, s, nil}
				} else {
					segment = ResourceIdSegment{SegmentCast, s, nil}
				}
			} else {
				segment = ResourceIdSegment{SegmentLabel, s, nil}
			}
		}
		id.segments = append(id.segments, segment)
	}
	return
}
