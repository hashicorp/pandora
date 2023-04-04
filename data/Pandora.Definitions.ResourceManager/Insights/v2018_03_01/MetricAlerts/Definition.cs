using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;

internal class Definition : ResourceDefinition
{
    public string Name => "MetricAlerts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AggregationTypeEnumConstant),
        typeof(CriterionTypeConstant),
        typeof(DynamicThresholdOperatorConstant),
        typeof(DynamicThresholdSensitivityConstant),
        typeof(OdatatypeConstant),
        typeof(OperatorConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DynamicMetricCriteriaModel),
        typeof(DynamicThresholdFailingPeriodsModel),
        typeof(MetricAlertActionModel),
        typeof(MetricAlertCriteriaModel),
        typeof(MetricAlertMultipleResourceMultipleMetricCriteriaModel),
        typeof(MetricAlertPropertiesModel),
        typeof(MetricAlertPropertiesPatchModel),
        typeof(MetricAlertResourceModel),
        typeof(MetricAlertResourceCollectionModel),
        typeof(MetricAlertResourcePatchModel),
        typeof(MetricAlertSingleResourceMultipleMetricCriteriaModel),
        typeof(MetricCriteriaModel),
        typeof(MetricDimensionModel),
        typeof(MultiMetricCriteriaModel),
        typeof(WebtestLocationAvailabilityCriteriaModel),
    };
}
