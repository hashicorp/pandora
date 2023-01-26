using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VpnGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPsecEncryptionConstant
{
    [Description("AES192")]
    AESOneNineTwo,

    [Description("AES128")]
    AESOneTwoEight,

    [Description("AES256")]
    AESTwoFiveSix,

    [Description("DES")]
    DES,

    [Description("DES3")]
    DESThree,

    [Description("GCMAES192")]
    GCMAESOneNineTwo,

    [Description("GCMAES128")]
    GCMAESOneTwoEight,

    [Description("GCMAES256")]
    GCMAESTwoFiveSix,

    [Description("None")]
    None,
}
