using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.MachineLearningComputes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MountStateConstant
{
    [Description("MountFailed")]
    MountFailed,

    [Description("MountRequested")]
    MountRequested,

    [Description("Mounted")]
    Mounted,

    [Description("UnmountFailed")]
    UnmountFailed,

    [Description("UnmountRequested")]
    UnmountRequested,

    [Description("Unmounted")]
    Unmounted,
}
