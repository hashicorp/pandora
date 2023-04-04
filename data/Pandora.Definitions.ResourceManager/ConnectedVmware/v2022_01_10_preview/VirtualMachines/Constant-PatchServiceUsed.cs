using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PatchServiceUsedConstant
{
    [Description("APT")]
    APT,

    [Description("Unknown")]
    Unknown,

    [Description("WU")]
    WU,

    [Description("WU_WSUS")]
    WUWSUS,

    [Description("YUM")]
    YUM,

    [Description("Zypper")]
    Zypper,
}
