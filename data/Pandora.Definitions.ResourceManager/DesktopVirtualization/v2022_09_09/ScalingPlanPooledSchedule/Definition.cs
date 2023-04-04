using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.ScalingPlanPooledSchedule;

internal class Definition : ResourceDefinition
{
    public string Name => "ScalingPlanPooledSchedule";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DayOfWeekConstant),
        typeof(SessionHostLoadBalancingAlgorithmConstant),
        typeof(StopHostsWhenConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ScalingPlanPooledScheduleModel),
        typeof(ScalingPlanPooledSchedulePatchModel),
        typeof(ScalingPlanPooledSchedulePropertiesModel),
        typeof(TimeModel),
    };
}
