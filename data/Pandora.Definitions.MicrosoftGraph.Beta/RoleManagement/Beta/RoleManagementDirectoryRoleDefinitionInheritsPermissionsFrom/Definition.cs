// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryRoleDefinitionInheritsPermissionsFrom;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementDirectoryRoleDefinitionInheritsPermissionsFrom";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementDirectoryRoleDefinitionByIdInheritsPermissionsFromOperation(),
        new DeleteRoleManagementDirectoryRoleDefinitionByIdInheritsPermissionsFromByIdOperation(),
        new GetRoleManagementDirectoryRoleDefinitionByIdInheritsPermissionsFromByIdOperation(),
        new GetRoleManagementDirectoryRoleDefinitionByIdInheritsPermissionsFromCountOperation(),
        new ListRoleManagementDirectoryRoleDefinitionByIdInheritsPermissionsFromsOperation(),
        new UpdateRoleManagementDirectoryRoleDefinitionByIdInheritsPermissionsFromByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
