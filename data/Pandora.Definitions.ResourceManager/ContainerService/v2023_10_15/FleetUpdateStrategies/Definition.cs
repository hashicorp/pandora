using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.FleetUpdateStrategies;

internal class Definition : ResourceDefinition
{
    public string Name => "FleetUpdateStrategies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByFleetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FleetUpdateStrategyProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FleetUpdateStrategyModel),
        typeof(FleetUpdateStrategyPropertiesModel),
        typeof(UpdateGroupModel),
        typeof(UpdateRunStrategyModel),
        typeof(UpdateStageModel),
    };
}
