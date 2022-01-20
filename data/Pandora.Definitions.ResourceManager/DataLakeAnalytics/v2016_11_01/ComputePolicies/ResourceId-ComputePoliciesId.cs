using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.ComputePolicies;

internal class ComputePoliciesId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts/{accountName}/computePolicies/{computePolicyName}";

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
                    Name = "staticMicrosoftDataLakeAnalytics",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.DataLakeAnalytics"
                },

                new()
                {
                    Name = "staticAccounts",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "accounts"
                },

                new()
                {
                    Name = "accountName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticComputePolicies",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "computePolicies"
                },

                new()
                {
                    Name = "computePolicyName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
