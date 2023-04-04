using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.Schedule;

internal class Definition : ResourceDefinition
{
    public string Name => "Schedule";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAutomationAccountOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CountTypeConstant),
        typeof(ScheduleDayConstant),
        typeof(ScheduleFrequencyConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdvancedScheduleModel),
        typeof(AdvancedScheduleMonthlyOccurrenceModel),
        typeof(ScheduleModel),
        typeof(ScheduleCreateOrUpdateParametersModel),
        typeof(ScheduleCreateOrUpdatePropertiesModel),
        typeof(SchedulePropertiesModel),
        typeof(ScheduleUpdateParametersModel),
        typeof(ScheduleUpdatePropertiesModel),
    };
}
