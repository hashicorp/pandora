using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.GatewayRegenerateKey;

internal class GatewayRegenerateKeyOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };

    public override Type? RequestObject() => typeof(GatewayKeyRegenerationRequestContractModel);

    public override ResourceID? ResourceId() => new GatewayId();

    public override string? UriSuffix() => "/regenerateKey";


}
