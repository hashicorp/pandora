// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdKeyVaultKey{}

type commonIdKeyVaultKey struct{}

func (c commonIdKeyVaultKey) id() models.ResourceID {
	name := "KeyVaultKey"
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
			models.NewStaticValueResourceIDSegment("keys", "keys"),
			models.NewUserSpecifiedResourceIDSegment("keyName", "keyName"),
		},
	}
}
