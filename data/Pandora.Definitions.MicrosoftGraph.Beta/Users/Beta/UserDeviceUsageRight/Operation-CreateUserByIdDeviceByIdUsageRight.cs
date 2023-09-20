// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceUsageRight;

internal class CreateUserByIdDeviceByIdUsageRightOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UsageRightModel);
    public override ResourceID? ResourceId() => new UserIdDeviceId();
    public override Type? ResponseObject() => typeof(UsageRightModel);
    public override string? UriSuffix() => "/usageRights";
}
