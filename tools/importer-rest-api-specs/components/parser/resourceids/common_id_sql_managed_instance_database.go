package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdSqlManagedInstanceDatabase{}

type commonIdSqlManagedInstanceDatabase struct{}

func (c commonIdSqlManagedInstanceDatabase) id() models.ParsedResourceId {
	name := "SqlManagedInstanceDatabase"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Sql"),
			models.StaticResourceIDSegment("managedInstances", "managedInstances"),
			models.UserSpecifiedResourceIDSegment("managedInstanceName"),
			models.StaticResourceIDSegment("databases", "databases"),
			models.UserSpecifiedResourceIDSegment("databaseName"),
		},
	}
}
