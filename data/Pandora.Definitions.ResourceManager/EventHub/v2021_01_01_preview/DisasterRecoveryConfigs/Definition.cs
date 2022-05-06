using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.DisasterRecoveryConfigs;

internal class Definition : ResourceDefinition
{
    public string Name => "DisasterRecoveryConfigs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BreakPairingOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new FailOverOperation(),
        new GetOperation(),
        new ListOperation(),
    };
}
