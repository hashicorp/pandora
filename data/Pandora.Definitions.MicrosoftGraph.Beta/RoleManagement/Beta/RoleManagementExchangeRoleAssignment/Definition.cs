// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementExchangeRoleAssignment;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementExchangeRoleAssignment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementExchangeRoleAssignmentOperation(),
        new DeleteRoleManagementExchangeRoleAssignmentByIdOperation(),
        new GetRoleManagementExchangeRoleAssignmentByIdOperation(),
        new GetRoleManagementExchangeRoleAssignmentCountOperation(),
        new ListRoleManagementExchangeRoleAssignmentsOperation(),
        new UpdateRoleManagementExchangeRoleAssignmentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
