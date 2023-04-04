using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Forecast;

internal class Definition : ResourceDefinition
{
    public string Name => "Forecast";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExternalCloudProviderUsageOperation(),
        new UsageOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExternalCloudProviderTypeConstant),
        typeof(ForecastOperatorTypeConstant),
        typeof(ForecastTimeframeConstant),
        typeof(ForecastTypeConstant),
        typeof(FunctionNameConstant),
        typeof(FunctionTypeConstant),
        typeof(GranularityTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ForecastAggregationModel),
        typeof(ForecastColumnModel),
        typeof(ForecastComparisonExpressionModel),
        typeof(ForecastDatasetModel),
        typeof(ForecastDatasetConfigurationModel),
        typeof(ForecastDefinitionModel),
        typeof(ForecastFilterModel),
        typeof(ForecastPropertiesModel),
        typeof(ForecastResultModel),
        typeof(ForecastTimePeriodModel),
    };
}
