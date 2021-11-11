using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedClusterVersion
{
    internal class EnvironmentManagedClusterVersionId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/environments/{environment}/managedClusterVersions/{clusterVersion}";

        public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
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
                    Name = "providers",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "microsoftServiceFabric",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.ServiceFabric"
                },

                new()
                {
                    Name = "locations",
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
                    Name = "environments",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "environments"
                },

                new()
                {
                    Name = "environment",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(EnvironmentConstant)
                },

                new()
                {
                    Name = "managedClusterVersions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "managedClusterVersions"
                },

                new()
                {
                    Name = "clusterVersion",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
