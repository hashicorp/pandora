// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryRoleEligibilityScheduleDirectoryScope;

internal class RoleManagementDirectoryRoleEligibilityScheduleId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/directory/roleEligibilitySchedules/{unifiedRoleEligibilityScheduleId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticRoleEligibilitySchedules", "roleEligibilitySchedules"),
        ResourceIDSegment.UserSpecified("unifiedRoleEligibilityScheduleId")
    };
}
