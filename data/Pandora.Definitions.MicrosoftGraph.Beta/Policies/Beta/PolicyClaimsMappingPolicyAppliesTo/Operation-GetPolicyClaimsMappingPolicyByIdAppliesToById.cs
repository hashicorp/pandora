// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyClaimsMappingPolicyAppliesTo;

internal class GetPolicyClaimsMappingPolicyByIdAppliesToByIdOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new PolicyClaimsMappingPolicyIdAppliesToId();
    public override Type? ResponseObject() => typeof(DirectoryObjectModel);
    public override string? UriSuffix() => null;
}
