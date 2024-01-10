// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryResourceNamespace;

internal class RoleManagementDirectoryResourceNamespaceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/directory/resourceNamespaces/{unifiedRbacResourceNamespaceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticResourceNamespaces", "resourceNamespaces"),
        ResourceIDSegment.UserSpecified("unifiedRbacResourceNamespaceId")
    };
}
