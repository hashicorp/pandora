// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAppConsentRequestsForApproval;

internal class CreateMeAppConsentRequestsForApprovalOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AppConsentRequestModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(AppConsentRequestModel);
    public override string? UriSuffix() => "/me/appConsentRequestsForApproval";
}
