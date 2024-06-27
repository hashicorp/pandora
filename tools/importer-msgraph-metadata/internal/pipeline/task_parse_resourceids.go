// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/normalize"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/tags"
)

func (p pipelineForService) parseResourceIDs() (resourceIds parser.ResourceIds, err error) {
	resourceIds = make(parser.ResourceIds, 0)
	for path, item := range p.spec.Paths {
		operations := item.Operations()
		operationTags := make([]string, 0)

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tags.Matches(p.service, operation.Tags) {
				operationTags = append(operationTags, operation.Tags...)
				skip = false
			}
		}
		if skip {
			continue
		}

		id := parser.NewResourceId(path, operationTags)
		segmentsLastIndex := len(id.Segments) - 1

		lastSegment := id.Segments[segmentsLastIndex]
		if lastSegment.Type == parser.SegmentODataReference {
			lastSegment = id.Segments[segmentsLastIndex-1]
			truncated := id.TruncateToLastSegmentOfTypeBeforeSegment([]parser.ResourceIdSegmentType{}, segmentsLastIndex)
			if truncated == nil {
				err = fmt.Errorf("unable to truncate resource ID with OData Reference (service %q, version %q): %q", p.service, p.apiVersion, id.ID())
				return
			}
			id = *truncated
		}
		if lastSegment.Type != parser.SegmentUserValue {
			continue
		}

		resourceIdName := ""
		if r, ok := id.FindResourceIdName(); ok {
			resourceIdName = normalize.Singularize(normalize.CleanName(*r))
		}

		if resourceIdName != "" {
			p.logger.Info(fmt.Sprintf("Found resource ID %q (service %q, version %q)", resourceIdName, p.service, p.apiVersion))

			id.Name = resourceIdName
			id.Service = normalize.CleanName(p.service)
			id.Version = p.apiVersion
			resourceIds = append(resourceIds, &id)
		}
	}

	return
}
