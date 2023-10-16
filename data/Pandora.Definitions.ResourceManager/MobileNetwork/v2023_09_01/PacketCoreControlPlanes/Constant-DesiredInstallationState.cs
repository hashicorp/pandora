using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.PacketCoreControlPlanes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DesiredInstallationStateConstant
{
    [Description("Installed")]
    Installed,

    [Description("Uninstalled")]
    Uninstalled,
}
