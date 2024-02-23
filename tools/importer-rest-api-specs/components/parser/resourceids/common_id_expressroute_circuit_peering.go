// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdExpressRouteCircuitPeering{}

type commonIdExpressRouteCircuitPeering struct{}

func (c commonIdExpressRouteCircuitPeering) id() importerModels.ParsedResourceId {
	name := "ExpressRouteCircuitPeering"
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
			models.NewStaticValueResourceIDSegment("expressRouteCircuits", "expressRouteCircuits"),
			models.NewUserSpecifiedResourceIDSegment("circuitName", "circuitName"),
			models.NewStaticValueResourceIDSegment("peerings", "peerings"),
			models.NewUserSpecifiedResourceIDSegment("peeringName", "peeringName"),
		},
	}
}
