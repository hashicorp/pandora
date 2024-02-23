// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdKeyVaultKeyVersion{}

type commonIdKeyVaultKeyVersion struct{}

func (c commonIdKeyVaultKeyVersion) id() importerModels.ParsedResourceId {
	name := "KeyVaultKeyVersion"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("subscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.KeyVault"),
			importerModels.StaticResourceIDSegment("vaults", "vaults"),
			importerModels.UserSpecifiedResourceIDSegment("vaultName"),
			importerModels.StaticResourceIDSegment("keys", "keys"),
			importerModels.UserSpecifiedResourceIDSegment("keyName"),
			importerModels.StaticResourceIDSegment("versions", "versions"),
			importerModels.UserSpecifiedResourceIDSegment("versionName"),
		},
	}
}
