// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityConditionalAccesAuthenticationStrengthAuthenticationMethodMode;

internal class IdentityConditionalAccesAuthenticationStrengthAuthenticationMethodModeId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/identity/conditionalAccess/authenticationStrength/authenticationMethodModes/{authenticationMethodModeDetailId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticIdentity", "identity"),
        ResourceIDSegment.Static("staticConditionalAccess", "conditionalAccess"),
        ResourceIDSegment.Static("staticAuthenticationStrength", "authenticationStrength"),
        ResourceIDSegment.Static("staticAuthenticationMethodModes", "authenticationMethodModes"),
        ResourceIDSegment.UserSpecified("authenticationMethodModeDetailId")
    };
}
