// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppRoleAssignmentScheduleRequest;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEnterpriseAppRoleAssignmentScheduleRequest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEnterpriseAppByIdRoleAssignmentScheduleRequestByIdCancelOperation(),
        new CreateRoleManagementEnterpriseAppByIdRoleAssignmentScheduleRequestOperation(),
        new DeleteRoleManagementEnterpriseAppByIdRoleAssignmentScheduleRequestByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdRoleAssignmentScheduleRequestByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdRoleAssignmentScheduleRequestCountOperation(),
        new ListRoleManagementEnterpriseAppByIdRoleAssignmentScheduleRequestsOperation(),
        new UpdateRoleManagementEnterpriseAppByIdRoleAssignmentScheduleRequestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
