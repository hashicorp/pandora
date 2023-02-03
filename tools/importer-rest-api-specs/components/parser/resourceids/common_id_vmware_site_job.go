package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdVMwareSiteJob{}

type commonIdVMwareSiteJob struct {
}

func (c commonIdVMwareSiteJob) id() models.ParsedResourceId {
	name := "VMwareSiteJob"
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
			models.StaticResourceIDSegment("vmwareSites", "vmwareSites"),
			models.UserSpecifiedResourceIDSegment("vmwareSiteName"),
			models.StaticResourceIDSegment("jobs", "jobs"),
			models.UserSpecifiedResourceIDSegment("jobName"),
		},
	}
}
