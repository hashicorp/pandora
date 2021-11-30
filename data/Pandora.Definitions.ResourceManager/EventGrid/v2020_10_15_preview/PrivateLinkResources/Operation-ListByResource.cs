using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PrivateLinkResources
{
    internal class ListByResourceOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new ProviderId();

        public override Type NestedItemType() => typeof(PrivateLinkResourceModel);

        public override Type? OptionsObject() => typeof(ListByResourceOperation.ListByResourceOptions);

        public override string? UriSuffix() => "/privateLinkResources";

        internal class ListByResourceOptions
        {
            [QueryStringName("$filter")]
            [Optional]
            public string Filter { get; set; }

            [QueryStringName("$top")]
            [Optional]
            public int Top { get; set; }
        }
    }
}
