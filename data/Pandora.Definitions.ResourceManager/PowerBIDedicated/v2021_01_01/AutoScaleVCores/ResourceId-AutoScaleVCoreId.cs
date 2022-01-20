using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores;

internal class AutoScaleVCoreId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PowerBIDedicated/autoScaleVCores/{vcoreName}";

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
                    Name = "staticMicrosoftPowerBIDedicated",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.PowerBIDedicated"
                },

                new()
                {
                    Name = "staticAutoScaleVCores",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "autoScaleVCores"
                },

                new()
                {
                    Name = "vcoreName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
