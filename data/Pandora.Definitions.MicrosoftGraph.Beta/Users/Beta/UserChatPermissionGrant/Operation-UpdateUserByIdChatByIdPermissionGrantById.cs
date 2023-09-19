// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatPermissionGrant;

internal class UpdateUserByIdChatByIdPermissionGrantByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ResourceSpecificPermissionGrantModel);
    public override ResourceID? ResourceId() => new UserIdChatIdPermissionGrantId();
    public override Type? ResponseObject() => typeof(ResourceSpecificPermissionGrantModel);
    public override string? UriSuffix() => null;
}
