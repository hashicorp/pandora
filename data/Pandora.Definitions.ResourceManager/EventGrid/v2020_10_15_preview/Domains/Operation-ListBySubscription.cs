using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Domains
{
    internal class ListBySubscriptionOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new SubscriptionId();

        public override Type NestedItemType() => typeof(DomainModel);

        public override Type? OptionsObject() => typeof(ListBySubscriptionOperation.ListBySubscriptionOptions);

        public override string? UriSuffix() => "/providers/Microsoft.EventGrid/domains";

        internal class ListBySubscriptionOptions
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
