package parser

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type resourceIdParseResult struct {
	resourceUrisToObjects map[string]parsedResourceId
	nestedResult          parseResult
}

type parsedResourceId struct {
	nestedResult parseResult
	segments     []ResourceIdSegment
	uriSuffix    *string
}

func (pri parsedResourceId) NormalizedResourceId() string {
	components := make([]string, 0)
	for _, segment := range pri.segments {
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
	Type              SegmentType
	ConstantReference *string
	FixedValue        *string
	Name              string
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

func (d *SwaggerDefinition) findResourceIdsForTag(tag *string) (*resourceIdParseResult, error) {
	result := resourceIdParseResult{
		nestedResult: parseResult{
			constants: map[string]models.ConstantDetails{},
			models:    map[string]models.ModelDetails{},
		},
		resourceUrisToObjects: map[string]parsedResourceId{},
	}

	for _, operation := range d.swaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if !operationMatchesTag(operationDetails, tag) {
				continue
			}

			resourceId, err := d.parseResourceIdFromOperation(uri, operationDetails)
			if err != nil {
				return nil, fmt.Errorf("parsing %q: %+v", uri, err)
			}
			resourceUri := resourceId.NormalizedResourceId()
			result.resourceUrisToObjects[resourceUri] = *resourceId
			result.nestedResult.append(resourceId.nestedResult)
		}
	}

	return &result, nil
}

func (d *SwaggerDefinition) parseResourceIdFromOperation(uri string, operationDetails *spec.Operation) (*parsedResourceId, error) {
	// TODO: unit tests for this method too
	segments := make([]ResourceIdSegment, 0)
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	uriSegments := strings.Split(strings.TrimPrefix(uri, "/"), "/")
	for _, uriSegment := range uriSegments {
		normalizedSegment := cleanup.NormalizeSegment(uriSegment, true)
		normalizedSegment = strings.TrimSuffix(strings.TrimPrefix(normalizedSegment, "{"), "}")

		// intentionally check the pre-cut version
		if strings.HasPrefix(uriSegment, "{") && strings.HasSuffix(uriSegment, "}") {
			if strings.EqualFold(normalizedSegment, "scope") {
				segments = append(segments, ResourceIdSegment{
					Type:              ScopeSegment,
					Name:              normalizedSegment,
					ConstantReference: nil,
					FixedValue:        nil,
				})
				continue
			}

			for _, param := range operationDetails.Parameters {
				if strings.EqualFold(param.Name, normalizedSegment) && strings.EqualFold(param.In, "path") {
					if param.Ref.String() != "" {
						return nil, fmt.Errorf("TODO: Enum's aren't supported by Reference right now, but apparently should be for %q", uriSegment)
					}

					if param.Enum != nil {
						// then find the constant itself
						constant, err := mapConstant([]string{param.Type}, param.Enum, param.Extensions)
						if err != nil {
							return nil, fmt.Errorf("parsing constant from %q: %+v", uriSegment, err)
						}
						result.constants[constant.name] = constant.details
						segments = append(segments, ResourceIdSegment{
							Type:              ConstantSegment,
							Name:              normalizedSegment,
							ConstantReference: &constant.name,
							FixedValue:        nil,
						})
						continue
					}
				}
			}

			// TODO: Subscription & Resource Group Segments (of which there can be multiple within a URI)

			segments = append(segments, ResourceIdSegment{
				Type:              UserSpecifiedSegment,
				Name:              normalizedSegment,
				ConstantReference: nil,
				FixedValue:        nil,
			})
			continue
		}

		segments = append(segments, ResourceIdSegment{
			Type:              StaticSegment,
			Name:              normalizedSegment,
			ConstantReference: nil,
			FixedValue:        &normalizedSegment,
		})
	}

	// TODO: go through the ordered segments, if we have a repeated set of static strings (e.g. /restart or
	// /something/else/operation) that can become uriSuffix - which then wants removing from the segments

	output := parsedResourceId{
		nestedResult: result,
		segments:     segments,
		uriSuffix:    nil,
	}
	return &output, nil
}

func operationMatchesTag(operation *spec.Operation, tag *string) bool {
	// if there's no tags defined, we should capture it when the tag matched
	if tag == nil {
		return len(operation.Tags) == 0
	}

	for _, thisTag := range operation.Tags {
		if thisTag == *tag {
			return true
		}
	}

	return false
}
