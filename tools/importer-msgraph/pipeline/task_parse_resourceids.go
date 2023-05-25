package pipeline

import "github.com/getkin/kin-openapi/openapi3"

func (pipelineTask) parseResourceIDsForService(service string, serviceTags []string, paths openapi3.Paths) (resources map[string]*ResourceId) {
	resources = make(map[string]*ResourceId)
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

		resourceName := ""
		if r := id.FindResource(); r != nil {
			resourceName = singularize(cleanName(r.Value))
		}

		segmentsLastIndex := len(id.Segments) - 1
		if lastSegment := id.Segments[segmentsLastIndex]; lastSegment.Type == SegmentUserValue {
			resources[resourceName] = &id
		}
	}

	return
}
