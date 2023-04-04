using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Trigger;

internal class Definition : ResourceDefinition
{
    public string Name => "Trigger";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByShareSubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(RecurrenceIntervalConstant),
        typeof(StatusConstant),
        typeof(SynchronizationModeConstant),
        typeof(TriggerKindConstant),
        typeof(TriggerStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataShareErrorInfoModel),
        typeof(OperationResponseModel),
        typeof(ScheduledTriggerModel),
        typeof(ScheduledTriggerPropertiesModel),
        typeof(TriggerModel),
    };
}
