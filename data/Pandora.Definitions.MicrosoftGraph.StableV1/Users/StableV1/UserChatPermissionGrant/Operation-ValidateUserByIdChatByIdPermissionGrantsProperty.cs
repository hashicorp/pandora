// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserChatPermissionGrant;

internal class ValidateUserByIdChatByIdPermissionGrantsPropertyOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(ValidateUserByIdChatByIdPermissionGrantsPropertyRequestModel);
    public override ResourceID? ResourceId() => new UserIdChatId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/permissionGrants/validateProperties";
}
