using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.TopicTypes
{
    internal class TopicTypeId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/providers/Microsoft.EventGrid/topicTypes/{topicTypeName}";

        public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
        {
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
                    Name = "staticTopicTypes",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "topicTypes"
                },

                new()
                {
                    Name = "topicTypeName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
