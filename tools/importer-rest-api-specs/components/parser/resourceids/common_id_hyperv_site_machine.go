package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdHyperVSiteMachine{}

type commonIdHyperVSiteMachine struct{}

func (c commonIdHyperVSiteMachine) id() models.ParsedResourceId {
	name := "HyperVSiteMachine"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.OffAzure"),
			models.StaticResourceIDSegment("hyperVSites", "hyperVSites"),
			models.UserSpecifiedResourceIDSegment("hyperVSiteName"),
			models.StaticResourceIDSegment("machines", "machines"),
			models.UserSpecifiedResourceIDSegment("machineName"),
		},
	}
}
