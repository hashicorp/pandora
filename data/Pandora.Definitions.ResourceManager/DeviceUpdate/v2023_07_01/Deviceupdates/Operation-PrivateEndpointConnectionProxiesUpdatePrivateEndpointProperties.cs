using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2023_07_01.Deviceupdates;

internal class PrivateEndpointConnectionProxiesUpdatePrivateEndpointPropertiesOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(PrivateEndpointUpdateModel);

    public override ResourceID? ResourceId() => new PrivateEndpointConnectionProxyId();

    public override string? UriSuffix() => "/updatePrivateEndpointProperties";


}
