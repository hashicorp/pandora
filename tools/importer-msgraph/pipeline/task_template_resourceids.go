package pipeline

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateResourceIdsForService(files *Tree, serviceName string, resources map[string]*Resource, logger hclog.Logger) error {
	resourceIds := make(map[string]string)

	for _, resource := range resources {
		for _, operation := range resource.Operations {
			if operation.ID == nil || !operation.ID.HasUserValue() { //segmentsLastIndex := len(resource.ID.Segments) - 1; resource.ID.Segments[segmentsLastIndex].Type == SegmentUserValue {
				continue
			}
			if lastSegment := operation.ID.Segments[len(operation.ID.Segments)-1]; lastSegment.Value == "$ref" {
				continue
			}
			clientMethodFile := fmt.Sprintf("%s/%s/ResourceId-%s.cs", resource.Service, cleanVersion(resource.Version), fmt.Sprintf("%sId", resource.Name))
			resourceIds[clientMethodFile] = templateResourceId(resource, operation.ID)
		}
	}

	resourceIdFiles := sortedKeys(resourceIds)
	for _, resourceIdFile := range resourceIdFiles {
		if err := files.addFile(resourceIdFile, resourceIds[resourceIdFile]); err != nil {
			return err
		}
	}

	return nil
}

func templateResourceId(resource *Resource, resourceId *ResourceId) string {
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

internal class %[3]sId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "%[4]s";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
%[5]s
    };
}
`, resource.Service, cleanVersion(resource.Version), resource.Name, resourceId.ID(), segmentsCode)
}
