using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionAlgorithmConstant
{
    [Description("AES192")]
    AESOneNineTwo,

    [Description("AES128")]
    AESOneTwoEight,

    [Description("AES256")]
    AESTwoFiveSix,

    [Description("DES3")]
    DESThree,

    [Description("None")]
    None,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("RC2")]
    RCTwo,
}
