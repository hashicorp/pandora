// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserActivityHistoryItemActivity;

internal class UserIdActivityIdHistoryItemId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/activities/{userActivityId}/historyItems/{activityHistoryItemId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticActivities", "activities"),
        ResourceIDSegment.UserSpecified("userActivityId"),
        ResourceIDSegment.Static("staticHistoryItems", "historyItems"),
        ResourceIDSegment.UserSpecified("activityHistoryItemId")
    };
}
