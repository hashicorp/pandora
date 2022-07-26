using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2018_06_01.ResetQueryPerformanceInsightData;

internal class Definition : ResourceDefinition
{
    public string Name => "ResetQueryPerformanceInsightData";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ResetQueryPerformanceInsightDataOperation(),
    };
}
