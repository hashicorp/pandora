using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ServerAdvisors;

internal class Definition : ResourceDefinition
{
    public string Name => "ServerAdvisors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByServerOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdvisorStatusConstant),
        typeof(AutoExecuteStatusConstant),
        typeof(AutoExecuteStatusInheritedFromConstant),
        typeof(ImplementationMethodConstant),
        typeof(IsRetryableConstant),
        typeof(RecommendedActionCurrentStateConstant),
        typeof(RecommendedActionInitiatedByConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdvisorModel),
        typeof(AdvisorPropertiesModel),
        typeof(RecommendedActionModel),
        typeof(RecommendedActionErrorInfoModel),
        typeof(RecommendedActionImpactRecordModel),
        typeof(RecommendedActionImplementationInfoModel),
        typeof(RecommendedActionMetricInfoModel),
        typeof(RecommendedActionPropertiesModel),
        typeof(RecommendedActionStateInfoModel),
    };
}
