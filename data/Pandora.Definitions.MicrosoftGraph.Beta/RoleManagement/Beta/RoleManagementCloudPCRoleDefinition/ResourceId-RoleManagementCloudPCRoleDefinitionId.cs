// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementCloudPCRoleDefinition;

internal class RoleManagementCloudPCRoleDefinitionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/cloudPC/roleDefinitions/{unifiedRoleDefinitionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticCloudPC", "cloudPC"),
        ResourceIDSegment.Static("staticRoleDefinitions", "roleDefinitions"),
        ResourceIDSegment.UserSpecified("unifiedRoleDefinitionId")
    };
}
