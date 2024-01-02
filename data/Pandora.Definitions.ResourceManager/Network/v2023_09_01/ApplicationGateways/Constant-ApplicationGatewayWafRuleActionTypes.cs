using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayWafRuleActionTypesConstant
{
    [Description("Allow")]
    Allow,

    [Description("AnomalyScoring")]
    AnomalyScoring,

    [Description("Block")]
    Block,

    [Description("Log")]
    Log,

    [Description("None")]
    None,
}
