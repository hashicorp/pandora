using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService.v2021_12_01_preview.LoadTests
{
    internal class LoadTestId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.LoadTestService/loadTests/{loadTestName}";

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
                    Name = "staticMicrosoftLoadTestService",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.LoadTestService"
                },

                new()
                {
                    Name = "staticLoadTests",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "loadTests"
                },

                new()
                {
                    Name = "loadTestName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
