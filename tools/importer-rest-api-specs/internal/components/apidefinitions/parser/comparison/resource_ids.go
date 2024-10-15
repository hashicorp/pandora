// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package comparison

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func ResourceIDsMatch(first, second sdkModels.ResourceID) bool {
	if len(first.Segments) != len(second.Segments) {
		return false
	}

	for i, firstSegment := range first.Segments {
		secondSegment := second.Segments[i]
		if firstSegment.Type != secondSegment.Type {
			return false
		}

		// Whilst these should match, it's possible that they don't but are the same e.g.
		// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{resourceName}
		// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}
		// as such providing they're both user specified segments (and the rest is the same) then they're the same
		if firstSegment.Type == sdkModels.ResourceGroupResourceIDSegmentType || firstSegment.Type == sdkModels.SubscriptionIDResourceIDSegmentType || firstSegment.Type == sdkModels.UserSpecifiedResourceIDSegmentType {
			continue
		}

		// With a Scope the key doesn't matter as much as that it's a Scope, so presuming the types match (above) we're good.
		if firstSegment.Type == sdkModels.ScopeResourceIDSegmentType {
			continue
		}

		if firstSegment.Type == sdkModels.ConstantResourceIDSegmentType {
			if firstSegment.ConstantReference != nil && secondSegment.ConstantReference == nil {
				return false
			}
			if firstSegment.ConstantReference == nil && secondSegment.ConstantReference != nil {
				return false
			}

			// We're intentionally not checking the constants involved, since both the name and values could differ
			// between different operations due to data issues - however when either happens we'd end up using a
			// Common ID to resolve this - therefore presuming the rest of the Resource ID matches we should be good.

			continue
		}

		if firstSegment.Type == sdkModels.ResourceProviderResourceIDSegmentType || firstSegment.Type == sdkModels.StaticResourceIDSegmentType {
			if firstSegment.FixedValue != nil && secondSegment.FixedValue == nil {
				return false
			}
			if firstSegment.FixedValue == nil && secondSegment.FixedValue != nil {
				return false
			}
			if firstSegment.FixedValue != nil && secondSegment.FixedValue != nil && *firstSegment.FixedValue != *secondSegment.FixedValue {
				return false
			}

			continue
		}

		if !strings.EqualFold(firstSegment.Name, secondSegment.Name) {
			return false
		}
	}

	return true
}
