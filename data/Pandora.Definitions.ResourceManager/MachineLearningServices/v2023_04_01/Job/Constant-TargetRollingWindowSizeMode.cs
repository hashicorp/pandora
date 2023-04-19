using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TargetRollingWindowSizeModeConstant
{
    [Description("Auto")]
    Auto,

    [Description("Custom")]
    Custom,
}
