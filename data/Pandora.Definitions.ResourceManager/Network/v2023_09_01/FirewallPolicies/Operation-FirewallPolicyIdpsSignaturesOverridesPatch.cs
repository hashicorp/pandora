using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.FirewallPolicies;

internal class FirewallPolicyIdpsSignaturesOverridesPatchOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(SignaturesOverridesModel);

    public override ResourceID? ResourceId() => new FirewallPolicyId();

    public override Type? ResponseObject() => typeof(SignaturesOverridesModel);

    public override string? UriSuffix() => "/signatureOverrides/default";


}
