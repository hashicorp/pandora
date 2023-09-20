// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDeviceManagementRoleDefinitionInheritsPermissionsFrom;

internal class RoleManagementDeviceManagementRoleDefinitionIdInheritsPermissionsFromId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/deviceManagement/roleDefinitions/{unifiedRoleDefinitionId}/inheritsPermissionsFrom/{unifiedRoleDefinitionId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticDeviceManagement", "deviceManagement"),
        ResourceIDSegment.Static("staticRoleDefinitions", "roleDefinitions"),
        ResourceIDSegment.UserSpecified("unifiedRoleDefinitionId"),
        ResourceIDSegment.Static("staticInheritsPermissionsFrom", "inheritsPermissionsFrom"),
        ResourceIDSegment.UserSpecified("unifiedRoleDefinitionId1")
    };
}
