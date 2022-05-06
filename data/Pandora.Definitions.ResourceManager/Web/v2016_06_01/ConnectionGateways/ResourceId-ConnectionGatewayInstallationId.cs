using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ConnectionGateways;

internal class ConnectionGatewayInstallationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.Web/locations/{location}/connectionGatewayInstallations/{gatewayId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
                new()
                {
                    Name = "staticSubscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "subscriptions"
                },

                new()
                {
                    Name = "subscriptionId",
                    Type = ResourceIDSegmentType.SubscriptionId
                },

                new()
                {
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftWeb",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Web"
                },

                new()
                {
                    Name = "staticLocations",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "locations"
                },

                new()
                {
                    Name = "location",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticConnectionGatewayInstallations",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "connectionGatewayInstallations"
                },

                new()
                {
                    Name = "gatewayId",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
