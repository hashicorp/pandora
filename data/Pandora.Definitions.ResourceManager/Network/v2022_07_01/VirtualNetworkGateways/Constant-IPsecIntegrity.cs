using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPsecIntegrityConstant
{
    [Description("GCMAES192")]
    GCMAESOneNineTwo,

    [Description("GCMAES128")]
    GCMAESOneTwoEight,

    [Description("GCMAES256")]
    GCMAESTwoFiveSix,

    [Description("MD5")]
    MDFive,

    [Description("SHA1")]
    SHAOne,

    [Description("SHA256")]
    SHATwoFiveSix,
}
