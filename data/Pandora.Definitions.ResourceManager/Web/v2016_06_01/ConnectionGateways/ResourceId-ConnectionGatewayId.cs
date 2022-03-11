using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ConnectionGateways;

internal class ConnectionGatewayId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/connectionGateways/{connectionGatewayName}";

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
                    Name = "staticResourceGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "resourceGroups"
                },

                new()
                {
                    Name = "resourceGroupName",
                    Type = ResourceIDSegmentType.ResourceGroup
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
                    Name = "staticConnectionGateways",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "connectionGateways"
                },

                new()
                {
                    Name = "connectionGatewayName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
