// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDeviceManagementRoleAssignmentAppScope;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementDeviceManagementRoleAssignmentAppScope";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementDeviceManagementRoleAssignmentByIdAppScopeOperation(),
        new DeleteRoleManagementDeviceManagementRoleAssignmentByIdAppScopeByIdOperation(),
        new GetRoleManagementDeviceManagementRoleAssignmentByIdAppScopeByIdOperation(),
        new GetRoleManagementDeviceManagementRoleAssignmentByIdAppScopeCountOperation(),
        new ListRoleManagementDeviceManagementRoleAssignmentByIdAppScopesOperation(),
        new UpdateRoleManagementDeviceManagementRoleAssignmentByIdAppScopeByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
