using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.ConsumerGroups
{
    internal class ListByEventHubOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new EventhubId();

        public override Type NestedItemType() => typeof(ConsumerGroupModel);

        public override Type? OptionsObject() => typeof(ListByEventHubOperation.ListByEventHubOptions);

        public override string? UriSuffix() => "/consumerGroups";

        internal class ListByEventHubOptions
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
