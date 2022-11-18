using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.ReservedInstances;

internal class GenerateReservationDetailsReportByBillingProfileIdOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new BillingProfileId();

\t\tpublic override Type? ResponseObject() => typeof(OperationStatusModel);

\t\tpublic override Type? OptionsObject() => typeof(GenerateReservationDetailsReportByBillingProfileIdOperation.GenerateReservationDetailsReportByBillingProfileIdOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.CostManagement/generateReservationDetailsReport";

    internal class GenerateReservationDetailsReportByBillingProfileIdOptions
    {
        [QueryStringName("endDate")]
        public string EndDate { get; set; }

        [QueryStringName("startDate")]
        public string StartDate { get; set; }
    }
}
