// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementEntitlementManagementRoleEligibilityScheduleInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEntitlementManagementRoleEligibilityScheduleInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEntitlementManagementRoleEligibilityScheduleInstanceOperation(),
        new DeleteRoleManagementEntitlementManagementRoleEligibilityScheduleInstanceByIdOperation(),
        new GetRoleManagementEntitlementManagementRoleEligibilityScheduleInstanceByIdOperation(),
        new GetRoleManagementEntitlementManagementRoleEligibilityScheduleInstanceCountOperation(),
        new ListRoleManagementEntitlementManagementRoleEligibilityScheduleInstancesOperation(),
        new UpdateRoleManagementEntitlementManagementRoleEligibilityScheduleInstanceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
