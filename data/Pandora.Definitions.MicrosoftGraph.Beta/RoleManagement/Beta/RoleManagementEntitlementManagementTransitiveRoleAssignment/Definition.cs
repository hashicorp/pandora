// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEntitlementManagementTransitiveRoleAssignment;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEntitlementManagementTransitiveRoleAssignment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEntitlementManagementTransitiveRoleAssignmentOperation(),
        new DeleteRoleManagementEntitlementManagementTransitiveRoleAssignmentByIdOperation(),
        new GetRoleManagementEntitlementManagementTransitiveRoleAssignmentByIdOperation(),
        new GetRoleManagementEntitlementManagementTransitiveRoleAssignmentCountOperation(),
        new ListRoleManagementEntitlementManagementTransitiveRoleAssignmentsOperation(),
        new UpdateRoleManagementEntitlementManagementTransitiveRoleAssignmentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
