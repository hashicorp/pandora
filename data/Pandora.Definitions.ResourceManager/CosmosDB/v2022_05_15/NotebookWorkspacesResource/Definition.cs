using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.NotebookWorkspacesResource;

internal class Definition : ResourceDefinition
{
    public string Name => "NotebookWorkspacesResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NotebookWorkspacesCreateOrUpdateOperation(),
        new NotebookWorkspacesDeleteOperation(),
        new NotebookWorkspacesGetOperation(),
        new NotebookWorkspacesListByDatabaseAccountOperation(),
        new NotebookWorkspacesListConnectionInfoOperation(),
        new NotebookWorkspacesRegenerateAuthTokenOperation(),
        new NotebookWorkspacesStartOperation(),
    };
}
