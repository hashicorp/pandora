package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdHyperVSiteJob{}

type commonIdHyperVSiteJob struct{}

func (c commonIdHyperVSiteJob) id() models.ParsedResourceId {
	name := "HyperVSiteJob"
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
			models.StaticResourceIDSegment("jobs", "jobs"),
			models.UserSpecifiedResourceIDSegment("jobName"),
		},
	}
}
