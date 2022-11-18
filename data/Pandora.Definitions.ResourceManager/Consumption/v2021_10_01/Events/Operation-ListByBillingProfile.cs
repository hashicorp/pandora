using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Events;

internal class ListByBillingProfileOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new BillingProfileId();

\t\tpublic override Type NestedItemType() => typeof(EventSummaryModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByBillingProfileOperation.ListByBillingProfileOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Consumption/events";

    internal class ListByBillingProfileOptions
    {
        [QueryStringName("endDate")]
        public string EndDate { get; set; }

        [QueryStringName("startDate")]
        public string StartDate { get; set; }
    }
}
