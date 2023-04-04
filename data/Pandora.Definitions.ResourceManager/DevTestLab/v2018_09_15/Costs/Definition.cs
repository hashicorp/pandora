using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Costs;

internal class Definition : ResourceDefinition
{
    public string Name => "Costs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CostThresholdStatusConstant),
        typeof(CostTypeConstant),
        typeof(ReportingCycleTypeConstant),
        typeof(TargetCostStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CostThresholdPropertiesModel),
        typeof(LabCostModel),
        typeof(LabCostDetailsPropertiesModel),
        typeof(LabCostPropertiesModel),
        typeof(LabCostSummaryPropertiesModel),
        typeof(LabResourceCostPropertiesModel),
        typeof(PercentageCostThresholdPropertiesModel),
        typeof(TargetCostPropertiesModel),
    };
}
