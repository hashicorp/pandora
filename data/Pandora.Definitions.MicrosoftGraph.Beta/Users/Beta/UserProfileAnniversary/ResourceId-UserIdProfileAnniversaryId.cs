// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileAnniversary;

internal class UserIdProfileAnniversaryId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/profile/anniversaries/{personAnnualEventId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticAnniversaries", "anniversaries"),
        ResourceIDSegment.UserSpecified("personAnnualEventId")
    };
}
