using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteProviderPorts;

internal class Definition : ResourceDefinition
{
    public string Name => "ExpressRouteProviderPorts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExpressRouteProviderPortOperation(),
        new LocationListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpressRouteProviderPortModel),
        typeof(ExpressRouteProviderPortListResultModel),
        typeof(ExpressRouteProviderPortPropertiesModel),
    };
}
