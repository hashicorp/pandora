using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.ProxyOperations;

internal class Definition : ResourceDefinition
{
    public string Name => "ProxyOperations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new WorkspacesListNotebookKeysOperation(),
        new WorkspacesListStorageAccountKeysOperation(),
        new WorkspacesPrepareNotebookOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ListNotebookKeysResultModel),
        typeof(ListStorageAccountKeysResultModel),
        typeof(NotebookPreparationErrorModel),
        typeof(NotebookResourceInfoModel),
    };
}
