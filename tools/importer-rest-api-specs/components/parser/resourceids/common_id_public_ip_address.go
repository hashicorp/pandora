package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdPublicIPAddress{}

type commonIdPublicIPAddress struct{}

func (c commonIdPublicIPAddress) id() models.ParsedResourceId {
	name := "PublicIPAddress"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			models.StaticResourceIDSegment("publicIPAddresses", "publicIPAddresses"),
			models.UserSpecifiedResourceIDSegment("publicIPAddressesName"),
		},
	}
}
