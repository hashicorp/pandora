package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdAutomationCompilationJob{}

type commonIdAutomationCompilationJob struct{}

func (c commonIdAutomationCompilationJob) id() models.ParsedResourceId {
	name := "AutomationCompilationJob"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Automation"),
			models.StaticResourceIDSegment("automationAccounts", "automationAccounts"),
			models.UserSpecifiedResourceIDSegment("automationAccountName"),
			models.StaticResourceIDSegment("compilationJobs", "compilationJobs"),
			models.UserSpecifiedResourceIDSegment("compilationJobId"),
		},
	}
}
