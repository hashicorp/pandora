// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdUserAssignedIdentity{}

type commonIdUserAssignedIdentity struct{}

func (commonIdUserAssignedIdentity) id() models.ParsedResourceId {
	name := "UserAssignedIdentity"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.ManagedIdentity"),
			models.StaticResourceIDSegment("userAssignedIdentities", "userAssignedIdentities"),
			models.UserSpecifiedResourceIDSegment("userAssignedIdentityName"),
		},
	}
}
