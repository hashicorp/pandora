using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationSummaries;

internal class ReservationsSummariesListByReservationOrderAndReservationOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ReservationId();

    public override Type NestedItemType() => typeof(ReservationSummaryModel);

    public override Type? OptionsObject() => typeof(ReservationsSummariesListByReservationOrderAndReservationOperation.ReservationsSummariesListByReservationOrderAndReservationOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationSummaries";

    internal class ReservationsSummariesListByReservationOrderAndReservationOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("grain")]
        public DatagrainConstant Grain { get; set; }
    }
}
