using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkManagerEffectiveConnectivityConfiguration;

internal class ListNetworkManagerEffectiveConnectivityConfigurationsOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(QueryRequestOptionsModel);

    public override ResourceID? ResourceId() => new VirtualNetworkId();

    public override Type? ResponseObject() => typeof(NetworkManagerEffectiveConnectivityConfigurationListResultModel);

    public override string? UriSuffix() => "/listNetworkManagerEffectiveConnectivityConfigurations";


}
