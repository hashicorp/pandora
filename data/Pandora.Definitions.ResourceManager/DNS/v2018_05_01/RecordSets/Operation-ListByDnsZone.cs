using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets
{
    internal class ListByDnsZoneOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new DnsZoneId();

        public override Type NestedItemType() => typeof(RecordSetModel);

        public override Type? OptionsObject() => typeof(ListByDnsZoneOperation.ListByDnsZoneOptions);

        public override string? UriSuffix() => "/recordsets";

        internal class ListByDnsZoneOptions
        {
            [QueryStringName("$recordsetnamesuffix")]
            [Optional]
            public string Recordsetnamesuffix { get; set; }

            [QueryStringName("$top")]
            [Optional]
            public int Top { get; set; }
        }
    }
}
