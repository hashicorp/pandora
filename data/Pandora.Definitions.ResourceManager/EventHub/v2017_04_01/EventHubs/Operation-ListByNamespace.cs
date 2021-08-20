using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{
    internal class ListByNamespaceOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new NamespaceId();

        public override Type NestedItemType() => typeof(EventhubModel);

        public override Type? OptionsObject() => typeof(ListByNamespaceOperation.ListByNamespaceOptions);

        public override string? UriSuffix() => "/eventhubs";

        internal class ListByNamespaceOptions
        {
            [QueryStringName("$skip")]
            [Optional]
            public int Skip { get; set; }
            [QueryStringName("$top")]
            [Optional]
            public int Top { get; set; }
        }
    }
}
