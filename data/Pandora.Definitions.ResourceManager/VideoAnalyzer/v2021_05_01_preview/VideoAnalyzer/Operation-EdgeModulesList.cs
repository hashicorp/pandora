using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{
    internal class EdgeModulesListOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "@nextLink";

        public override ResourceID? ResourceId() => new VideoAnalyzerId();

        public override Type NestedItemType() => typeof(EdgeModuleEntityModel);

        public override Type? OptionsObject() => typeof(EdgeModulesListOperation.EdgeModulesListOptions);

        public override string? UriSuffix() => "/edgeModules";

        internal class EdgeModulesListOptions
        {
            [QueryStringName("$filter")]
            [Optional]
            public string Filter { get; set; }
            [QueryStringName("$orderby")]
            [Optional]
            public string Orderby { get; set; }
            [QueryStringName("$top")]
            [Optional]
            public int Top { get; set; }
        }
    }
}
