// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryRoleDefinition;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementDirectoryRoleDefinition";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementDirectoryRoleDefinitionOperation(),
        new DeleteRoleManagementDirectoryRoleDefinitionByIdOperation(),
        new GetRoleManagementDirectoryRoleDefinitionByIdOperation(),
        new GetRoleManagementDirectoryRoleDefinitionCountOperation(),
        new ListRoleManagementDirectoryRoleDefinitionsOperation(),
        new UpdateRoleManagementDirectoryRoleDefinitionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
