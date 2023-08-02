using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TargetRollingWindowSizeModeConstant
{
    [Description("Auto")]
    Auto,

    [Description("Custom")]
    Custom,
}
