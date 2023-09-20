// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyCrossTenantAccessPolicyDefault;

internal class UpdatePolicyCrossTenantAccessPolicyDefaultOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CrossTenantAccessPolicyConfigurationDefaultModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(CrossTenantAccessPolicyConfigurationDefaultModel);
    public override string? UriSuffix() => "/policies/crossTenantAccessPolicy/default";
}
