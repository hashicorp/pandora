// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdNetworkInterfaceIPConfiguration{}

type commonIdNetworkInterfaceIPConfiguration struct{}

func (c commonIdNetworkInterfaceIPConfiguration) id() models.ResourceID {
	name := "NetworkInterfaceIPConfiguration"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			models.NewStaticValueResourceIDSegment("networkInterfaces", "networkInterfaces"),
			models.NewUserSpecifiedResourceIDSegment("networkInterfaceName", "networkInterfaceName"),
			models.NewStaticValueResourceIDSegment("ipConfigurations", "ipConfigurations"),
			models.NewUserSpecifiedResourceIDSegment("ipConfigurationName", "ipConfigurationName"),
		},
	}
}
