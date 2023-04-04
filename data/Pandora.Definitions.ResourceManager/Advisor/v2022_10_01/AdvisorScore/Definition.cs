using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.AdvisorScore;

internal class Definition : ResourceDefinition
{
    public string Name => "AdvisorScore";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AggregatedConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdvisorScoreEntityModel),
        typeof(AdvisorScoreEntityPropertiesModel),
        typeof(AdvisorScoreResponseModel),
        typeof(ScoreEntityModel),
        typeof(TimeSeriesEntityTimeSeriesInlinedModel),
    };
}
