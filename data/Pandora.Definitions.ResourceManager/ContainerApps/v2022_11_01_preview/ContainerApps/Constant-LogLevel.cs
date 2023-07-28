using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ContainerApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogLevelConstant
{
    [Description("debug")]
    Debug,

    [Description("error")]
    Error,

    [Description("info")]
    Info,

    [Description("warn")]
    Warn,
}
