using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;

internal class EdgeModulesListProvisioningTokenOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ListProvisioningTokenInputModel);

    public override ResourceID? ResourceId() => new EdgeModuleId();

    public override Type? ResponseObject() => typeof(EdgeModuleProvisioningTokenModel);

    public override string? UriSuffix() => "/listProvisioningToken";


}
