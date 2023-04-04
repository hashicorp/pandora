using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.GuestAgents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningActionConstant
{
    [Description("install")]
    Install,

    [Description("repair")]
    Repair,

    [Description("uninstall")]
    Uninstall,
}
