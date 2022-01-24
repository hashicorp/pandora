using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.RealUserMetrics;

internal class TrafficManagerUserMetricsKeysDeleteOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(DeleteOperationResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default";


}
