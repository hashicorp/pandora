using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.ExpressRouteCircuitRoutesTableSummary;

internal class Definition : ResourceDefinition
{
    public string Name => "ExpressRouteCircuitRoutesTableSummary";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExpressRouteCircuitsListRoutesTableSummaryOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpressRouteCircuitRoutesTableSummaryModel),
        typeof(ExpressRouteCircuitsRoutesTableSummaryListResultModel),
    };
}
