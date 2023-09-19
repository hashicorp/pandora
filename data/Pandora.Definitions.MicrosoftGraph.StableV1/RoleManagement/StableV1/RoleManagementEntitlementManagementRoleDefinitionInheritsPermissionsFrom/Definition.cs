// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementEntitlementManagementRoleDefinitionInheritsPermissionsFrom;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEntitlementManagementRoleDefinitionInheritsPermissionsFrom";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEntitlementManagementRoleDefinitionByIdInheritsPermissionsFromOperation(),
        new DeleteRoleManagementEntitlementManagementRoleDefinitionByIdInheritsPermissionsFromByIdOperation(),
        new GetRoleManagementEntitlementManagementRoleDefinitionByIdInheritsPermissionsFromByIdOperation(),
        new GetRoleManagementEntitlementManagementRoleDefinitionByIdInheritsPermissionsFromCountOperation(),
        new ListRoleManagementEntitlementManagementRoleDefinitionByIdInheritsPermissionsFromsOperation(),
        new UpdateRoleManagementEntitlementManagementRoleDefinitionByIdInheritsPermissionsFromByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
