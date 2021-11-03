using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.PrivateEndpointConnections
{
    internal class PrivateEndpointConnectionId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}";

        public List<ResourceIDSegment> Segments()
        {
            return new List<ResourceIDSegment>
            {
                new()
                {
                    Name = "subscriptions",
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
                    Name = "resourceGroups",
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
                    Name = "providers",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "microsoftCognitiveServices",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.CognitiveServices"
                },

                new()
                {
                    Name = "accounts",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "accounts"
                },

                new()
                {
                    Name = "accountName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "privateEndpointConnections",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "privateEndpointConnections"
                },

                new()
                {
                    Name = "privateEndpointConnectionName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
