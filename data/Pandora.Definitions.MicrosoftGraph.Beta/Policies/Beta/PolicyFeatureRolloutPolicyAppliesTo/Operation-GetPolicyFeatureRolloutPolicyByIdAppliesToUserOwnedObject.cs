// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyFeatureRolloutPolicyAppliesTo;

internal class GetPolicyFeatureRolloutPolicyByIdAppliesToUserOwnedObjectOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(GetPolicyFeatureRolloutPolicyByIdAppliesToUserOwnedObjectRequestModel);
    public override ResourceID? ResourceId() => new PolicyFeatureRolloutPolicyId();
    public override Type? ResponseObject() => typeof(DirectoryObjectModel);
    public override string? UriSuffix() => "/appliesTo/getUserOwnedObjects";
}
