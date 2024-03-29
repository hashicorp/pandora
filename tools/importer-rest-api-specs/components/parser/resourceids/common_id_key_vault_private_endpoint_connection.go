// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdKeyVaultPrivateEndpointConnection{}

type commonIdKeyVaultPrivateEndpointConnection struct{}

func (c commonIdKeyVaultPrivateEndpointConnection) id() models.ResourceID {
	name := "KeyVaultPrivateEndpointConnection"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.KeyVault"),
			models.NewStaticValueResourceIDSegment("vaults", "vaults"),
			models.NewUserSpecifiedResourceIDSegment("vaultName", "vaultName"),
			models.NewStaticValueResourceIDSegment("privateEndpointConnections", "privateEndpointConnections"),
			models.NewUserSpecifiedResourceIDSegment("privateEndpointConnectionName", "privateEndpointConnectionName"),
		},
	}
}
