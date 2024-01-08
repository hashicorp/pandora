using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualNetworkGateways;

internal class VpnDeviceConfigurationScriptOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(VpnDeviceScriptParametersModel);

    public override ResourceID? ResourceId() => new ConnectionId();

    public override Type? ResponseObject() => typeof(string);

    public override string? UriSuffix() => "/vpndeviceconfigurationscript";


}
