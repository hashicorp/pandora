using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.ConnectedClusters;

internal class ConnectedClusterListClusterUserCredentialOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ListClusterUserCredentialPropertiesModel);

\t\tpublic override ResourceID? ResourceId() => new ConnectedClusterId();

\t\tpublic override Type? ResponseObject() => typeof(CredentialResultsModel);

\t\tpublic override string? UriSuffix() => "/listClusterUserCredential";


}
