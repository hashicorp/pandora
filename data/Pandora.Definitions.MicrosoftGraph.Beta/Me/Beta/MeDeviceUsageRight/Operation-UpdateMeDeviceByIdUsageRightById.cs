// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceUsageRight;

internal class UpdateMeDeviceByIdUsageRightByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UsageRightModel);
    public override ResourceID? ResourceId() => new MeDeviceIdUsageRightId();
    public override Type? ResponseObject() => typeof(UsageRightModel);
    public override string? UriSuffix() => null;
}
