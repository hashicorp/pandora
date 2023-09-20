// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileEducationalActivity;

internal class UserIdProfileEducationalActivityId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/profile/educationalActivities/{educationalActivityId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticEducationalActivities", "educationalActivities"),
        ResourceIDSegment.UserSpecified("educationalActivityId")
    };
}
