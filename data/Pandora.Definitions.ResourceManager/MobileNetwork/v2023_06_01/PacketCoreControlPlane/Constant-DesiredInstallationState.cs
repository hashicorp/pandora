using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.PacketCoreControlPlane;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DesiredInstallationStateConstant
{
    [Description("Installed")]
    Installed,

    [Description("Uninstalled")]
    Uninstalled,
}
