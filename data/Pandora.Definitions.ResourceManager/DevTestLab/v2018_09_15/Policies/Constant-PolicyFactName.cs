using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Policies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyFactNameConstant
{
    [Description("EnvironmentTemplate")]
    EnvironmentTemplate,

    [Description("GalleryImage")]
    GalleryImage,

    [Description("LabPremiumVmCount")]
    LabPremiumVMCount,

    [Description("LabTargetCost")]
    LabTargetCost,

    [Description("LabVmCount")]
    LabVMCount,

    [Description("LabVmSize")]
    LabVMSize,

    [Description("ScheduleEditPermission")]
    ScheduleEditPermission,

    [Description("UserOwnedLabPremiumVmCount")]
    UserOwnedLabPremiumVMCount,

    [Description("UserOwnedLabVmCount")]
    UserOwnedLabVMCount,

    [Description("UserOwnedLabVmCountInSubnet")]
    UserOwnedLabVMCountInSubnet,
}
