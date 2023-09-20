// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteAnalyticItemActivityStatActivity;

internal class GroupIdSiteIdAnalyticItemActivityStatIdActivityId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/sites/{siteId}/analytics/itemActivityStats/{itemActivityStatId}/activities/{itemActivityId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticSites", "sites"),
        ResourceIDSegment.UserSpecified("siteId"),
        ResourceIDSegment.Static("staticAnalytics", "analytics"),
        ResourceIDSegment.Static("staticItemActivityStats", "itemActivityStats"),
        ResourceIDSegment.UserSpecified("itemActivityStatId"),
        ResourceIDSegment.Static("staticActivities", "activities"),
        ResourceIDSegment.UserSpecified("itemActivityId")
    };
}
