using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.DomainTopics
{
    internal class ListByDomainOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new DomainId();

        public override Type NestedItemType() => typeof(DomainTopicModel);

        public override Type? OptionsObject() => typeof(ListByDomainOperation.ListByDomainOptions);

        public override string? UriSuffix() => "/topics";

        internal class ListByDomainOptions
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
