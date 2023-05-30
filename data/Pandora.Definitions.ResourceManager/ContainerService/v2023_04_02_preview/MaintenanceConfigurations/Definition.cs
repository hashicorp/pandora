using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_04_02_preview.MaintenanceConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "MaintenanceConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByManagedClusterOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(TypeConstant),
        typeof(WeekDayConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AbsoluteMonthlyScheduleModel),
        typeof(DailyScheduleModel),
        typeof(DateSpanModel),
        typeof(MaintenanceConfigurationModel),
        typeof(MaintenanceConfigurationPropertiesModel),
        typeof(MaintenanceWindowModel),
        typeof(RelativeMonthlyScheduleModel),
        typeof(ScheduleModel),
        typeof(TimeInWeekModel),
        typeof(TimeSpanModel),
        typeof(WeeklyScheduleModel),
    };
}
