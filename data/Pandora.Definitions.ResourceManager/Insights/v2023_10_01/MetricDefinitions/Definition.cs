using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.MetricDefinitions;

internal class Definition : ResourceDefinition
{
    public string Name => "MetricDefinitions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
        new ListAtSubscriptionScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AggregationTypeConstant),
        typeof(MetricAggregationTypeConstant),
        typeof(MetricClassConstant),
        typeof(MetricUnitConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LocalizableStringModel),
        typeof(MetricAvailabilityModel),
        typeof(MetricDefinitionModel),
        typeof(MetricDefinitionCollectionModel),
        typeof(SubscriptionScopeMetricDefinitionModel),
        typeof(SubscriptionScopeMetricDefinitionCollectionModel),
    };
}
