using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.ScalingPlanPooledSchedule;

internal class PooledScheduleId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/scalingPlans/{scalingPlanName}/pooledSchedules/{pooledScheduleName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDesktopVirtualization", "Microsoft.DesktopVirtualization"),
        ResourceIDSegment.Static("staticScalingPlans", "scalingPlans"),
        ResourceIDSegment.UserSpecified("scalingPlanName"),
        ResourceIDSegment.Static("staticPooledSchedules", "pooledSchedules"),
        ResourceIDSegment.UserSpecified("pooledScheduleName"),
    };
}
