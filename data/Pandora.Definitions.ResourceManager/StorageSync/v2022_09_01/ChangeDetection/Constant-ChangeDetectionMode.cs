using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.ChangeDetection;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChangeDetectionModeConstant
{
    [Description("Default")]
    Default,

    [Description("Recursive")]
    Recursive,
}
