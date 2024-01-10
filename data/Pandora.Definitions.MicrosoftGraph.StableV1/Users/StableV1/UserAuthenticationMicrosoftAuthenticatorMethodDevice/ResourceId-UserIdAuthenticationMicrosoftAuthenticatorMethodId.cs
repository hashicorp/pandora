// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserAuthenticationMicrosoftAuthenticatorMethodDevice;

internal class UserIdAuthenticationMicrosoftAuthenticatorMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/authentication/microsoftAuthenticatorMethods/{microsoftAuthenticatorAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticMicrosoftAuthenticatorMethods", "microsoftAuthenticatorMethods"),
        ResourceIDSegment.UserSpecified("microsoftAuthenticatorAuthenticationMethodId")
    };
}
