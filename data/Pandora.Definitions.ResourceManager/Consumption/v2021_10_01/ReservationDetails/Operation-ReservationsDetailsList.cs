using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationDetails;

internal class ReservationsDetailsListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ScopeId();

\t\tpublic override Type NestedItemType() => typeof(ReservationDetailModel);

\t\tpublic override Type? OptionsObject() => typeof(ReservationsDetailsListOperation.ReservationsDetailsListOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationDetails";

    internal class ReservationsDetailsListOptions
    {
        [QueryStringName("endDate")]
        [Optional]
        public string EndDate { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("reservationId")]
        [Optional]
        public string ReservationId { get; set; }

        [QueryStringName("reservationOrderId")]
        [Optional]
        public string ReservationOrderId { get; set; }

        [QueryStringName("startDate")]
        [Optional]
        public string StartDate { get; set; }
    }
}
