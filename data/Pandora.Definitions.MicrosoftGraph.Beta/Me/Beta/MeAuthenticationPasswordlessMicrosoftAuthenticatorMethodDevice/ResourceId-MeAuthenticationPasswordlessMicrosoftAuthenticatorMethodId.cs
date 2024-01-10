// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAuthenticationPasswordlessMicrosoftAuthenticatorMethodDevice;

internal class MeAuthenticationPasswordlessMicrosoftAuthenticatorMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/passwordlessMicrosoftAuthenticatorMethods/{passwordlessMicrosoftAuthenticatorAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticPasswordlessMicrosoftAuthenticatorMethods", "passwordlessMicrosoftAuthenticatorMethods"),
        ResourceIDSegment.UserSpecified("passwordlessMicrosoftAuthenticatorAuthenticationMethodId")
    };
}
