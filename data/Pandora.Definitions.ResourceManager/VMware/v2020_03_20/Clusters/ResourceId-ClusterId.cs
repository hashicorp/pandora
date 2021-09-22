using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Clusters
{
    internal class ClusterId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/clusters/{clusterName}";

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
                    Type = ResourceIDSegmentType.Static,
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
                    Name = "clusters",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "clusters"
                },

                new()
                {
                    Name = "clusterName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
