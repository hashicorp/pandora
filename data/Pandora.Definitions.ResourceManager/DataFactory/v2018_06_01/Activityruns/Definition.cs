using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Activityruns;

internal class Definition : ResourceDefinition
{
    public string Name => "Activityruns";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new QueryByPipelineRunOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RunQueryFilterOperandConstant),
        typeof(RunQueryFilterOperatorConstant),
        typeof(RunQueryOrderConstant),
        typeof(RunQueryOrderByFieldConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActivityRunModel),
        typeof(ActivityRunsQueryResponseModel),
        typeof(RunFilterParametersModel),
        typeof(RunQueryFilterModel),
        typeof(RunQueryOrderByModel),
    };
}
