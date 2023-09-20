// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOauth2PermissionGrant;

internal class MeOauth2PermissionGrantId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/oauth2PermissionGrants/{oAuth2PermissionGrantId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOauth2PermissionGrants", "oauth2PermissionGrants"),
        ResourceIDSegment.UserSpecified("oAuth2PermissionGrantId")
    };
}
