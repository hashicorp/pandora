// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryRoleEligibilityScheduleInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementDirectoryRoleEligibilityScheduleInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementDirectoryRoleEligibilityScheduleInstanceOperation(),
        new DeleteRoleManagementDirectoryRoleEligibilityScheduleInstanceByIdOperation(),
        new GetRoleManagementDirectoryRoleEligibilityScheduleInstanceByIdOperation(),
        new GetRoleManagementDirectoryRoleEligibilityScheduleInstanceCountOperation(),
        new ListRoleManagementDirectoryRoleEligibilityScheduleInstancesOperation(),
        new UpdateRoleManagementDirectoryRoleEligibilityScheduleInstanceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
