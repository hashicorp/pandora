// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdCloudServicesPublicIPAddress{}

type commonIdCloudServicesPublicIPAddress struct{}

func (c commonIdCloudServicesPublicIPAddress) id() importerModels.ParsedResourceId {
	name := "CloudServicesPublicIPAddress"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("subscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Compute"),
			importerModels.StaticResourceIDSegment("cloudServices", "cloudServices"),
			importerModels.UserSpecifiedResourceIDSegment("cloudServiceName"),
			importerModels.StaticResourceIDSegment("roleInstances", "roleInstances"),
			importerModels.UserSpecifiedResourceIDSegment("roleInstanceName"),
			importerModels.StaticResourceIDSegment("networkInterfaces", "networkInterfaces"),
			importerModels.UserSpecifiedResourceIDSegment("networkInterfaceName"),
			importerModels.StaticResourceIDSegment("ipConfigurations", "ipConfigurations"),
			importerModels.UserSpecifiedResourceIDSegment("ipConfigurationName"),
			importerModels.StaticResourceIDSegment("publicIPAddresses", "publicIPAddresses"),
			importerModels.UserSpecifiedResourceIDSegment("publicIPAddressName"),
		},
	}

}
