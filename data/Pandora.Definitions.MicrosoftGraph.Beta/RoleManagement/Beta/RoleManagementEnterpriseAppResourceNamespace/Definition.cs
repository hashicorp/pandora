// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppResourceNamespace;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementEnterpriseAppResourceNamespace";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateRoleManagementEnterpriseAppByIdResourceNamespaceByIdImportResourceActionOperation(),
        new CreateRoleManagementEnterpriseAppByIdResourceNamespaceOperation(),
        new DeleteRoleManagementEnterpriseAppByIdResourceNamespaceByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdResourceNamespaceByIdOperation(),
        new GetRoleManagementEnterpriseAppByIdResourceNamespaceCountOperation(),
        new ListRoleManagementEnterpriseAppByIdResourceNamespacesOperation(),
        new UpdateRoleManagementEnterpriseAppByIdResourceNamespaceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateRoleManagementEnterpriseAppByIdResourceNamespaceByIdImportResourceActionRequestModel)
    };
}
