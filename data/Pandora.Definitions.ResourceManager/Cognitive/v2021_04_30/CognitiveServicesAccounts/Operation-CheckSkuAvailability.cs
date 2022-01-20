using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts;

internal class CheckSkuAvailabilityOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CheckSkuAvailabilityParameterModel);

    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(SkuAvailabilityListResultModel);

    public override string? UriSuffix() => "/checkSkuAvailability";


}
