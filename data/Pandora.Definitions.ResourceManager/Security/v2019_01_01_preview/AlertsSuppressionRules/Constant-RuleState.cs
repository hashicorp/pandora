using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.AlertsSuppressionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RuleStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Expired")]
    Expired,
}
