using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.ConnectedRegistries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogLevelConstant
{
    [Description("Debug")]
    Debug,

    [Description("Error")]
    Error,

    [Description("Information")]
    Information,

    [Description("None")]
    None,

    [Description("Warning")]
    Warning,
}
