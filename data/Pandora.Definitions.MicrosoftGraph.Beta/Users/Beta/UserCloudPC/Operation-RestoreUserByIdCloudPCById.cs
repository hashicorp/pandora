// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCloudPC;

internal class RestoreUserByIdCloudPCByIdOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(RestoreUserByIdCloudPCByIdRequestModel);
    public override ResourceID? ResourceId() => new UserIdCloudPCId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/restore";
}
