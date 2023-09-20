// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfilePatent;

internal class UserIdProfilePatentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/profile/patents/{itemPatentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticPatents", "patents"),
        ResourceIDSegment.UserSpecified("itemPatentId")
    };
}
