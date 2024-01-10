// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Oauth2PermissionGrants.StableV1.Oauth2PermissionGrant;

internal class CreateOauth2PermissionGrantOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(OAuth2PermissionGrantModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(OAuth2PermissionGrantModel);
    public override string? UriSuffix() => "/oauth2PermissionGrants";
}
