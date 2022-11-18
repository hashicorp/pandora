using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationSummaries;

internal class ReservationsSummariesListByReservationOrderAndReservationOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ReservationId();

\t\tpublic override Type NestedItemType() => typeof(ReservationSummaryModel);

\t\tpublic override Type? OptionsObject() => typeof(ReservationsSummariesListByReservationOrderAndReservationOperation.ReservationsSummariesListByReservationOrderAndReservationOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationSummaries";

    internal class ReservationsSummariesListByReservationOrderAndReservationOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("grain")]
        public DatagrainConstant Grain { get; set; }
    }
}
