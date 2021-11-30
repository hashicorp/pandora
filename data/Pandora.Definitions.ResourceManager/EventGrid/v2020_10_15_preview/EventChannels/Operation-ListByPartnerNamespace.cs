using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{
    internal class ListByPartnerNamespaceOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new PartnerNamespaceId();

        public override Type NestedItemType() => typeof(EventChannelModel);

        public override Type? OptionsObject() => typeof(ListByPartnerNamespaceOperation.ListByPartnerNamespaceOptions);

        public override string? UriSuffix() => "/eventChannels";

        internal class ListByPartnerNamespaceOptions
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
