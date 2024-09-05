// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var _ dataWorkaround = workaroundRepeatingResourceIdSegments{}

// workaroundRepeatingResourceIdSegments removes incompatible resource IDs due to repeating segments which are not supported at this time.
type workaroundRepeatingResourceIdSegments struct{}

func (workaroundRepeatingResourceIdSegments) Name() string {
	return "Resource IDs with repeating segments / remove incompatible resource IDs"
}

func (workaroundRepeatingResourceIdSegments) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	for resourceIdName := range resourceIds {
		var invalid bool
		resourceId := *resourceIds[resourceIdName]

		seenSegmentNames := map[string]struct{}{}
		for _, segment := range resourceId.Segments {
			if _, ok := seenSegmentNames[segment.Value]; ok {
				logging.Warnf("Dropping resource ID due to duplicate segment %q: %s", resourceIdName, segment.Value)
				invalid = true
				break
			}
			seenSegmentNames[segment.Value] = struct{}{}
		}

		if invalid {
			delete(resourceIds, resourceIdName)
		}
	}

	return nil
}
