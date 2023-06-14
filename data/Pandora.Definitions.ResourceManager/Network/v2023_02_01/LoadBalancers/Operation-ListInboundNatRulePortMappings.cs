using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.LoadBalancers;

internal class ListInboundNatRulePortMappingsOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(QueryInboundNatRulePortMappingRequestModel);

    public override ResourceID? ResourceId() => new BackendAddressPoolId();

    public override Type? ResponseObject() => typeof(BackendAddressInboundNatRulePortMappingsModel);

    public override string? UriSuffix() => "/queryInboundNatRulePortMapping";


}
