using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;

internal class ConfirmConsentCodeOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ConfirmConsentCodeDefinitionModel);

    public override ResourceID? ResourceId() => new ConnectionId();

    public override Type? ResponseObject() => typeof(ConfirmConsentCodeDefinitionModel);

    public override string? UriSuffix() => "/confirmConsentCode";


}
