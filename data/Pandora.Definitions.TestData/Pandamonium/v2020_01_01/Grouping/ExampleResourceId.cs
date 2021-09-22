using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class ExampleResourceId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/blah";

        public List<ResourceIDSegment> Segments()
        {
            return new List<ResourceIDSegment>
            {
                new()
                {
                    Name = "Subscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "subscriptions"
                },
                new()
                {
                    Type = ResourceIDSegmentType.SubscriptionId,
                },
                new()
                {
                    Name = "ResourceGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "resourceGroups"
                },
                new()
                {
                    Type = ResourceIDSegmentType.ResourceGroup,
                }
            };
        }
    }
}