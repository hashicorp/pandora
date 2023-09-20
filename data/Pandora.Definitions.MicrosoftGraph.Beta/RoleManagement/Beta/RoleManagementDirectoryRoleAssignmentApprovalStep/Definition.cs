// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryRoleAssignmentApprovalStep;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementDirectoryRoleAssignmentApprovalStep";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementDirectoryRoleAssignmentApprovalByIdStepOperation(),
        new DeleteRoleManagementDirectoryRoleAssignmentApprovalByIdStepByIdOperation(),
        new GetRoleManagementDirectoryRoleAssignmentApprovalByIdStepByIdOperation(),
        new GetRoleManagementDirectoryRoleAssignmentApprovalByIdStepCountOperation(),
        new ListRoleManagementDirectoryRoleAssignmentApprovalByIdStepsOperation(),
        new UpdateRoleManagementDirectoryRoleAssignmentApprovalByIdStepByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
