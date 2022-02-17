using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.Extensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LevelTypeConstant
{
    [Description("Error")]
    Error,

    [Description("Information")]
    Information,

    [Description("Warning")]
    Warning,
}
