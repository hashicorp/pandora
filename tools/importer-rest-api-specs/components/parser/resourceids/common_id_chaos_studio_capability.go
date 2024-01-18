package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdChaosStudioCapability{}

type commonIdChaosStudioCapability struct{}

func (commonIdChaosStudioCapability) id() models.ParsedResourceId {
	name := "ChaosStudioCapability"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.ScopeResourceIDSegment("scope"),
			models.StaticResourceIDSegment("staticProviders", "providers"),
			models.ResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			models.StaticResourceIDSegment("staticTargets", "targets"),
			models.UserSpecifiedResourceIDSegment("targetName"),
			models.StaticResourceIDSegment("staticCapabilities", "capabilities"),
			models.UserSpecifiedResourceIDSegment("capabilityName"),
		},
	}
}
