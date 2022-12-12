using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlanes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstallationStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Installed")]
    Installed,

    [Description("Installing")]
    Installing,

    [Description("Reinstalling")]
    Reinstalling,

    [Description("RollingBack")]
    RollingBack,

    [Description("Uninstalled")]
    Uninstalled,

    [Description("Uninstalling")]
    Uninstalling,

    [Description("Updating")]
    Updating,

    [Description("Upgrading")]
    Upgrading,
}
