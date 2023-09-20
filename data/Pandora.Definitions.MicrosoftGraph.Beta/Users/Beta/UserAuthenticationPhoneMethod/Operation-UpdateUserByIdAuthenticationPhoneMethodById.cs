// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAuthenticationPhoneMethod;

internal class UpdateUserByIdAuthenticationPhoneMethodByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(PhoneAuthenticationMethodModel);
    public override ResourceID? ResourceId() => new UserIdAuthenticationPhoneMethodId();
    public override Type? ResponseObject() => typeof(PhoneAuthenticationMethodModel);
    public override string? UriSuffix() => null;
}
