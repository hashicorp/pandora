using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_03_01.ScheduledActions;

internal class Definition : ResourceDefinition
{
    public string Name => "ScheduledActions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CheckNameAvailabilityByScopeOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateByScopeOperation(),
        new DeleteOperation(),
        new DeleteByScopeOperation(),
        new GetOperation(),
        new GetByScopeOperation(),
        new ListOperation(),
        new ListByScopeOperation(),
        new RunOperation(),
        new RunByScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CheckNameAvailabilityReasonConstant),
        typeof(DaysOfWeekConstant),
        typeof(FileFormatConstant),
        typeof(ScheduleFrequencyConstant),
        typeof(ScheduledActionKindConstant),
        typeof(ScheduledActionStatusConstant),
        typeof(WeeksOfMonthConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(FileDestinationModel),
        typeof(NotificationPropertiesModel),
        typeof(SchedulePropertiesModel),
        typeof(ScheduledActionModel),
        typeof(ScheduledActionPropertiesModel),
    };
}
