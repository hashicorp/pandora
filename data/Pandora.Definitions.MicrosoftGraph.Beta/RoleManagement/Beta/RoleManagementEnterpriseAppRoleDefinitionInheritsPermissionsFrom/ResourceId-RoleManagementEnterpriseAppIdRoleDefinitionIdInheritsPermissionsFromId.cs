// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppRoleDefinitionInheritsPermissionsFrom;

internal class RoleManagementEnterpriseAppIdRoleDefinitionIdInheritsPermissionsFromId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/enterpriseApps/{rbacApplicationId}/roleDefinitions/{unifiedRoleDefinitionId}/inheritsPermissionsFrom/{unifiedRoleDefinitionId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticEnterpriseApps", "enterpriseApps"),
        ResourceIDSegment.UserSpecified("rbacApplicationId"),
        ResourceIDSegment.Static("staticRoleDefinitions", "roleDefinitions"),
        ResourceIDSegment.UserSpecified("unifiedRoleDefinitionId"),
        ResourceIDSegment.Static("staticInheritsPermissionsFrom", "inheritsPermissionsFrom"),
        ResourceIDSegment.UserSpecified("unifiedRoleDefinitionId1")
    };
}
