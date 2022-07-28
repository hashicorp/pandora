using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum FirewallPolicyIDPSSignatureSeverityConstant
{
    [Description("1")]
    One,

    [Description("3")]
    Three,

    [Description("2")]
    Two,
}
