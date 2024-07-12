// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdKeyVaultPrivateEndpointConnection{}

type commonIdKeyVaultPrivateEndpointConnection struct{}

func (c commonIdKeyVaultPrivateEndpointConnection) ID() sdkModels.ResourceID {
	name := "KeyVaultPrivateEndpointConnection"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.KeyVault"),
			sdkModels.NewStaticValueResourceIDSegment("vaults", "vaults"),
			sdkModels.NewUserSpecifiedResourceIDSegment("vaultName", "vaultName"),
			sdkModels.NewStaticValueResourceIDSegment("privateEndpointConnections", "privateEndpointConnections"),
			sdkModels.NewUserSpecifiedResourceIDSegment("privateEndpointConnectionName", "privateEndpointConnectionName"),
		},
	}
}
