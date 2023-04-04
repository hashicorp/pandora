using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2019_08_01.ContainerServices;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerServices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOrchestratorsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(OrchestratorProfileModel),
        typeof(OrchestratorVersionProfileModel),
        typeof(OrchestratorVersionProfileListResultModel),
        typeof(OrchestratorVersionProfilePropertiesModel),
    };
}
