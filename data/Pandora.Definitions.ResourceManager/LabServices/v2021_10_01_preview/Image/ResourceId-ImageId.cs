using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Image
{
    internal class ImageId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.LabServices/labPlans/{labPlanName}/images/{imageName}";

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
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "Microsoft.LabServices"
                },

                new()
                {
                    Name = "labPlans",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "labPlans"
                },

                new()
                {
                    Name = "labPlanName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "images",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "images"
                },

                new()
                {
                    Name = "imageName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
