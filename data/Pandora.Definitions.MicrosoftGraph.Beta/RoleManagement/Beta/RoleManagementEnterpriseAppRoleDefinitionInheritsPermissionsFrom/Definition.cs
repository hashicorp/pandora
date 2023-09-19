// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppRoleDefinitionInheritsPermissionsFrom;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEnterpriseAppRoleDefinitionInheritsPermissionsFrom";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEnterpriseAppByIdRoleDefinitionByIdInheritsPermissionsFromOperation(),
        new DeleteRoleManagementEnterpriseAppByIdRoleDefinitionByIdInheritsPermissionsFromByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdRoleDefinitionByIdInheritsPermissionsFromByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdRoleDefinitionByIdInheritsPermissionsFromCountOperation(),
        new ListRoleManagementEnterpriseAppByIdRoleDefinitionByIdInheritsPermissionsFromsOperation(),
        new UpdateRoleManagementEnterpriseAppByIdRoleDefinitionByIdInheritsPermissionsFromByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
