package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type resourceIdParseResult struct {
	resourceUrisToObjects map[string]ParsedResourceId
	nestedResult parseResult
}

type ParsedResourceId struct {
	Constants map[string]models.ConstantDetails
	Segments []ResourceIdSegment
	UriSuffix *string
}

func (pri ParsedResourceId) ResourceId() string {
	return "/TODO/build/this/up/from/the/segments"
}

type ResourceIdSegment struct {
	Type SegmentType
	ConstantReference *string
	FixedValue *string
	OriginalSegmentName string
}

type SegmentType string

const (
	StaticSegment SegmentType = "static"
	ConstantSegment SegmentType = "constant"
	ScopeSegment SegmentType = "scope"
	UserSpecifiedSegment SegmentType = "user-specified"
)

func (d *SwaggerDefinition) findResourceIdsForTag(tag *string) (*resourceIdParseResult, error) {
	return &resourceIdParseResult{}, nil
}
