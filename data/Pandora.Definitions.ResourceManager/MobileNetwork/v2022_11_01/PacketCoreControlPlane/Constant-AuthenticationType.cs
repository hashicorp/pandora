using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlane;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationTypeConstant
{
    [Description("AAD")]
    AAD,

    [Description("Password")]
    Password,
}
