using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;

internal class ConnectedClusterUpdateOperation : Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ConnectedClusterPatchModel);

    public override ResourceID? ResourceId() => new ConnectedClusterId();

    public override Type? ResponseObject() => typeof(ConnectedClusterModel);


}
