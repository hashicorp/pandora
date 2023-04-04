using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.HeatMaps;

internal class Definition : ResourceDefinition
{
    public string Name => "HeatMaps";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new HeatMapGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EndpointTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(HeatMapEndpointModel),
        typeof(HeatMapModelModel),
        typeof(HeatMapPropertiesModel),
        typeof(QueryExperienceModel),
        typeof(TrafficFlowModel),
    };
}
