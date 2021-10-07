using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class LocationId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.AnalysisServices/locations/{location}";

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
                    Name = "microsoftAnalysisServices",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.AnalysisServices"
                },

                new()
                {
                    Name = "locations",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "locations"
                },

                new()
                {
                    Name = "location",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
