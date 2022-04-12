using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.DaprComponents;

internal class DaprComponentId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/daprComponents/{name}";

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
                    Name = "staticMicrosoftApp",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.App"
                },

                new()
                {
                    Name = "staticManagedEnvironments",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "managedEnvironments"
                },

                new()
                {
                    Name = "environmentName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticDaprComponents",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "daprComponents"
                },

                new()
                {
                    Name = "name",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
