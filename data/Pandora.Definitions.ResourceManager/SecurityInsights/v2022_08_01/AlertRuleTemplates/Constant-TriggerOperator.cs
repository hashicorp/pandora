using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.AlertRuleTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerOperatorConstant
{
    [Description("Equal")]
    Equal,

    [Description("GreaterThan")]
    GreaterThan,

    [Description("LessThan")]
    LessThan,

    [Description("NotEqual")]
    NotEqual,
}
