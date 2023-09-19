// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyAuthorizationPolicyDefaultUserRoleOverride;

internal class CreatePolicyAuthorizationPolicyByIdDefaultUserRoleOverrideOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(DefaultUserRoleOverrideModel);
    public override ResourceID? ResourceId() => new PolicyAuthorizationPolicyId();
    public override Type? ResponseObject() => typeof(DefaultUserRoleOverrideModel);
    public override string? UriSuffix() => "/defaultUserRoleOverrides";
}
