using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMGuestPatchRebootSettingConstant
{
    [Description("Always")]
    Always,

    [Description("IfRequired")]
    IfRequired,

    [Description("Never")]
    Never,
}
