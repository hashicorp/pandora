// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Oauth2PermissionGrants.Beta.Oauth2PermissionGrant;

internal class UpdateOauth2PermissionGrantByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(OAuth2PermissionGrantModel);
    public override ResourceID? ResourceId() => new Oauth2PermissionGrantId();
    public override Type? ResponseObject() => typeof(OAuth2PermissionGrantModel);
    public override string? UriSuffix() => null;
}
