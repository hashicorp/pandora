using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Lots;

internal class ListByCustomerOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new CustomerId();

    public override Type NestedItemType() => typeof(LotSummaryModel);

    public override Type? OptionsObject() => typeof(ListByCustomerOperation.ListByCustomerOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Consumption/lots";

    internal class ListByCustomerOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
