package pipeline

import (
	"fmt"
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) parseResourceIDsForService(logger hclog.Logger, apiVersion, service string, serviceTags []string, paths openapi3.Paths) (resources ResourceIds) {
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
		if lastSegment := id.Segments[segmentsLastIndex]; lastSegment.Type == SegmentUserValue {
			resourceIdName := ""
			if r, ok := id.FindResourceIdName(); ok {
				resourceIdName = singularize(cleanName(*r))
			}

			if resourceIdName != "" {
				logger.Info(fmt.Sprintf("found resource ID %q for service %q in API version %q", resourceIdName, service, apiVersion))

				id.Name = resourceIdName
				id.Service = cleanName(service)
				id.Version = apiVersion
				resources = append(resources, &id)
			}
		}
	}

	return
}
