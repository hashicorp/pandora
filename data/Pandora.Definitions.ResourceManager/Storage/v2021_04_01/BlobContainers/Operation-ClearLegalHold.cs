using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;

internal class ClearLegalHoldOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(LegalHoldModel);

    public override ResourceID? ResourceId() => new ContainerId();

    public override Type? ResponseObject() => typeof(LegalHoldModel);

    public override string? UriSuffix() => "/clearLegalHold";


}
