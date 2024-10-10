// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdKeyVaultKeyVersion{}

type commonIdKeyVaultKeyVersion struct{}

func (c commonIdKeyVaultKeyVersion) ID() sdkModels.ResourceID {
	name := "KeyVaultKeyVersion"
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
			sdkModels.NewStaticValueResourceIDSegment("keys", "keys"),
			sdkModels.NewUserSpecifiedResourceIDSegment("keyName", "keyName"),
			sdkModels.NewStaticValueResourceIDSegment("versions", "versions"),
			sdkModels.NewUserSpecifiedResourceIDSegment("versionName", "versionName"),
		},
	}
}
