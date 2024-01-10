// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDeviceManagementRoleAssignmentPrincipal;

internal class RoleManagementDeviceManagementRoleAssignmentIdPrincipalId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/deviceManagement/roleAssignments/{unifiedRoleAssignmentMultipleId}/principals/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticDeviceManagement", "deviceManagement"),
        ResourceIDSegment.Static("staticRoleAssignments", "roleAssignments"),
        ResourceIDSegment.UserSpecified("unifiedRoleAssignmentMultipleId"),
        ResourceIDSegment.Static("staticPrincipals", "principals"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
