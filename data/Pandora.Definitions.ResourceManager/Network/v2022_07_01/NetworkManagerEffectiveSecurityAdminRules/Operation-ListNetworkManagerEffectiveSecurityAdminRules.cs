using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagerEffectiveSecurityAdminRules;

internal class ListNetworkManagerEffectiveSecurityAdminRulesOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(QueryRequestOptionsModel);

    public override ResourceID? ResourceId() => new VirtualNetworkId();

    public override Type? ResponseObject() => typeof(NetworkManagerEffectiveSecurityAdminRulesListResultModel);

    public override string? UriSuffix() => "/listNetworkManagerEffectiveSecurityAdminRules";


}
