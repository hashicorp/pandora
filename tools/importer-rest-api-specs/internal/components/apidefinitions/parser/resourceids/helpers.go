// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
)

func normalizedResourceManagerResourceId(pri sdkModels.ResourceID) string {
	segments := segmentsWithoutUriSuffix(pri)
	return normalizedResourceId(segments)
}

func segmentsWithoutUriSuffix(pri sdkModels.ResourceID) []sdkModels.ResourceIDSegment {
	segments := pri.Segments
	lastUserValueSegment := -1
	for i, segment := range segments {
		// everything else technically is a user configurable component
		if segment.Type != sdkModels.StaticResourceIDSegmentType && segment.Type != sdkModels.ResourceProviderResourceIDSegmentType {
			lastUserValueSegment = i
		}
	}
	if lastUserValueSegment >= 0 && len(segments) > lastUserValueSegment+1 {
		// remove any URI Suffix since this isn't relevant for the ID's
		segments = segments[0 : lastUserValueSegment+1]
	}
	return segments
}

func normalizedResourceId(segments []sdkModels.ResourceIDSegment) string {
	components := make([]string, 0)
	for _, segment := range segments {
		switch segment.Type {
		case sdkModels.ResourceProviderResourceIDSegmentType:
			{
				normalizedSegment := cleanup.NormalizeResourceProviderName(*segment.FixedValue)
				components = append(components, normalizedSegment)
				continue
			}

		case sdkModels.StaticResourceIDSegmentType:
			{
				normalizedSegment := cleanup.NormalizeSegment(*segment.FixedValue, true)
				components = append(components, normalizedSegment)
				continue
			}

		case sdkModels.ConstantResourceIDSegmentType, sdkModels.ResourceGroupResourceIDSegmentType, sdkModels.ScopeResourceIDSegmentType, sdkModels.SubscriptionIDResourceIDSegmentType, sdkModels.UserSpecifiedResourceIDSegmentType:
			// e.g. {example}
			normalizedSegment := segment.Name
			normalizedSegment = cleanup.NormalizeReservedKeywords(segment.Name)
			components = append(components, fmt.Sprintf("{%s}", normalizedSegment))
			continue

		default:
			panic(fmt.Sprintf("unimplemented segment type %q", string(segment.Type)))
		}
	}

	return fmt.Sprintf("/%s", strings.Join(components, "/"))
}
