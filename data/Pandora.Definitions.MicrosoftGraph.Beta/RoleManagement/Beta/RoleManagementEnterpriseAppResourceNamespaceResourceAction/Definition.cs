// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppResourceNamespaceResourceAction;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEnterpriseAppResourceNamespaceResourceAction";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEnterpriseAppByIdResourceNamespaceByIdResourceActionOperation(),
        new DeleteRoleManagementEnterpriseAppByIdResourceNamespaceByIdResourceActionByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdResourceNamespaceByIdResourceActionByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdResourceNamespaceByIdResourceActionCountOperation(),
        new ListRoleManagementEnterpriseAppByIdResourceNamespaceByIdResourceActionsOperation(),
        new UpdateRoleManagementEnterpriseAppByIdResourceNamespaceByIdResourceActionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
