using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.ServiceFabrics;

internal class Definition : ResourceDefinition
{
    public string Name => "ServiceFabrics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListApplicableSchedulesOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnableStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicableScheduleModel),
        typeof(ApplicableSchedulePropertiesModel),
        typeof(DayDetailsModel),
        typeof(HourDetailsModel),
        typeof(NotificationSettingsModel),
        typeof(ScheduleModel),
        typeof(SchedulePropertiesModel),
        typeof(ServiceFabricModel),
        typeof(ServiceFabricPropertiesModel),
        typeof(UpdateResourceModel),
        typeof(WeekDetailsModel),
    };
}
