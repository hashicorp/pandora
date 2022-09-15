using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.RestorePointCollections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsVMGuestPatchModeConstant
{
    [Description("AutomaticByOS")]
    AutomaticByOS,

    [Description("AutomaticByPlatform")]
    AutomaticByPlatform,

    [Description("Manual")]
    Manual,
}
