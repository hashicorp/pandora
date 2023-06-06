package pipeline

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateResourceIdsForService(files *Tree, serviceName string, resourceIds ResourceIds, logger hclog.Logger) error {
	ids := make(map[string]string)

	for _, resourceId := range resourceIds {
		clientMethodFile := fmt.Sprintf("%s/%s/ResourceId-%s.cs", resourceId.Service, cleanVersion(resourceId.Version), resourceId.Name)
		ids[clientMethodFile] = templateResourceId(resourceId)
	}

	resourceIdFiles := sortedKeys(ids)
	for _, resourceIdFile := range resourceIdFiles {
		if err := files.addFile(resourceIdFile, ids[resourceIdFile]); err != nil {
			return err
		}
	}

	return nil
}

func templateResourceId(resourceId *ResourceId) string {
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

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s;

internal class %[3]s : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "%[4]s";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
%[5]s
    };
}
`, resourceId.Service, cleanVersion(resourceId.Version), resourceId.Name, resourceId.ID(), segmentsCode)
}
