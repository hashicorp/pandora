using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments;

internal class StatuseId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/experiments/{experimentName}/statuses/{statusId}";

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
                    Name = "staticMicrosoftChaos",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Chaos"
                },

                new()
                {
                    Name = "staticExperiments",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "experiments"
                },

                new()
                {
                    Name = "experimentName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticStatuses",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "statuses"
                },

                new()
                {
                    Name = "statusId",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
