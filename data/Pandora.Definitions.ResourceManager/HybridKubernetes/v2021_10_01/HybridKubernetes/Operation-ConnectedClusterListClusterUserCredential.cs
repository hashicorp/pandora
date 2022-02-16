using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;

internal class ConnectedClusterListClusterUserCredentialOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ListClusterUserCredentialPropertiesModel);

    public override ResourceID? ResourceId() => new ConnectedClusterId();

    public override Type? ResponseObject() => typeof(CredentialResultsModel);

    public override string? UriSuffix() => "/listClusterUserCredential";


}
