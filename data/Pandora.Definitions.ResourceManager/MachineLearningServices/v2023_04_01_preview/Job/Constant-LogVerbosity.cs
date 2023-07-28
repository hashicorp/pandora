using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogVerbosityConstant
{
    [Description("Critical")]
    Critical,

    [Description("Debug")]
    Debug,

    [Description("Error")]
    Error,

    [Description("Info")]
    Info,

    [Description("NotSet")]
    NotSet,

    [Description("Warning")]
    Warning,
}
