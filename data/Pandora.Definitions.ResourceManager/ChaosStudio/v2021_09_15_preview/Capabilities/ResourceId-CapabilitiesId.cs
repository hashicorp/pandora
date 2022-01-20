using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Capabilities;

internal class CapabilitiesId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities/{capabilityName}";

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
                    Name = "parentProviderNamespace",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "parentResourceType",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "parentResourceName",
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
                    Name = "staticMicrosoftChaos",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Chaos"
                },

                new()
                {
                    Name = "staticTargets",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "targets"
                },

                new()
                {
                    Name = "targetName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticCapabilities",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "capabilities"
                },

                new()
                {
                    Name = "capabilityName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
