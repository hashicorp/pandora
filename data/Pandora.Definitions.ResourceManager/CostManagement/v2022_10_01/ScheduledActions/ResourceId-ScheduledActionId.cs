using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.ScheduledActions;

internal class ScheduledActionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.CostManagement/scheduledActions/{scheduledActionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftCostManagement", "Microsoft.CostManagement"),
        ResourceIDSegment.Static("staticScheduledActions", "scheduledActions"),
        ResourceIDSegment.UserSpecified("scheduledActionName"),
    };
}
