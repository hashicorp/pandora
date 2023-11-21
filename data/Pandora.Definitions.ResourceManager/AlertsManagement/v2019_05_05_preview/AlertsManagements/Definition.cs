using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

internal class Definition : ResourceDefinition
{
    public string Name => "AlertsManagements";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AlertsChangeStateOperation(),
        new AlertsGetAllOperation(),
        new AlertsGetByIdOperation(),
        new AlertsGetHistoryOperation(),
        new AlertsGetSummaryOperation(),
        new AlertsMetaDataOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertModificationEventConstant),
        typeof(AlertStateConstant),
        typeof(AlertsSortByFieldsConstant),
        typeof(AlertsSummaryGroupByFieldsConstant),
        typeof(IdentifierConstant),
        typeof(MetadataIdentifierConstant),
        typeof(MonitorConditionConstant),
        typeof(MonitorServiceConstant),
        typeof(SeverityConstant),
        typeof(SignalTypeConstant),
        typeof(SortOrderConstant),
        typeof(TimeRangeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionStatusModel),
        typeof(AlertModel),
        typeof(AlertModificationModel),
        typeof(AlertModificationItemModel),
        typeof(AlertModificationPropertiesModel),
        typeof(AlertPropertiesModel),
        typeof(AlertsMetaDataModel),
        typeof(AlertsMetaDataPropertiesModel),
        typeof(AlertsSummaryModel),
        typeof(AlertsSummaryGroupModel),
        typeof(AlertsSummaryGroupItemModel),
        typeof(CommentsModel),
        typeof(EssentialsModel),
    };
}
