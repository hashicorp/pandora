using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.ConnectedClusters;

internal class ConnectedClusterListClusterUserCredentialOperation : Pandora.Definitions.Operations.PostOperation
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
