// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdKeyVaultPrivateEndpointConnection{}

type commonIdKeyVaultPrivateEndpointConnection struct{}

func (c commonIdKeyVaultPrivateEndpointConnection) id() importerModels.ParsedResourceId {
	name := "KeyVaultPrivateEndpointConnection"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("subscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.KeyVault"),
			importerModels.StaticResourceIDSegment("vaults", "vaults"),
			importerModels.UserSpecifiedResourceIDSegment("vaultName"),
			importerModels.StaticResourceIDSegment("privateEndpointConnections", "privateEndpointConnections"),
			importerModels.UserSpecifiedResourceIDSegment("privateEndpointConnectionName"),
		},
	}
}
