using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.ScalingPlan;

internal class Definition : ResourceDefinition
{
    public string Name => "ScalingPlan";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByHostPoolOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DaysOfWeekConstant),
        typeof(ScalingHostPoolTypeConstant),
        typeof(SessionHostLoadBalancingAlgorithmConstant),
        typeof(SkuTierConstant),
        typeof(StopHostsWhenConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PlanModel),
        typeof(ScalingHostPoolReferenceModel),
        typeof(ScalingPlanModel),
        typeof(ScalingPlanPatchModel),
        typeof(ScalingPlanPatchPropertiesModel),
        typeof(ScalingPlanPropertiesModel),
        typeof(ScalingScheduleModel),
        typeof(SkuModel),
        typeof(TimeModel),
    };
}
