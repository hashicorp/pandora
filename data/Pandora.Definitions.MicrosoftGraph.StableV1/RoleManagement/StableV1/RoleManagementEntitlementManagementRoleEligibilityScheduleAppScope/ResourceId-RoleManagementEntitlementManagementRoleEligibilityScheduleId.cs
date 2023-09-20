// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementEntitlementManagementRoleEligibilityScheduleAppScope;

internal class RoleManagementEntitlementManagementRoleEligibilityScheduleId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/entitlementManagement/roleEligibilitySchedules/{unifiedRoleEligibilityScheduleId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticEntitlementManagement", "entitlementManagement"),
        ResourceIDSegment.Static("staticRoleEligibilitySchedules", "roleEligibilitySchedules"),
        ResourceIDSegment.UserSpecified("unifiedRoleEligibilityScheduleId")
    };
}
