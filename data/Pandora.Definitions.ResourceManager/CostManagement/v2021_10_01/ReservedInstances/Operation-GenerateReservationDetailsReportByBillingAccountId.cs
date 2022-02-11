using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.ReservedInstances;

internal class GenerateReservationDetailsReportByBillingAccountIdOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new BillingAccountId();

    public override Type? ResponseObject() => typeof(OperationStatusModel);

    public override Type? OptionsObject() => typeof(GenerateReservationDetailsReportByBillingAccountIdOperation.GenerateReservationDetailsReportByBillingAccountIdOptions);

    public override string? UriSuffix() => "/providers/Microsoft.CostManagement/generateReservationDetailsReport";

    internal class GenerateReservationDetailsReportByBillingAccountIdOptions
    {
        [QueryStringName("endDate")]
        public string EndDate { get; set; }

        [QueryStringName("startDate")]
        public string StartDate { get; set; }
    }
}
