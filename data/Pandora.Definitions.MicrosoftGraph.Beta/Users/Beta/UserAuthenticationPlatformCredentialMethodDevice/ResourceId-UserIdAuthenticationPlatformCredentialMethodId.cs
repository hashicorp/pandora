// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAuthenticationPlatformCredentialMethodDevice;

internal class UserIdAuthenticationPlatformCredentialMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/authentication/platformCredentialMethods/{platformCredentialAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticPlatformCredentialMethods", "platformCredentialMethods"),
        ResourceIDSegment.UserSpecified("platformCredentialAuthenticationMethodId")
    };
}
