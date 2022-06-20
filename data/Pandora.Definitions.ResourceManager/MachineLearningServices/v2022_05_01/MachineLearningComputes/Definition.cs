using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.MachineLearningComputes;

internal class Definition : ResourceDefinition
{
    public string Name => "MachineLearningComputes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ComputeCreateOrUpdateOperation(),
        new ComputeDeleteOperation(),
        new ComputeGetOperation(),
        new ComputeListOperation(),
        new ComputeListKeysOperation(),
        new ComputeListNodesOperation(),
        new ComputeRestartOperation(),
        new ComputeStartOperation(),
        new ComputeStopOperation(),
        new ComputeUpdateOperation(),
    };
}
