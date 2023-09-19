// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppRoleEligibilityScheduleInstanceRoleDefinition;

internal class RoleManagementEnterpriseAppIdRoleEligibilityScheduleInstanceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/enterpriseApps/{rbacApplicationId}/roleEligibilityScheduleInstances/{unifiedRoleEligibilityScheduleInstanceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticEnterpriseApps", "enterpriseApps"),
        ResourceIDSegment.UserSpecified("rbacApplicationId"),
        ResourceIDSegment.Static("staticRoleEligibilityScheduleInstances", "roleEligibilityScheduleInstances"),
        ResourceIDSegment.UserSpecified("unifiedRoleEligibilityScheduleInstanceId")
    };
}
