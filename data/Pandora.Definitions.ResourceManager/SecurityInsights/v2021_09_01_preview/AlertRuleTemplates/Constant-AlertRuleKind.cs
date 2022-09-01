using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.AlertRuleTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertRuleKindConstant
{
    [Description("Fusion")]
    Fusion,

    [Description("MLBehaviorAnalytics")]
    MLBehaviorAnalytics,

    [Description("MicrosoftSecurityIncidentCreation")]
    MicrosoftSecurityIncidentCreation,

    [Description("NRT")]
    NRT,

    [Description("Scheduled")]
    Scheduled,

    [Description("ThreatIntelligence")]
    ThreatIntelligence,
}
