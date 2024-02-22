// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdVPNConnection{}

type commonIdVPNConnection struct{}

func (c commonIdVPNConnection) id() importerModels.ParsedResourceId {
	name := "VPNConnection"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			models.NewStaticValueResourceIDSegment("vpnGateways", "vpnGateways"),
			models.NewUserSpecifiedResourceIDSegment("gatewayName", "gatewayName"),
			models.NewStaticValueResourceIDSegment("vpnConnections", "vpnConnections"),
			models.NewUserSpecifiedResourceIDSegment("connectionName", "connectionName"),
		},
	}
}
