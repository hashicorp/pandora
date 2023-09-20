// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAppConsentRequestsForApprovalUserConsentRequest;

internal class UpdateUserByIdAppConsentRequestsForApprovalByIdUserConsentRequestByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UserConsentRequestModel);
    public override ResourceID? ResourceId() => new UserIdAppConsentRequestsForApprovalIdUserConsentRequestId();
    public override Type? ResponseObject() => typeof(UserConsentRequestModel);
    public override string? UriSuffix() => null;
}
