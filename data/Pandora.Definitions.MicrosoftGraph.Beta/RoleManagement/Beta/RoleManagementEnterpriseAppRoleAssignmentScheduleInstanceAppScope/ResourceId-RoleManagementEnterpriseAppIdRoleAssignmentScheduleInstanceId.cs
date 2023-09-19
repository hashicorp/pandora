// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppRoleAssignmentScheduleInstanceAppScope;

internal class RoleManagementEnterpriseAppIdRoleAssignmentScheduleInstanceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/enterpriseApps/{rbacApplicationId}/roleAssignmentScheduleInstances/{unifiedRoleAssignmentScheduleInstanceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticEnterpriseApps", "enterpriseApps"),
        ResourceIDSegment.UserSpecified("rbacApplicationId"),
        ResourceIDSegment.Static("staticRoleAssignmentScheduleInstances", "roleAssignmentScheduleInstances"),
        ResourceIDSegment.UserSpecified("unifiedRoleAssignmentScheduleInstanceId")
    };
}
