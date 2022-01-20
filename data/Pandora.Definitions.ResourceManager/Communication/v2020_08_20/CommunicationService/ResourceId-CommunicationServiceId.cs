using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService;

internal class CommunicationServiceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Communication/communicationServices/{communicationServiceName}";

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
                    Name = "staticMicrosoftCommunication",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Communication"
                },

                new()
                {
                    Name = "staticCommunicationServices",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "communicationServices"
                },

                new()
                {
                    Name = "communicationServiceName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
