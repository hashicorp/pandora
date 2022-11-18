using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.PriceSheet;

internal class GetByBillingPeriodOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new BillingPeriodId();

    public override Type? ResponseObject() => typeof(PriceSheetResultModel);

    public override Type? OptionsObject() => typeof(GetByBillingPeriodOperation.GetByBillingPeriodOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Consumption/pricesheets/default";

    internal class GetByBillingPeriodOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
