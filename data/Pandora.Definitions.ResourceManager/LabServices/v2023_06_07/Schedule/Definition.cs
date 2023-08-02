using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2023_06_07.Schedule;

internal class Definition : ResourceDefinition
{
    public string Name => "Schedule";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByLabOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(RecurrenceFrequencyConstant),
        typeof(WeekDayConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RecurrencePatternModel),
        typeof(ResourceOperationErrorModel),
        typeof(ScheduleModel),
        typeof(SchedulePropertiesModel),
        typeof(ScheduleUpdateModel),
        typeof(ScheduleUpdatePropertiesModel),
    };
}
