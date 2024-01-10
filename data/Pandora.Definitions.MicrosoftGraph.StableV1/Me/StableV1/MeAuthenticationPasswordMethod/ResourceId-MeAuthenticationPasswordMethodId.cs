// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeAuthenticationPasswordMethod;

internal class MeAuthenticationPasswordMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/passwordMethods/{passwordAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticPasswordMethods", "passwordMethods"),
        ResourceIDSegment.UserSpecified("passwordAuthenticationMethodId")
    };
}
