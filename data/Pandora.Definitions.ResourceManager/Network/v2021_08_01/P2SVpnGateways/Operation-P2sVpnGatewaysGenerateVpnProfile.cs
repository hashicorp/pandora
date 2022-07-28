using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.P2SVpnGateways;

internal class P2sVpnGatewaysGenerateVpnProfileOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(P2SVpnProfileParametersModel);

    public override ResourceID? ResourceId() => new P2svpnGatewayId();

    public override Type? ResponseObject() => typeof(VpnProfileResponseModel);

    public override string? UriSuffix() => "/generatevpnprofile";


}
