using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VpnServerConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IkeIntegrityConstant
{
    [Description("GCMAES128")]
    GCMAESOneTwoEight,

    [Description("GCMAES256")]
    GCMAESTwoFiveSix,

    [Description("MD5")]
    MDFive,

    [Description("SHA1")]
    SHAOne,

    [Description("SHA384")]
    SHAThreeEightFour,

    [Description("SHA256")]
    SHATwoFiveSix,
}
