using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.SynchronizationSetting;

internal class Definition : ResourceDefinition
{
    public string Name => "SynchronizationSetting";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByShareOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(RecurrenceIntervalConstant),
        typeof(StatusConstant),
        typeof(SynchronizationSettingKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataShareErrorInfoModel),
        typeof(OperationResponseModel),
        typeof(ScheduledSynchronizationSettingModel),
        typeof(ScheduledSynchronizationSettingPropertiesModel),
        typeof(SynchronizationSettingModel),
    };
}
