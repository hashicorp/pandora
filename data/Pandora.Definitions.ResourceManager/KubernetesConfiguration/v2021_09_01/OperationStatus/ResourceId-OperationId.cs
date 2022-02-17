using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.OperationStatus;

internal class OperationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{clusterRp}/{clusterResourceName}/{clusterName}/providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}/operations/{operationId}";

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
                    Name = "clusterRp",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(ClusterRpConstant)
                },

                new()
                {
                    Name = "clusterResourceName",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(ClusterResourceNameConstant)
                },

                new()
                {
                    Name = "clusterName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticProviders2",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftKubernetesConfiguration",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.KubernetesConfiguration"
                },

                new()
                {
                    Name = "staticExtensions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "extensions"
                },

                new()
                {
                    Name = "extensionName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticOperations",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "operations"
                },

                new()
                {
                    Name = "operationId",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
