using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.Zones
{
    internal class ListOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new SubscriptionId();

        public override Type NestedItemType() => typeof(ZoneModel);

        public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

        public override string? UriSuffix() => "/providers/Microsoft.Network/dnszones";

        internal class ListOptions
        {
            [QueryStringName("$top")]
            [Optional]
            public int Top { get; set; }
        }
    }
}
