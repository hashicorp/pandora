using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Workspaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Workspaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DiagnoseOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new ListNotebookAccessTokenOperation(),
        new ResyncKeysOperation(),
        new UpdateOperation(),
        new WorkspaceFeaturesListOperation(),
    };
}
