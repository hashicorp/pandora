using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.Workspaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Workspaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
        new WorkspaceAadAdminsCreateOrUpdateOperation(),
        new WorkspaceAadAdminsDeleteOperation(),
        new WorkspaceAadAdminsGetOperation(),
        new WorkspaceManagedIdentitySqlControlSettingsCreateOrUpdateOperation(),
        new WorkspaceManagedIdentitySqlControlSettingsGetOperation(),
        new WorkspaceSqlAadAdminsCreateOrUpdateOperation(),
        new WorkspaceSqlAadAdminsDeleteOperation(),
        new WorkspaceSqlAadAdminsGetOperation(),
    };
}
