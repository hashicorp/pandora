// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementEntitlementManagementRoleEligibilitySchedule;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEntitlementManagementRoleEligibilitySchedule";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEntitlementManagementRoleEligibilityScheduleOperation(),
        new DeleteRoleManagementEntitlementManagementRoleEligibilityScheduleByIdOperation(),
        new GetRoleManagementEntitlementManagementRoleEligibilityScheduleByIdOperation(),
        new GetRoleManagementEntitlementManagementRoleEligibilityScheduleCountOperation(),
        new ListRoleManagementEntitlementManagementRoleEligibilitySchedulesOperation(),
        new UpdateRoleManagementEntitlementManagementRoleEligibilityScheduleByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
