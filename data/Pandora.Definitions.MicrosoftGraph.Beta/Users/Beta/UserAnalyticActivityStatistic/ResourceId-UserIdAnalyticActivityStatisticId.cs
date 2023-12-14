// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAnalyticActivityStatistic;

internal class UserIdAnalyticActivityStatisticId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/analytics/activityStatistics/{activityStatisticsId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAnalytics", "analytics"),
        ResourceIDSegment.Static("staticActivityStatistics", "activityStatistics"),
        ResourceIDSegment.UserSpecified("activityStatisticsId")
    };
}
