using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_06_01_preview.ScheduledActions;

internal class ScopedScheduledActionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.CostManagement/scheduledActions/{name}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftCostManagement", "Microsoft.CostManagement"),
        ResourceIDSegment.Static("staticScheduledActions", "scheduledActions"),
        ResourceIDSegment.UserSpecified("name"),
    };
}
