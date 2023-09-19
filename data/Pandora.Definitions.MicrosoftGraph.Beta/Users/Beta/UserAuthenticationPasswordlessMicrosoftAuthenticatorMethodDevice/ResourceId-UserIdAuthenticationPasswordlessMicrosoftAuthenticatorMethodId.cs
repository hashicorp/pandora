// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAuthenticationPasswordlessMicrosoftAuthenticatorMethodDevice;

internal class UserIdAuthenticationPasswordlessMicrosoftAuthenticatorMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/authentication/passwordlessMicrosoftAuthenticatorMethods/{passwordlessMicrosoftAuthenticatorAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticPasswordlessMicrosoftAuthenticatorMethods", "passwordlessMicrosoftAuthenticatorMethods"),
        ResourceIDSegment.UserSpecified("passwordlessMicrosoftAuthenticatorAuthenticationMethodId")
    };
}
