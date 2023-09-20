// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeActivityHistoryItem;

internal class MeActivityIdHistoryItemId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/activities/{userActivityId}/historyItems/{activityHistoryItemId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticActivities", "activities"),
        ResourceIDSegment.UserSpecified("userActivityId"),
        ResourceIDSegment.Static("staticHistoryItems", "historyItems"),
        ResourceIDSegment.UserSpecified("activityHistoryItemId")
    };
}
