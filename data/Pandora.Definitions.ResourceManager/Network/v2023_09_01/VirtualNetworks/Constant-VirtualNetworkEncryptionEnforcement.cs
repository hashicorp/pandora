using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkEncryptionEnforcementConstant
{
    [Description("AllowUnencrypted")]
    AllowUnencrypted,

    [Description("DropUnencrypted")]
    DropUnencrypted,
}
