using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualNetworkGateways;

internal class GetAdvertisedRoutesOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new VirtualNetworkGatewayId();

    public override Type? OptionsObject() => typeof(GetAdvertisedRoutesOperation.GetAdvertisedRoutesOptions);

    public override string? UriSuffix() => "/getAdvertisedRoutes";

    internal class GetAdvertisedRoutesOptions
    {
        [QueryStringName("peer")]
        public string Peer { get; set; }
    }
}
