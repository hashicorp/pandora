using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views;

internal class ViewId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.CostManagement/views/{viewName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftCostManagement", "Microsoft.CostManagement"),
        ResourceIDSegment.Static("staticViews", "views"),
        ResourceIDSegment.UserSpecified("viewName"),
    };
}
