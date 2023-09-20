// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyAuthenticationStrengthPolicyCombinationConfiguration;

internal class UpdatePolicyAuthenticationStrengthPolicyByIdCombinationConfigurationByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AuthenticationCombinationConfigurationModel);
    public override ResourceID? ResourceId() => new PolicyAuthenticationStrengthPolicyIdCombinationConfigurationId();
    public override Type? ResponseObject() => typeof(AuthenticationCombinationConfigurationModel);
    public override string? UriSuffix() => null;
}
