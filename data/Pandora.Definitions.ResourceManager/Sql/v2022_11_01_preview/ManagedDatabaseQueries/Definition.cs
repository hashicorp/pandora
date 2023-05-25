using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedDatabaseQueries;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedDatabaseQueries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByQueryOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(QueryMetricUnitTypeConstant),
        typeof(QueryTimeGrainTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedInstanceQueryModel),
        typeof(QueryMetricIntervalModel),
        typeof(QueryMetricPropertiesModel),
        typeof(QueryPropertiesModel),
        typeof(QueryStatisticsModel),
        typeof(QueryStatisticsPropertiesModel),
    };
}
