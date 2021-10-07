using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{
    internal class AuthorizationId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/authorizations/{authorizationName}";

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
                    Name = "microsoftAVS",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.AVS"
                },

                new()
                {
                    Name = "privateClouds",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "privateClouds"
                },

                new()
                {
                    Name = "privateCloudName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "authorizations",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "authorizations"
                },

                new()
                {
                    Name = "authorizationName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
