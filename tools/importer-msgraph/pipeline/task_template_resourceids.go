package pipeline

import (
	"fmt"
	"os"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateResourceIdsForService(files *Tree, serviceName string, resources Resources, logger hclog.Logger) error {
	ids := make(map[string]string)

	for _, resource := range resources {
		if resource.Id == nil {
			continue
		}
		filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]s%[5]s%[1]sResourceId-%[6]s.cs", string(os.PathSeparator), versionDirectory(resource.Id.Version), resource.Id.Service, cleanName(resource.Id.Version), resource.Category, resource.Id.Name)
		ids[filename] = templateResourceId(resource.Id, resource.Category)
	}

	resourceIdFiles := sortedKeys(ids)
	for _, resourceIdFile := range resourceIdFiles {
		if err := files.addFile(resourceIdFile, ids[resourceIdFile]); err != nil {
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

	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s.%[4]s;

internal class %[5]sId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "%[6]s";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
%[7]s
    };
}
`, resourceId.Service, versionDirectory(resourceId.Version), cleanName(resourceId.Version), category, resourceId.Name, resourceId.ID(), segmentsCode)
}
