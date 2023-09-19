// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryTransitiveRoleAssignmentRoleDefinition;

internal class RoleManagementDirectoryTransitiveRoleAssignmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/directory/transitiveRoleAssignments/{unifiedRoleAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticTransitiveRoleAssignments", "transitiveRoleAssignments"),
        ResourceIDSegment.UserSpecified("unifiedRoleAssignmentId")
    };
}
