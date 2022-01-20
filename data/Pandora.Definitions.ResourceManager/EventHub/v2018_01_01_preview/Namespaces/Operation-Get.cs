using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces;

internal class GetOperation : Operations.GetOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Created,
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new NamespaceId();

    public override Type? ResponseObject() => typeof(EHNamespaceModel);


}
