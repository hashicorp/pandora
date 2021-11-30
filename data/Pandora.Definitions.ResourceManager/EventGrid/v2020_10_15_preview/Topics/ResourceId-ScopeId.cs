using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{
    internal class ScopeId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/{scope}";

        public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
        {
                new()
                {
                    Name = "scope",
                    Type = ResourceIDSegmentType.Scope
                },

        };
    }
}
