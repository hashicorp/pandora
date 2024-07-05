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

func ResourceIdsMatch(first, second sdkModels.ResourceID) bool {
	if len(first.Segments) != len(second.Segments) {
		return false
	}

	for i, first := range first.Segments {
		second := second.Segments[i]
		if first.Type != second.Type {
			return false
		}

		// Whilst these should match, it's possible that they don't but are the same e.g.
		// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{resourceName}
		// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}
		// as such providing they're both user specified segments (and the rest is the same) then they're the same
		if first.Type == sdkModels.ResourceGroupResourceIDSegmentType || first.Type == sdkModels.SubscriptionIDResourceIDSegmentType || first.Type == sdkModels.UserSpecifiedResourceIDSegmentType {
			continue
		}

		// With a Scope the key doesn't matter as much as that it's a Scope, so presuming the types match (above) we're good.
		if first.Type == sdkModels.ScopeResourceIDSegmentType {
			continue
		}

		if first.Type == sdkModels.ConstantResourceIDSegmentType {
			if first.ConstantReference != nil && second.ConstantReference == nil {
				return false
			}
			if first.ConstantReference == nil && second.ConstantReference != nil {
				return false
			}

			// We're intentionally not checking the constants involved, since both the name and values could differ
			// between different operations due to data issues - however when either happens we'd end up using a
			// Common ID to resolve this - therefore presuming the rest of the Resource ID matches we should be good.

			continue
		}

		if first.Type == sdkModels.ResourceProviderResourceIDSegmentType || first.Type == sdkModels.StaticResourceIDSegmentType {
			if first.FixedValue != nil && second.FixedValue == nil {
				return false
			}
			if first.FixedValue == nil && second.FixedValue != nil {
				return false
			}
			if first.FixedValue != nil && second.FixedValue != nil && *first.FixedValue != *second.FixedValue {
				return false
			}

			continue
		}

		if !strings.EqualFold(first.Name, second.Name) {
			return false
		}
	}

	return true
}
