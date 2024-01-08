using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnNatRuleModeConstant
{
    [Description("EgressSnat")]
    EgressSnat,

    [Description("IngressSnat")]
    IngressSnat,
}
