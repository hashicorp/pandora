using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.PrivateEndpointConnectionProxies;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Created,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(PrivateEndpointConnectionProxyModel);

\t\tpublic override ResourceID? ResourceId() => new PrivateEndpointConnectionProxyId();

\t\tpublic override Type? ResponseObject() => typeof(PrivateEndpointConnectionProxyModel);


}
