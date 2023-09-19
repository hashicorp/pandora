// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryRoleAssignmentScheduleRequestTargetSchedule;

internal class RoleManagementDirectoryRoleAssignmentScheduleRequestId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/directory/roleAssignmentScheduleRequests/{unifiedRoleAssignmentScheduleRequestId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticRoleAssignmentScheduleRequests", "roleAssignmentScheduleRequests"),
        ResourceIDSegment.UserSpecified("unifiedRoleAssignmentScheduleRequestId")
    };
}
