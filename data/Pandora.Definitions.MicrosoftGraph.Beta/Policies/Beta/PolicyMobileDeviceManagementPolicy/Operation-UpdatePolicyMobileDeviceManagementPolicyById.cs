// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyMobileDeviceManagementPolicy;

internal class UpdatePolicyMobileDeviceManagementPolicyByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(MobilityManagementPolicyModel);
    public override ResourceID? ResourceId() => new PolicyMobileDeviceManagementPolicyId();
    public override Type? ResponseObject() => typeof(MobilityManagementPolicyModel);
    public override string? UriSuffix() => null;
}
