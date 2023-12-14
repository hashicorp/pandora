// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAuthenticationWindowsHelloForBusinessMethodDevice;

internal class MeAuthenticationWindowsHelloForBusinessMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/windowsHelloForBusinessMethods/{windowsHelloForBusinessAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticWindowsHelloForBusinessMethods", "windowsHelloForBusinessMethods"),
        ResourceIDSegment.UserSpecified("windowsHelloForBusinessAuthenticationMethodId")
    };
}
