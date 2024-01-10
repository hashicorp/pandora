// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAuthenticationMicrosoftAuthenticatorMethod;

internal class MeAuthenticationMicrosoftAuthenticatorMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/microsoftAuthenticatorMethods/{microsoftAuthenticatorAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticMicrosoftAuthenticatorMethods", "microsoftAuthenticatorMethods"),
        ResourceIDSegment.UserSpecified("microsoftAuthenticatorAuthenticationMethodId")
    };
}
