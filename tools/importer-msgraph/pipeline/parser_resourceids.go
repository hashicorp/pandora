package pipeline

import (
	"regexp"
	"strings"
)

type ResourceId struct {
	Name     string
	Segments []ResourceIdSegment
	Tag      string
	SubTags  []string
}

func (r ResourceId) ID() string {
	segments := make([]string, len(r.Segments))
	for i, s := range r.Segments {
		segments[i] = s.Value
	}
	return "/" + strings.Join(segments, "/")
}

func (r ResourceId) IDf() string {
	segments := make([]string, len(r.Segments))
	for i, s := range r.Segments {
		if s.Type == SegmentUserValue {
			segments[i] = "%s"
		} else {
			segments[i] = s.Value
		}
	}
	return "/" + strings.Join(segments, "/")
}

func (r ResourceId) LastLabel() *ResourceIdSegment {
	for i := len(r.Segments) - 1; i > 0; i-- {
		if segment := r.Segments[i]; segment.Type == SegmentLabel && regexp.MustCompile("^[a-zA-Z]+$").MatchString(segment.Value) {
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
	SegmentODataFunction
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

	for _, s := range segments {
		segment := ResourceIdSegment{}
		if strings.HasPrefix(s, "{") && strings.HasSuffix(s, "}") {
			value := s[1 : len(s)-1]
			value = strings.Title(value)
			value = regexp.MustCompile("([^A-Za-z0-9])").ReplaceAllString(value, "")
			segment = ResourceIdSegment{SegmentUserValue, s, &value}
		} else if strings.Contains(s, "(") {
			segment = ResourceIdSegment{SegmentFunction, s, nil}
		} else if strings.HasPrefix(strings.ToLower(s), "microsoft.graph.") || strings.HasPrefix(strings.ToLower(s), "graph.") {
			if tagSuffix(".actions") {
				segment = ResourceIdSegment{SegmentAction, s, nil}
			} else {
				segment = ResourceIdSegment{SegmentCast, s, nil}
			}
		} else if strings.HasPrefix(strings.ToLower(s), "$") {
			segment = ResourceIdSegment{SegmentODataFunction, s, nil}
			//} else if i == len(segments)-1 && normalizeFieldName(segments[i-1]) == "" {
			//	segment = ResourceIdSegment{SegmentAction, s, nil}
		} else {
			segment = ResourceIdSegment{SegmentLabel, s, nil}
		}
		id.Segments = append(id.Segments, segment)
	}
	return
}
