using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_03_01.Exports;

internal class Definition : ResourceDefinition
{
    public string Name => "Exports";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ExecuteOperation(),
        new GetOperation(),
        new GetExecutionHistoryOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExecutionStatusConstant),
        typeof(ExecutionTypeConstant),
        typeof(ExportTypeConstant),
        typeof(FormatTypeConstant),
        typeof(GranularityTypeConstant),
        typeof(RecurrenceTypeConstant),
        typeof(StatusTypeConstant),
        typeof(TimeframeTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CommonExportPropertiesModel),
        typeof(ErrorDetailsModel),
        typeof(ExportModel),
        typeof(ExportDatasetModel),
        typeof(ExportDatasetConfigurationModel),
        typeof(ExportDefinitionModel),
        typeof(ExportDeliveryDestinationModel),
        typeof(ExportDeliveryInfoModel),
        typeof(ExportExecutionListResultModel),
        typeof(ExportListResultModel),
        typeof(ExportPropertiesModel),
        typeof(ExportRecurrencePeriodModel),
        typeof(ExportRunModel),
        typeof(ExportRunPropertiesModel),
        typeof(ExportScheduleModel),
        typeof(ExportTimePeriodModel),
    };
}
