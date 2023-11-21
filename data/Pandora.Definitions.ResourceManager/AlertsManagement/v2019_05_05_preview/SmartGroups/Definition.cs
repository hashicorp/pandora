using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.SmartGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "SmartGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ChangeStateOperation(),
        new GetAllOperation(),
        new GetByIdOperation(),
        new GetHistoryOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertStateConstant),
        typeof(MonitorConditionConstant),
        typeof(MonitorServiceConstant),
        typeof(SeverityConstant),
        typeof(SmartGroupModificationEventConstant),
        typeof(SmartGroupsSortByFieldsConstant),
        typeof(SortOrderConstant),
        typeof(StateConstant),
        typeof(TimeRangeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SmartGroupModel),
        typeof(SmartGroupAggregatedPropertyModel),
        typeof(SmartGroupModificationModel),
        typeof(SmartGroupModificationItemModel),
        typeof(SmartGroupModificationPropertiesModel),
        typeof(SmartGroupPropertiesModel),
    };
}
