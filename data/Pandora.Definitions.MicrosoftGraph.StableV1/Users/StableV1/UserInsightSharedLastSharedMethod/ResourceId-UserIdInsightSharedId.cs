// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserInsightSharedLastSharedMethod;

internal class UserIdInsightSharedId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/insights/shared/{sharedInsightId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInsights", "insights"),
        ResourceIDSegment.Static("staticShared", "shared"),
        ResourceIDSegment.UserSpecified("sharedInsightId")
    };
}
