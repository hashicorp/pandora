// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeAuthenticationSoftwareOathMethod;

internal class MeAuthenticationSoftwareOathMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/softwareOathMethods/{softwareOathAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticSoftwareOathMethods", "softwareOathMethods"),
        ResourceIDSegment.UserSpecified("softwareOathAuthenticationMethodId")
    };
}
