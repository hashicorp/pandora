// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppRoleEligibilityScheduleRequest;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEnterpriseAppRoleEligibilityScheduleRequest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEnterpriseAppByIdRoleEligibilityScheduleRequestByIdCancelOperation(),
        new CreateRoleManagementEnterpriseAppByIdRoleEligibilityScheduleRequestOperation(),
        new DeleteRoleManagementEnterpriseAppByIdRoleEligibilityScheduleRequestByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdRoleEligibilityScheduleRequestByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdRoleEligibilityScheduleRequestCountOperation(),
        new ListRoleManagementEnterpriseAppByIdRoleEligibilityScheduleRequestsOperation(),
        new UpdateRoleManagementEnterpriseAppByIdRoleEligibilityScheduleRequestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
