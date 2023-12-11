using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.Metrics;

internal class Definition : ResourceDefinition
{
    public string Name => "Metrics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
        new ListAtSubscriptionScopeOperation(),
        new ListAtSubscriptionScopePostOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(MetricResultTypeConstant),
        typeof(MetricUnitConstant),
        typeof(ResultTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LocalizableStringModel),
        typeof(MetadataValueModel),
        typeof(MetricModel),
        typeof(MetricValueModel),
        typeof(ResponseModel),
        typeof(SubscriptionScopeMetricsRequestBodyParametersModel),
        typeof(TimeSeriesElementModel),
    };
}
