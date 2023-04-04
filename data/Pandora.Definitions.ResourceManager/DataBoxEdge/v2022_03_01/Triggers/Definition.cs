using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Triggers;

internal class Definition : ResourceDefinition
{
    public string Name => "Triggers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDataBoxEdgeDeviceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(TriggerEventTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FileEventTriggerModel),
        typeof(FileSourceInfoModel),
        typeof(FileTriggerPropertiesModel),
        typeof(PeriodicTimerEventTriggerModel),
        typeof(PeriodicTimerPropertiesModel),
        typeof(PeriodicTimerSourceInfoModel),
        typeof(RoleSinkInfoModel),
        typeof(TriggerModel),
    };
}
