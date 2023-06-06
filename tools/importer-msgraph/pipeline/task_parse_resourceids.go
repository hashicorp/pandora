package pipeline

import "github.com/getkin/kin-openapi/openapi3"

func (pipelineTask) parseResourceIDsForService(apiVersion, service string, serviceTags []string, paths openapi3.Paths) (resources ResourceIds) {
	resources = make(ResourceIds, 0)
	for path, item := range paths {
		operations := item.Operations()
		operationTags := make([]string, 0)

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tagMatches(service, serviceTags, operation.Tags) {
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
			resourceName := ""
			if r, ok := id.FindResourceIdName(); ok {
				resourceName = singularize(cleanName(*r))
			}
			id.Name = resourceName
			id.Service = cleanName(service)
			id.Version = apiVersion
			resources = append(resources, &id)
		}
	}

	return
}
