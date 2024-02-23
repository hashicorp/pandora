// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type ParsedResourceId struct {
	// TODO: this type wants consolidating

	// CommonAlias is the alias used for this Resource ID, if this is a 'Common' Resource ID
	// examples of a Common Resource ID include Resource Group ID's and Subscription ID's
	CommonAlias *string

	// Constants are a map[Name]ConstantDetails for the Constants used in this Resource ID
	Constants map[string]models.SDKConstant

	// Segments are an ordered list of segments which comprise this Resource ID
	Segments []models.ResourceIDSegment
}

func (pri ParsedResourceId) ID() string {
	components := make([]string, 0)
	for _, segment := range pri.Segments {
		if segment.FixedValue != nil {
			components = append(components, *segment.FixedValue)
			continue
		}

		components = append(components, fmt.Sprintf("{%s}", segment.Name))
	}

	return fmt.Sprintf("/%s", strings.Join(components, "/"))
}

func (pri ParsedResourceId) Matches(other ParsedResourceId) bool {
	if len(pri.Segments) != len(other.Segments) {
		return false
	}

	for i, first := range pri.Segments {
		second := other.Segments[i]
		if first.Type != second.Type {
			return false
		}

		// Whilst these should match, it's possible that they don't but are the same e.g.
		// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{resourceName}
		// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}
		// as such providing they're both user specified segments (and the rest is the same) then they're the same
		if first.Type == models.ResourceGroupResourceIDSegmentType || first.Type == models.SubscriptionIDResourceIDSegmentType || first.Type == models.UserSpecifiedResourceIDSegmentType {
			continue
		}

		// With a Scope the key doesn't matter as much as that it's a Scope, so presuming the types match (above) we're good.
		if first.Type == models.ScopeResourceIDSegmentType {
			continue
		}

		if first.Type == models.ConstantResourceIDSegmentType {
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

		if first.Type == models.ResourceProviderResourceIDSegmentType || first.Type == models.StaticResourceIDSegmentType {
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

func (pri ParsedResourceId) String() string {
	// only used for debug purposes
	return pri.ID()
}
