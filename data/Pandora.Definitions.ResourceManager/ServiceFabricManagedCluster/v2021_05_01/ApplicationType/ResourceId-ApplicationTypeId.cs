using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ApplicationType;

internal class ApplicationTypeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/applicationTypes/{applicationTypeName}";

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
                    Name = "staticApplicationTypes",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "applicationTypes"
                },

                new()
                {
                    Name = "applicationTypeName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
