using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.AutoscaleAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "AutoscaleAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AutoscaleSettingsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ComparisonOperationTypeConstant),
        typeof(MetricStatisticTypeConstant),
        typeof(OperationTypeConstant),
        typeof(PredictiveAutoscalePolicyScaleModeConstant),
        typeof(RecurrenceFrequencyConstant),
        typeof(ScaleDirectionConstant),
        typeof(ScaleRuleMetricDimensionOperationTypeConstant),
        typeof(ScaleTypeConstant),
        typeof(TimeAggregationTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoscaleNotificationModel),
        typeof(AutoscaleProfileModel),
        typeof(AutoscaleSettingModel),
        typeof(AutoscaleSettingResourceModel),
        typeof(AutoscaleSettingResourcePatchModel),
        typeof(EmailNotificationModel),
        typeof(MetricTriggerModel),
        typeof(PredictiveAutoscalePolicyModel),
        typeof(RecurrenceModel),
        typeof(RecurrentScheduleModel),
        typeof(ScaleActionModel),
        typeof(ScaleCapacityModel),
        typeof(ScaleRuleModel),
        typeof(ScaleRuleMetricDimensionModel),
        typeof(TimeWindowModel),
        typeof(WebhookNotificationModel),
    };
}
