// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAuthenticationEmailMethod;

internal class MeAuthenticationEmailMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/emailMethods/{emailAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticEmailMethods", "emailMethods"),
        ResourceIDSegment.UserSpecified("emailAuthenticationMethodId")
    };
}
