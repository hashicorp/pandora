// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVPNConnection{}

type commonIdVPNConnection struct{}

func (c commonIdVPNConnection) ID() sdkModels.ResourceID {
	name := "VPNConnection"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			sdkModels.NewStaticValueResourceIDSegment("vpnGateways", "vpnGateways"),
			sdkModels.NewUserSpecifiedResourceIDSegment("gatewayName", "gatewayName"),
			sdkModels.NewStaticValueResourceIDSegment("vpnConnections", "vpnConnections"),
			sdkModels.NewUserSpecifiedResourceIDSegment("connectionName", "connectionName"),
		},
	}
}
