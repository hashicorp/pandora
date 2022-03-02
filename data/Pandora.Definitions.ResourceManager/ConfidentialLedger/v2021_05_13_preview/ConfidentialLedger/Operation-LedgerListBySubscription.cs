using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview.ConfidentialLedger;

internal class LedgerListBySubscriptionOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(ConfidentialLedgerModel);

    public override Type? OptionsObject() => typeof(LedgerListBySubscriptionOperation.LedgerListBySubscriptionOptions);

    public override string? UriSuffix() => "/providers/Microsoft.ConfidentialLedger/ledgers";

    internal class LedgerListBySubscriptionOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
