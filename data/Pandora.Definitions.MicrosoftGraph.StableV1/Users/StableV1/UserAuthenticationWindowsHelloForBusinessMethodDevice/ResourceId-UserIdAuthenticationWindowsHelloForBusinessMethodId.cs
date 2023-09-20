// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserAuthenticationWindowsHelloForBusinessMethodDevice;

internal class UserIdAuthenticationWindowsHelloForBusinessMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/authentication/windowsHelloForBusinessMethods/{windowsHelloForBusinessAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticWindowsHelloForBusinessMethods", "windowsHelloForBusinessMethods"),
        ResourceIDSegment.UserSpecified("windowsHelloForBusinessAuthenticationMethodId")
    };
}
