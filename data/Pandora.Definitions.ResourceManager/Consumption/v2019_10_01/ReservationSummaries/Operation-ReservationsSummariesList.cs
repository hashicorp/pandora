using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationSummaries;

internal class ReservationsSummariesListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ScopeId();

    public override Type NestedItemType() => typeof(ReservationSummaryModel);

    public override Type? OptionsObject() => typeof(ReservationsSummariesListOperation.ReservationsSummariesListOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationSummaries";

    internal class ReservationsSummariesListOptions
    {
        [QueryStringName("endDate")]
        [Optional]
        public string EndDate { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("grain")]
        public DatagrainConstant Grain { get; set; }

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
