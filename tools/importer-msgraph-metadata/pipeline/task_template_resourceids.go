// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"path"
	"strings"
)

func (p pipelineTask) templateResourceIdsForService(resources Resources) error {
	ids := make(map[string]string)

	for _, resource := range resources {
		if resource.Category == "" {
			continue
		}

		for _, operation := range resource.Operations {
			if operation.ResourceId == nil {
				continue
			}
			filename := path.Join(fmt.Sprintf("Pandora.Definitions.%s", definitionsDirectory(operation.ResourceId.Version)), operation.ResourceId.Service, cleanVersion(operation.ResourceId.Version), resource.Category, fmt.Sprintf("ResourceId-%s.cs", operation.ResourceId.Name))
			ids[filename] = templateResourceId(operation.ResourceId, resource.Category)
		}
	}

	resourceIdFiles := sortedKeys(ids)
	for _, resourceIdFile := range resourceIdFiles {
		if err := p.files.addFile(resourceIdFile, ids[resourceIdFile]); err != nil {
			return err
		}
	}

	return nil
}

func templateResourceId(resourceId *ResourceId, category string) string {
	segments := make([]string, 0)
	for _, seg := range resourceId.Segments {
		switch seg.Type {
		case SegmentUserValue:
			segments = append(segments, fmt.Sprintf(`ResourceIDSegment.UserSpecified("%s")`, cleanNameCamel(seg.Value)))
		default:
			segments = append(segments, fmt.Sprintf(`ResourceIDSegment.Static("static%s", "%s")`, cleanName(seg.Value), seg.Value))
		}
	}
	segmentsCode := indentSpace(strings.Join(segments, ",\n"), 8)

	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s.%[4]s;

internal class %[5]s : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "%[6]s";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
%[7]s
    };
}
`, resourceId.Service, definitionsDirectory(resourceId.Version), cleanVersion(resourceId.Version), category, resourceId.Name, resourceId.ID(), segmentsCode)
}
