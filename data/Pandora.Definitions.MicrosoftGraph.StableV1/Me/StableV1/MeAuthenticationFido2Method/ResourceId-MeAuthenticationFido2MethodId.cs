// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeAuthenticationFido2Method;

internal class MeAuthenticationFido2MethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/fido2Methods/{fido2AuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticFido2Methods", "fido2Methods"),
        ResourceIDSegment.UserSpecified("fido2AuthenticationMethodId")
    };
}
