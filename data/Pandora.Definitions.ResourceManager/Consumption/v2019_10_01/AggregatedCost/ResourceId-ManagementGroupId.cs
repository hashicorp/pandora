using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.AggregatedCost;

internal class ManagementGroupId : ResourceID
{
    public string? CommonAlias => "ManagementGroup";

    public string ID => "/providers/Microsoft.Management/managementGroups/{groupId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.Management"),
        ResourceIDSegment.Static("managementGroups", "managementGroups"),
        ResourceIDSegment.UserSpecified("groupId"),
    };
}
