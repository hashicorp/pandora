using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.Machines;

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
