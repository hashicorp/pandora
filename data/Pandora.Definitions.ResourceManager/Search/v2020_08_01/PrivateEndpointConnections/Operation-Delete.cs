using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.PrivateEndpointConnections;

internal class DeleteOperation : Pandora.Definitions.Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new PrivateEndpointConnectionId();

    public override Type? ResponseObject() => typeof(PrivateEndpointConnectionModel);

    public override Type? OptionsObject() => typeof(DeleteOperation.DeleteOptions);

    internal class DeleteOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XMsClientRequestId { get; set; }
    }
}
