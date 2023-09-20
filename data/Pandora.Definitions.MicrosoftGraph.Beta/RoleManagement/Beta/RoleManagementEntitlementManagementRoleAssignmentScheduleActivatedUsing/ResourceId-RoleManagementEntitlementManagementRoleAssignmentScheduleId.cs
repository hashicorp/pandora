// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEntitlementManagementRoleAssignmentScheduleActivatedUsing;

internal class RoleManagementEntitlementManagementRoleAssignmentScheduleId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/entitlementManagement/roleAssignmentSchedules/{unifiedRoleAssignmentScheduleId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticEntitlementManagement", "entitlementManagement"),
        ResourceIDSegment.Static("staticRoleAssignmentSchedules", "roleAssignmentSchedules"),
        ResourceIDSegment.UserSpecified("unifiedRoleAssignmentScheduleId")
    };
}
