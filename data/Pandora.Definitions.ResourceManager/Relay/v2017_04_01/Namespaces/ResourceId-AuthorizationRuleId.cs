using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces
{
    internal class AuthorizationRuleId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}";

        public List<ResourceIDSegment> Segments()
        {
            return new List<ResourceIDSegment>
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
                    Name = "resourceGroups",
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
                    Name = "providers",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "microsoftRelay",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "Microsoft.Relay"
                },

                new()
                {
                    Name = "namespaces",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "namespaces"
                },

                new()
                {
                    Name = "namespaceName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "authorizationRules",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "authorizationRules"
                },

                new()
                {
                    Name = "authorizationRuleName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
