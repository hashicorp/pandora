using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.VirtualNetworkRules;

internal class UpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(UpdateVirtualNetworkRuleParametersModel);

    public override ResourceID? ResourceId() => new VirtualNetworkRuleId();

    public override Type? ResponseObject() => typeof(VirtualNetworkRuleModel);


}
