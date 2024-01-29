// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdKeyVaultKeyVersion{}

type commonIdKeyVaultKeyVersion struct{}

func (c commonIdKeyVaultKeyVersion) id() models.ParsedResourceId {
	name := "KeyVaultKeyVersion"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.KeyVault"),
			models.StaticResourceIDSegment("vaults", "vaults"),
			models.UserSpecifiedResourceIDSegment("vaultName"),
			models.StaticResourceIDSegment("keys", "keys"),
			models.UserSpecifiedResourceIDSegment("keyName"),
			models.StaticResourceIDSegment("versions", "versions"),
			models.UserSpecifiedResourceIDSegment("versionName"),
		},
	}
}
