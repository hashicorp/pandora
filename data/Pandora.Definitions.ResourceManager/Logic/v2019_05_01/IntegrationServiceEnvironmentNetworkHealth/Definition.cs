using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentNetworkHealth;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationServiceEnvironmentNetworkHealth";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ErrorResponseCodeConstant),
        typeof(IntegrationServiceEnvironmentNetworkDependencyCategoryTypeConstant),
        typeof(IntegrationServiceEnvironmentNetworkDependencyHealthStateConstant),
        typeof(IntegrationServiceEnvironmentNetworkEndPointAccessibilityStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExtendedErrorInfoModel),
        typeof(IntegrationServiceEnvironmentNetworkDependencyModel),
        typeof(IntegrationServiceEnvironmentNetworkDependencyHealthModel),
        typeof(IntegrationServiceEnvironmentNetworkEndpointModel),
        typeof(IntegrationServiceEnvironmentSubnetNetworkHealthModel),
    };
}
