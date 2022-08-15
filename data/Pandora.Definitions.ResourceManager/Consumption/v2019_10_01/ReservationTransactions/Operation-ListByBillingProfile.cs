using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationTransactions;

internal class ListByBillingProfileOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new BillingProfileId();

    public override Type NestedItemType() => typeof(ModernReservationTransactionModel);

    public override Type? OptionsObject() => typeof(ListByBillingProfileOperation.ListByBillingProfileOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationTransactions";

    internal class ListByBillingProfileOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
