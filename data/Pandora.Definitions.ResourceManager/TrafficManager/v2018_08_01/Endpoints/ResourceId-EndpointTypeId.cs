using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Endpoints;

internal class EndpointTypeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}/{endpointType}/{endpointName}";

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
                    Name = "staticMicrosoftNetwork",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Network"
                },

                new()
                {
                    Name = "staticTrafficManagerProfiles",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "trafficManagerProfiles"
                },

                new()
                {
                    Name = "profileName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "endpointType",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(EndpointTypeConstant)
                },

                new()
                {
                    Name = "endpointName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
