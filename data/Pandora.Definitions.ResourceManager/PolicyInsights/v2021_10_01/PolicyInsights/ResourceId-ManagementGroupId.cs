using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2021_10_01.PolicyInsights;

internal class ManagementGroupId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.Constant("managementGroupsNamespace", typeof(ManagementGroupsNamespaceTypeConstant)),
        ResourceIDSegment.Static("staticManagementGroups", "managementGroups"),
        ResourceIDSegment.UserSpecified("managementGroupId"),
    };
}
