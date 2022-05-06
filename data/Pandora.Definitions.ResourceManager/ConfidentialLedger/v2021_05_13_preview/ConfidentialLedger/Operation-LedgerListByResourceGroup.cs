using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview.ConfidentialLedger;

internal class LedgerListByResourceGroupOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type NestedItemType() => typeof(ConfidentialLedgerModel);

    public override Type? OptionsObject() => typeof(LedgerListByResourceGroupOperation.LedgerListByResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.ConfidentialLedger/ledgers";

    internal class LedgerListByResourceGroupOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
