// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryResourceNamespaceResourceActionAuthenticationContext;

internal class RoleManagementDirectoryResourceNamespaceIdResourceActionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/directory/resourceNamespaces/{unifiedRbacResourceNamespaceId}/resourceActions/{unifiedRbacResourceActionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticResourceNamespaces", "resourceNamespaces"),
        ResourceIDSegment.UserSpecified("unifiedRbacResourceNamespaceId"),
        ResourceIDSegment.Static("staticResourceActions", "resourceActions"),
        ResourceIDSegment.UserSpecified("unifiedRbacResourceActionId")
    };
}
