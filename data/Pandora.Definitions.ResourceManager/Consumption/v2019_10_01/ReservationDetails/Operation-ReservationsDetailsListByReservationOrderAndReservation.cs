using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationDetails;

internal class ReservationsDetailsListByReservationOrderAndReservationOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ReservationId();

\t\tpublic override Type NestedItemType() => typeof(ReservationDetailModel);

\t\tpublic override Type? OptionsObject() => typeof(ReservationsDetailsListByReservationOrderAndReservationOperation.ReservationsDetailsListByReservationOrderAndReservationOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationDetails";

    internal class ReservationsDetailsListByReservationOrderAndReservationOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
