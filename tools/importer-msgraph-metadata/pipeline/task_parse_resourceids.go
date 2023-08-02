package pipeline

import (
	"fmt"
)

func (p pipelineTask) parseResourceIDsForService() (resourceIds ResourceIds, err error) {
	resourceIds = make(ResourceIds, 0)
	for path, item := range p.spec.Paths {
		operations := item.Operations()
		operationTags := make([]string, 0)

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tagMatches(p.service, operation.Tags) {
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
				err = fmt.Errorf("unable to truncate resource ID with OData Reference (service %q, version %q): %q", p.service, p.apiVersion, id.ID())
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
			p.logger.Info(fmt.Sprintf("found resource ID %q (service %q, version %q)", resourceIdName, p.service, p.apiVersion))

			id.Name = resourceIdName
			id.Service = cleanName(p.service)
			id.Version = p.apiVersion
			resourceIds = append(resourceIds, &id)
		}
	}

	return
}
