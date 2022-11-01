using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.AgentPools;

internal class Definition : ResourceDefinition
{
    public string Name => "AgentPools";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AbortLatestOperationOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetAvailableAgentPoolVersionsOperation(),
        new GetUpgradeProfileOperation(),
        new ListOperation(),
        new UpgradeNodeImageVersionOperation(),
    };
}
