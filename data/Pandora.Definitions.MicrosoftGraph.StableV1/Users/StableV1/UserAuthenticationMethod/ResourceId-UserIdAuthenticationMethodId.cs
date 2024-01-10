// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserAuthenticationMethod;

internal class UserIdAuthenticationMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/authentication/methods/{authenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticMethods", "methods"),
        ResourceIDSegment.UserSpecified("authenticationMethodId")
    };
}
