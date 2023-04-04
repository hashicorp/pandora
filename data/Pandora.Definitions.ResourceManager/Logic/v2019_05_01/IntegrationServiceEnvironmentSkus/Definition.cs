using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentSkus;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationServiceEnvironmentSkus";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IntegrationServiceEnvironmentSkuNameConstant),
        typeof(IntegrationServiceEnvironmentSkuScaleTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IntegrationServiceEnvironmentSkuCapacityModel),
        typeof(IntegrationServiceEnvironmentSkuDefinitionModel),
        typeof(IntegrationServiceEnvironmentSkuDefinitionSkuModel),
    };
}
