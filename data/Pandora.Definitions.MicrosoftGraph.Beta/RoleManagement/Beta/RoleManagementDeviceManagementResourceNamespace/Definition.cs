// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDeviceManagementResourceNamespace;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementDeviceManagementResourceNamespace";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementDeviceManagementResourceNamespaceByIdImportResourceActionOperation(),
        new CreateRoleManagementDeviceManagementResourceNamespaceOperation(),
        new DeleteRoleManagementDeviceManagementResourceNamespaceByIdOperation(),
        new GetRoleManagementDeviceManagementResourceNamespaceByIdOperation(),
        new GetRoleManagementDeviceManagementResourceNamespaceCountOperation(),
        new ListRoleManagementDeviceManagementResourceNamespacesOperation(),
        new UpdateRoleManagementDeviceManagementResourceNamespaceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateRoleManagementDeviceManagementResourceNamespaceByIdImportResourceActionRequestModel)
    };
}
