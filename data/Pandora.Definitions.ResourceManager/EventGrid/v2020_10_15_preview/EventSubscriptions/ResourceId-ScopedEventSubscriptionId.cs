using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{
    internal class ScopedEventSubscriptionId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/{scope}/providers/Microsoft.EventGrid/eventSubscriptions/{eventSubscriptionName}";

        public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
        {
                new()
                {
                    Name = "scope",
                    Type = ResourceIDSegmentType.Scope
                },

                new()
                {
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftEventGrid",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.EventGrid"
                },

                new()
                {
                    Name = "staticEventSubscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "eventSubscriptions"
                },

                new()
                {
                    Name = "eventSubscriptionName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
