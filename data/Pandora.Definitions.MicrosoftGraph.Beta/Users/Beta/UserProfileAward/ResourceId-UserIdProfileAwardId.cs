// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileAward;

internal class UserIdProfileAwardId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/profile/awards/{personAwardId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticAwards", "awards"),
        ResourceIDSegment.UserSpecified("personAwardId")
    };
}
