using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.AlertRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertRuleKindConstant
{
    [Description("Fusion")]
    Fusion,

    [Description("MicrosoftSecurityIncidentCreation")]
    MicrosoftSecurityIncidentCreation,

    [Description("Scheduled")]
    Scheduled,
}
