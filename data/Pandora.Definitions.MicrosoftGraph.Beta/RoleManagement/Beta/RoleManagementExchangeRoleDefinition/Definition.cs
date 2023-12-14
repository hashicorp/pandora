// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementExchangeRoleDefinition;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementExchangeRoleDefinition";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementExchangeRoleDefinitionOperation(),
        new DeleteRoleManagementExchangeRoleDefinitionByIdOperation(),
        new GetRoleManagementExchangeRoleDefinitionByIdOperation(),
        new GetRoleManagementExchangeRoleDefinitionCountOperation(),
        new ListRoleManagementExchangeRoleDefinitionsOperation(),
        new UpdateRoleManagementExchangeRoleDefinitionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
