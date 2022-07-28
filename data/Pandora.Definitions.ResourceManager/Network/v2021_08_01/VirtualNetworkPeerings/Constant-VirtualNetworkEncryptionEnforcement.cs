using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkPeerings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkEncryptionEnforcementConstant
{
    [Description("AllowUnencrypted")]
    AllowUnencrypted,

    [Description("DropUnencrypted")]
    DropUnencrypted,
}
