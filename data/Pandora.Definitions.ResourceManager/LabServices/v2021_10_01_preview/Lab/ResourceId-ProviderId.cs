using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Lab
{
    internal class ProviderId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.LabServices";

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

            };
        }
    }
}
