// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryRoleEligibilityScheduleInstanceDirectoryScope;

internal class RoleManagementDirectoryRoleEligibilityScheduleInstanceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/directory/roleEligibilityScheduleInstances/{unifiedRoleEligibilityScheduleInstanceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticRoleEligibilityScheduleInstances", "roleEligibilityScheduleInstances"),
        ResourceIDSegment.UserSpecified("unifiedRoleEligibilityScheduleInstanceId")
    };
}
