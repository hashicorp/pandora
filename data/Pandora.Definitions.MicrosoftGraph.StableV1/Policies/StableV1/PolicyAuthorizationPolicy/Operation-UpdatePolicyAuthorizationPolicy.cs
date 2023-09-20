// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyAuthorizationPolicy;

internal class UpdatePolicyAuthorizationPolicyOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AuthorizationPolicyModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(AuthorizationPolicyModel);
    public override string? UriSuffix() => "/policies/authorizationPolicy";
}
