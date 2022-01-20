using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService;

internal class LinkNotificationHubOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(LinkNotificationHubParametersModel);

    public override ResourceID? ResourceId() => new CommunicationServiceId();

    public override Type? ResponseObject() => typeof(LinkedNotificationHubModel);

    public override string? UriSuffix() => "/linkNotificationHub";


}
