package pipeline

import (
	"fmt"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) parseResourceIDsForService(logger hclog.Logger, apiVersion, service string, serviceTags []string, paths openapi3.Paths) (resources ResourceIds, err error) {
	resources = make(ResourceIds, 0)
	for path, item := range paths {
		operations := item.Operations()
		operationTags := make([]string, 0)

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tagMatches(service, operation.Tags) {
				operationTags = append(operationTags, operation.Tags...)
				skip = false
			}
		}
		if skip {
			continue
		}

		id := NewResourceId(path, operationTags)
		segmentsLastIndex := len(id.Segments) - 1

		lastSegment := id.Segments[segmentsLastIndex]
		if lastSegment.Type == SegmentODataReference {
			lastSegment = id.Segments[segmentsLastIndex-1]
			truncated := id.TruncateToLastSegmentOfTypeBeforeSegment([]ResourceIdSegmentType{}, segmentsLastIndex)
			if truncated == nil {
				err = fmt.Errorf("unable to truncate resource ID with OData Reference (service %q, version %q): %q", service, apiVersion, id.ID())
				return
			}
			id = *truncated
		}
		if lastSegment.Type != SegmentUserValue {
			continue
		}

		resourceIdName := ""
		if r, ok := id.FindResourceIdName(); ok {
			resourceIdName = singularize(cleanName(*r))
		}

		if resourceIdName != "" {
			logger.Info(fmt.Sprintf("found resource ID %q (service %q, version %q)", resourceIdName, service, apiVersion))

			id.Name = resourceIdName
			id.Service = cleanName(service)
			id.Version = apiVersion
			resources = append(resources, &id)
		}
	}

	return
}
