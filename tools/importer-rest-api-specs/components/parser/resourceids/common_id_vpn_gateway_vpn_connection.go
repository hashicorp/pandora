// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdVPNConnection{}

type commonIdVPNConnection struct{}

func (c commonIdVPNConnection) id() importerModels.ParsedResourceId {
	name := "VPNConnection"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("subscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			importerModels.StaticResourceIDSegment("vpnGateways", "vpnGateways"),
			importerModels.UserSpecifiedResourceIDSegment("gatewayName"),
			importerModels.StaticResourceIDSegment("vpnConnections", "vpnConnections"),
			importerModels.UserSpecifiedResourceIDSegment("connectionName"),
		},
	}
}
