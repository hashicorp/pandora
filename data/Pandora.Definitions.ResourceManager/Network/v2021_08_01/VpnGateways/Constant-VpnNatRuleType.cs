using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VpnGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnNatRuleTypeConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
