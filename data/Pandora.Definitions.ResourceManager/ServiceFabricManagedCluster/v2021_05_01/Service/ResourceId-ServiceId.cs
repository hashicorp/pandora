using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Service
{
    internal class ServiceId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/applications/{applicationName}/services/{serviceName}";

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
                    Name = "staticMicrosoftServiceFabric",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.ServiceFabric"
                },

                new()
                {
                    Name = "staticManagedClusters",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "managedClusters"
                },

                new()
                {
                    Name = "clusterName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticApplications",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "applications"
                },

                new()
                {
                    Name = "applicationName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticServices",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "services"
                },

                new()
                {
                    Name = "serviceName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
