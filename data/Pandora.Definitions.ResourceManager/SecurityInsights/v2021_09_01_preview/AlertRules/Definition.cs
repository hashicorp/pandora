using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.AlertRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AlertRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertDetailConstant),
        typeof(AlertRuleKindConstant),
        typeof(AlertSeverityConstant),
        typeof(AttackTacticConstant),
        typeof(EntityMappingTypeConstant),
        typeof(EventGroupingAggregationKindConstant),
        typeof(MatchingMethodConstant),
        typeof(MicrosoftSecurityProductNameConstant),
        typeof(TriggerOperatorConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AlertDetailsOverrideModel),
        typeof(AlertRuleModel),
        typeof(EntityMappingModel),
        typeof(EventGroupingSettingsModel),
        typeof(FieldMappingModel),
        typeof(FusionAlertRuleModel),
        typeof(FusionAlertRulePropertiesModel),
        typeof(GroupingConfigurationModel),
        typeof(IncidentConfigurationModel),
        typeof(MLBehaviorAnalyticsAlertRuleModel),
        typeof(MLBehaviorAnalyticsAlertRulePropertiesModel),
        typeof(MicrosoftSecurityIncidentCreationAlertRuleModel),
        typeof(MicrosoftSecurityIncidentCreationAlertRulePropertiesModel),
        typeof(NrtAlertRuleModel),
        typeof(QueryBasedAlertRulePropertiesModel),
        typeof(ScheduledAlertRuleModel),
        typeof(ScheduledAlertRulePropertiesModel),
        typeof(ThreatIntelligenceAlertRuleModel),
        typeof(ThreatIntelligenceAlertRulePropertiesModel),
    };
}
