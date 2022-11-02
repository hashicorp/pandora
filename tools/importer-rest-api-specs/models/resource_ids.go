package models

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ParsedResourceId struct {
	// CommonAlias is the alias used for this Resource ID, if this is a 'Common' Resource ID
	// examples of a Common Resource ID include Resource Group ID's and Subscription ID's
	CommonAlias *string

	// Constants are a map[Name]ConstantDetails for the Constants used in this Resource ID
	Constants map[string]resourcemanager.ConstantDetails

	// Segments are an ordered list of segments which comprise this Resource ID
	Segments []resourcemanager.ResourceIdSegment
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
		if first.Type == resourcemanager.ResourceGroupSegment || first.Type == resourcemanager.SubscriptionIdSegment || first.Type == resourcemanager.UserSpecifiedSegment {
			continue
		}

		// With a Scope the key doesn't matter as much as that it's a Scope, so presuming the types match (above) we're good.
		if first.Type == resourcemanager.ScopeSegment {
			continue
		}

		if first.Type == resourcemanager.ConstantSegment {
			if first.ConstantReference != nil && second.ConstantReference == nil {
				return false
			}
			if first.ConstantReference == nil && second.ConstantReference != nil {
				return false
			}
			if first.ConstantReference != nil && second.ConstantReference != nil && *first.ConstantReference != *second.ConstantReference {
				return false
			}

			continue
		}

		if first.Type == resourcemanager.ResourceProviderSegment || first.Type == resourcemanager.StaticSegment {
			if first.FixedValue != nil && second.FixedValue == nil {
				return false
			}
			if first.FixedValue == nil && second.FixedValue != nil {
				return false
			}
			if first.FixedValue != nil && second.FixedValue != nil && !strings.EqualFold(*first.FixedValue, *second.FixedValue) {
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

func ConstantResourceIDSegment(name, constantName string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		Type:              resourcemanager.ConstantSegment,
		Name:              name,
		ConstantReference: &constantName,
	}
}

func ResourceProviderResourceIDSegment(name, resourceProvider string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		Type:       resourcemanager.ResourceProviderSegment,
		Name:       name,
		FixedValue: &resourceProvider,
	}
}

func ResourceGroupResourceIDSegment(name string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		Type: resourcemanager.ResourceGroupSegment,
		Name: name,
	}
}

func StaticResourceIDSegment(name, fixedValue string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		Type:       resourcemanager.StaticSegment,
		Name:       name,
		FixedValue: &fixedValue,
	}
}

func ScopeResourceIDSegment(name string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		Name: name,
		Type: resourcemanager.ScopeSegment,
	}
}

func SubscriptionIDResourceIDSegment(name string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		Type: resourcemanager.SubscriptionIdSegment,
		Name: name,
	}
}

func UserSpecifiedResourceIDSegment(name string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		Type: resourcemanager.UserSpecifiedSegment,
		Name: name,
	}
}
