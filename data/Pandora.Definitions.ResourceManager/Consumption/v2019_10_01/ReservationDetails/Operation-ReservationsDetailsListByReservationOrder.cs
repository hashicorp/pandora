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

internal class ReservationsDetailsListByReservationOrderOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ReservationOrderId();

    public override Type NestedItemType() => typeof(ReservationDetailModel);

    public override Type? OptionsObject() => typeof(ReservationsDetailsListByReservationOrderOperation.ReservationsDetailsListByReservationOrderOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationDetails";

    internal class ReservationsDetailsListByReservationOrderOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
