using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.UsageDetails;

internal class GenerateDetailedCostReportCreateOperationOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(GenerateDetailedCostReportDefinitionModel);

    public override ResourceID? ResourceId() => new ScopeId();

    public override Type? ResponseObject() => typeof(GenerateDetailedCostReportOperationResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.CostManagement/generateDetailedCostReport";


}
