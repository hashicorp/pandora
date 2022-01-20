using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.RedisEnterprise;

internal class DatabasesRegenerateKeyOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(RegenerateKeyParametersModel);

    public override ResourceID? ResourceId() => new DatabaseId();

    public override Type? ResponseObject() => typeof(AccessKeysModel);

    public override string? UriSuffix() => "/regenerateKey";


}
