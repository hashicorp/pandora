// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyPermissionGrantPolicyExclude;

internal class CreatePolicyPermissionGrantPolicyByIdExcludeOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(PermissionGrantConditionSetModel);
    public override ResourceID? ResourceId() => new PolicyPermissionGrantPolicyId();
    public override Type? ResponseObject() => typeof(PermissionGrantConditionSetModel);
    public override string? UriSuffix() => "/excludes";
}
