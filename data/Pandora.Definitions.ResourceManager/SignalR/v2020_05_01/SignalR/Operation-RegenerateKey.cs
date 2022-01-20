using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR;

internal class RegenerateKeyOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Created,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(RegenerateKeyParametersModel);

    public override ResourceID? ResourceId() => new SignalRId();

    public override Type? ResponseObject() => typeof(SignalRKeysModel);

    public override string? UriSuffix() => "/regenerateKey";


}
