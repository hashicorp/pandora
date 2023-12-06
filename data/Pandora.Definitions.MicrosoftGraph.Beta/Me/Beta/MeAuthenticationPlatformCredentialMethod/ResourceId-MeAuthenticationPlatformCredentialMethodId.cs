// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAuthenticationPlatformCredentialMethod;

internal class MeAuthenticationPlatformCredentialMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/platformCredentialMethods/{platformCredentialAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticPlatformCredentialMethods", "platformCredentialMethods"),
        ResourceIDSegment.UserSpecified("platformCredentialAuthenticationMethodId")
    };
}
