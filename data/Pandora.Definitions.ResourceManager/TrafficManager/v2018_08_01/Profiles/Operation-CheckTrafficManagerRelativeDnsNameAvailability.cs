using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles;

internal class CheckTrafficManagerRelativeDnsNameAvailabilityOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CheckTrafficManagerRelativeDnsNameAvailabilityParametersModel);

    public override Type? ResponseObject() => typeof(TrafficManagerNameAvailabilityModel);

    public override string? UriSuffix() => "/providers/Microsoft.Network/checkTrafficManagerNameAvailability";


}
