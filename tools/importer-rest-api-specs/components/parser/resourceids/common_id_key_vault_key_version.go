// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdKeyVaultKeyVersion{}

type commonIdKeyVaultKeyVersion struct{}

func (c commonIdKeyVaultKeyVersion) id() importerModels.ParsedResourceId {
	name := "KeyVaultKeyVersion"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
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
			models.NewStaticValueResourceIDSegment("versions", "versions"),
			models.NewUserSpecifiedResourceIDSegment("versionName", "versionName"),
		},
	}
}
