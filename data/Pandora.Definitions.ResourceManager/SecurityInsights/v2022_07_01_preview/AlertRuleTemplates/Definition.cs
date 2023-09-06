using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.AlertRuleTemplates;

internal class Definition : ResourceDefinition
{
    public string Name => "AlertRuleTemplates";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertRuleKindConstant),
        typeof(AlertSeverityConstant),
        typeof(AttackTacticConstant),
        typeof(EntityMappingTypeConstant),
        typeof(EventGroupingAggregationKindConstant),
        typeof(MicrosoftSecurityProductNameConstant),
        typeof(TemplateStatusConstant),
        typeof(TriggerOperatorConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AlertDetailsOverrideModel),
        typeof(AlertRuleTemplateModel),
        typeof(AlertRuleTemplateDataSourceModel),
        typeof(EntityMappingModel),
        typeof(EventGroupingSettingsModel),
        typeof(FieldMappingModel),
        typeof(FusionAlertRuleTemplateModel),
        typeof(FusionAlertRuleTemplatePropertiesModel),
        typeof(FusionTemplateSourceSettingModel),
        typeof(FusionTemplateSourceSubTypeModel),
        typeof(FusionTemplateSubTypeSeverityFilterModel),
        typeof(MLBehaviorAnalyticsAlertRuleTemplateModel),
        typeof(MLBehaviorAnalyticsAlertRuleTemplatePropertiesModel),
        typeof(MicrosoftSecurityIncidentCreationAlertRuleTemplateModel),
        typeof(MicrosoftSecurityIncidentCreationAlertRuleTemplatePropertiesModel),
        typeof(NrtAlertRuleTemplateModel),
        typeof(NrtAlertRuleTemplatePropertiesModel),
        typeof(ScheduledAlertRuleTemplateModel),
        typeof(ScheduledAlertRuleTemplatePropertiesModel),
        typeof(ThreatIntelligenceAlertRuleTemplateModel),
        typeof(ThreatIntelligenceAlertRuleTemplatePropertiesModel),
    };
}
