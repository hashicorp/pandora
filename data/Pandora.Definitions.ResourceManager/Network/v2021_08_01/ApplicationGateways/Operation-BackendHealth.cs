using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ApplicationGateways;

internal class BackendHealthOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new ApplicationGatewayId();

    public override Type? ResponseObject() => typeof(ApplicationGatewayBackendHealthModel);

    public override Type? OptionsObject() => typeof(BackendHealthOperation.BackendHealthOptions);

    public override string? UriSuffix() => "/backendhealth";

    internal class BackendHealthOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
