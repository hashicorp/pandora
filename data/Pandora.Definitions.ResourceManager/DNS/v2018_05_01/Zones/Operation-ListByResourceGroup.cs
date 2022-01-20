using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.Zones;

internal class ListByResourceGroupOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type NestedItemType() => typeof(ZoneModel);

    public override Type? OptionsObject() => typeof(ListByResourceGroupOperation.ListByResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Network/dnsZones";

    internal class ListByResourceGroupOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
