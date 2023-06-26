using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.ReservationDetails;

internal class ReservationsDetailsListByReservationOrderAndReservationOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ReservationId();

    public override Type NestedItemType() => typeof(ReservationDetailModel);

    public override Type? OptionsObject() => typeof(ReservationsDetailsListByReservationOrderAndReservationOperation.ReservationsDetailsListByReservationOrderAndReservationOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationDetails";

    internal class ReservationsDetailsListByReservationOrderAndReservationOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
