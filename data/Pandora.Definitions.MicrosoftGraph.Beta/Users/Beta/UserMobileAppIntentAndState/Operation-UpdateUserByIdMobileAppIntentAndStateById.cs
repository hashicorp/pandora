// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMobileAppIntentAndState;

internal class UpdateUserByIdMobileAppIntentAndStateByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(MobileAppIntentAndStateModel);
    public override ResourceID? ResourceId() => new UserIdMobileAppIntentAndStateId();
    public override Type? ResponseObject() => typeof(MobileAppIntentAndStateModel);
    public override string? UriSuffix() => null;
}
