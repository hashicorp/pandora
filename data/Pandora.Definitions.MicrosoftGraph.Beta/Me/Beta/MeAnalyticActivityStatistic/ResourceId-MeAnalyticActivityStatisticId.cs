// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAnalyticActivityStatistic;

internal class MeAnalyticActivityStatisticId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/analytics/activityStatistics/{activityStatisticsId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAnalytics", "analytics"),
        ResourceIDSegment.Static("staticActivityStatistics", "activityStatistics"),
        ResourceIDSegment.UserSpecified("activityStatisticsId")
    };
}
