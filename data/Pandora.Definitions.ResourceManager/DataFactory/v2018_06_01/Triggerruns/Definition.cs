using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Triggerruns;

internal class Definition : ResourceDefinition
{
    public string Name => "Triggerruns";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new QueryByFactoryOperation(),
        new RerunOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RunQueryFilterOperandConstant),
        typeof(RunQueryFilterOperatorConstant),
        typeof(RunQueryOrderConstant),
        typeof(RunQueryOrderByFieldConstant),
        typeof(TriggerRunStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RunFilterParametersModel),
        typeof(RunQueryFilterModel),
        typeof(RunQueryOrderByModel),
        typeof(TriggerRunModel),
        typeof(TriggerRunsQueryResponseModel),
    };
}
