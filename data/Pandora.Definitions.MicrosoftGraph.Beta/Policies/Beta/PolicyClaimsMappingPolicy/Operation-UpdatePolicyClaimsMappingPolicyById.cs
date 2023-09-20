// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyClaimsMappingPolicy;

internal class UpdatePolicyClaimsMappingPolicyByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ClaimsMappingPolicyModel);
    public override ResourceID? ResourceId() => new PolicyClaimsMappingPolicyId();
    public override Type? ResponseObject() => typeof(ClaimsMappingPolicyModel);
    public override string? UriSuffix() => null;
}
