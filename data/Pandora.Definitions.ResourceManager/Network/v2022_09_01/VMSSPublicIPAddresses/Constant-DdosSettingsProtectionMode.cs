using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.VMSSPublicIPAddresses;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DdosSettingsProtectionModeConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("VirtualNetworkInherited")]
    VirtualNetworkInherited,
}
