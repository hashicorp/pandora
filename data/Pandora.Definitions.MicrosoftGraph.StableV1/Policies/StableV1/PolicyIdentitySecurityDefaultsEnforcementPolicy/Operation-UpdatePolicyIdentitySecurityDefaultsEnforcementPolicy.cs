// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyIdentitySecurityDefaultsEnforcementPolicy;

internal class UpdatePolicyIdentitySecurityDefaultsEnforcementPolicyOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(IdentitySecurityDefaultsEnforcementPolicyModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(IdentitySecurityDefaultsEnforcementPolicyModel);
    public override string? UriSuffix() => "/policies/identitySecurityDefaultsEnforcementPolicy";
}
