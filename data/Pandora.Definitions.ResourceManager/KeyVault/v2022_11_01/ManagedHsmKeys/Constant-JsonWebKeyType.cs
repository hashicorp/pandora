using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.ManagedHsmKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonWebKeyTypeConstant
{
    [Description("EC")]
    EC,

    [Description("EC-HSM")]
    ECNegativeHSM,

    [Description("RSA")]
    RSA,

    [Description("RSA-HSM")]
    RSANegativeHSM,
}
