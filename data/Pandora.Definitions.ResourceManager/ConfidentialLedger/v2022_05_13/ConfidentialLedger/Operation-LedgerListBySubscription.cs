using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2022_05_13.ConfidentialLedger;

internal class LedgerListBySubscriptionOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new SubscriptionId();

\t\tpublic override Type NestedItemType() => typeof(ConfidentialLedgerModel);

\t\tpublic override Type? OptionsObject() => typeof(LedgerListBySubscriptionOperation.LedgerListBySubscriptionOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.ConfidentialLedger/ledgers";

    internal class LedgerListBySubscriptionOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
