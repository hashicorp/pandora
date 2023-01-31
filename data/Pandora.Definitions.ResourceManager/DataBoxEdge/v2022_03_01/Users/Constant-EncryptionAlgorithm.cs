using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Users;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionAlgorithmConstant
{
    [Description("AES256")]
    AESTwoFiveSix,

    [Description("None")]
    None,

    [Description("RSAES_PKCS1_v_1_5")]
    RSAESPKCSOneVOneFive,
}
