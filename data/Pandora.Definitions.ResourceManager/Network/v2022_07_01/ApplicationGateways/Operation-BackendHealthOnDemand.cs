using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ApplicationGateways;

internal class BackendHealthOnDemandOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ApplicationGatewayOnDemandProbeModel);

    public override ResourceID? ResourceId() => new ApplicationGatewayId();

    public override Type? ResponseObject() => typeof(ApplicationGatewayBackendHealthOnDemandModel);

    public override Type? OptionsObject() => typeof(BackendHealthOnDemandOperation.BackendHealthOnDemandOptions);

    public override string? UriSuffix() => "/getBackendHealthOnDemand";

    internal class BackendHealthOnDemandOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
