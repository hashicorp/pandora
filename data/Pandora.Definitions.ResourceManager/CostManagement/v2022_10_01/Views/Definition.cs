using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Views;

internal class Definition : ResourceDefinition
{
    public string Name => "Views";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateByScopeOperation(),
        new DeleteOperation(),
        new DeleteByScopeOperation(),
        new GetOperation(),
        new GetByScopeOperation(),
        new ListOperation(),
        new ListByScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccumulatedTypeConstant),
        typeof(ChartTypeConstant),
        typeof(ExternalCloudProviderTypeConstant),
        typeof(FunctionTypeConstant),
        typeof(KpiTypeTypeConstant),
        typeof(MetricTypeConstant),
        typeof(OperatorTypeConstant),
        typeof(PivotTypeTypeConstant),
        typeof(QueryColumnTypeConstant),
        typeof(ReportConfigSortingTypeConstant),
        typeof(ReportGranularityTypeConstant),
        typeof(ReportTimeframeTypeConstant),
        typeof(ReportTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(KpiPropertiesModel),
        typeof(PivotPropertiesModel),
        typeof(ReportConfigAggregationModel),
        typeof(ReportConfigComparisonExpressionModel),
        typeof(ReportConfigDatasetModel),
        typeof(ReportConfigDatasetConfigurationModel),
        typeof(ReportConfigDefinitionModel),
        typeof(ReportConfigFilterModel),
        typeof(ReportConfigGroupingModel),
        typeof(ReportConfigSortingModel),
        typeof(ReportConfigTimePeriodModel),
        typeof(ViewModel),
        typeof(ViewPropertiesModel),
    };
}
