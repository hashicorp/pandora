using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views
{
    internal class ViewId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/providers/Microsoft.CostManagement/views/{viewName}";

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
                    Name = "staticMicrosoftCostManagement",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.CostManagement"
                },

                new()
                {
                    Name = "staticViews",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "views"
                },

                new()
                {
                    Name = "viewName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
