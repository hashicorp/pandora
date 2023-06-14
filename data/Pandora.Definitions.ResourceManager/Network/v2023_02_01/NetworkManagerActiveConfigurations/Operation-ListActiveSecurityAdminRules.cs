using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkManagerActiveConfigurations;

internal class ListActiveSecurityAdminRulesOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ActiveConfigurationParameterModel);

    public override ResourceID? ResourceId() => new NetworkManagerId();

    public override Type? ResponseObject() => typeof(ActiveSecurityAdminRulesListResultModel);

    public override string? UriSuffix() => "/listActiveSecurityAdminRules";


}
