using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets;

internal class ListByTypeOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ZoneId();

    public override Type NestedItemType() => typeof(RecordSetModel);

    public override Type? OptionsObject() => typeof(ListByTypeOperation.ListByTypeOptions);

    internal class ListByTypeOptions
    {
        [QueryStringName("$recordsetnamesuffix")]
        [Optional]
        public string Recordsetnamesuffix { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
