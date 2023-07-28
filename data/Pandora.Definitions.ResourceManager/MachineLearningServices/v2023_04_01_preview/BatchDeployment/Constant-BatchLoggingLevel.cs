using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.BatchDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BatchLoggingLevelConstant
{
    [Description("Debug")]
    Debug,

    [Description("Info")]
    Info,

    [Description("Warning")]
    Warning,
}
