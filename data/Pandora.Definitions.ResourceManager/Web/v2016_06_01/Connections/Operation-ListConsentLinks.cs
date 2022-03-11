using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;

internal class ListConsentLinksOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ListConsentLinksDefinitionModel);

    public override ResourceID? ResourceId() => new ConnectionId();

    public override Type? ResponseObject() => typeof(ConsentLinkCollectionModel);

    public override string? UriSuffix() => "/listConsentLinks";


}
