// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDeviceManagementResourceNamespaceResourceAction;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementDeviceManagementResourceNamespaceResourceAction";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementDeviceManagementResourceNamespaceByIdResourceActionOperation(),
        new DeleteRoleManagementDeviceManagementResourceNamespaceByIdResourceActionByIdOperation(),
        new GetRoleManagementDeviceManagementResourceNamespaceByIdResourceActionByIdOperation(),
        new GetRoleManagementDeviceManagementResourceNamespaceByIdResourceActionCountOperation(),
        new ListRoleManagementDeviceManagementResourceNamespaceByIdResourceActionsOperation(),
        new UpdateRoleManagementDeviceManagementResourceNamespaceByIdResourceActionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
