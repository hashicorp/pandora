using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.GatewayRegenerateKey;

internal class GatewayRegenerateKeyOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };

    public override Type? RequestObject() => typeof(GatewayKeyRegenerationRequestContractModel);

\t\tpublic override ResourceID? ResourceId() => new GatewayId();

\t\tpublic override string? UriSuffix() => "/regenerateKey";


}
