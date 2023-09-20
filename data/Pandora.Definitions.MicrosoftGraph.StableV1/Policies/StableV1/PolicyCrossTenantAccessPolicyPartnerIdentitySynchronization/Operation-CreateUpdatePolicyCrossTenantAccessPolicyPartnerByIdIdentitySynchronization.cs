// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyCrossTenantAccessPolicyPartnerIdentitySynchronization;

internal class CreateUpdatePolicyCrossTenantAccessPolicyPartnerByIdIdentitySynchronizationOperation : Operations.PutOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CrossTenantIdentitySyncPolicyPartnerModel);
    public override ResourceID? ResourceId() => new PolicyCrossTenantAccessPolicyPartnerId();
    public override Type? ResponseObject() => typeof(CrossTenantIdentitySyncPolicyPartnerModel);
    public override string? UriSuffix() => "/identitySynchronization";
}
