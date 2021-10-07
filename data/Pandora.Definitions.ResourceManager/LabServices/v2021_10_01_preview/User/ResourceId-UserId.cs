using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.User
{
    internal class UserId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.LabServices/labs/{labName}/users/{userName}";

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
                    Name = "microsoftLabServices",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.LabServices"
                },

                new()
                {
                    Name = "labs",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "labs"
                },

                new()
                {
                    Name = "labName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "users",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "users"
                },

                new()
                {
                    Name = "userName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
