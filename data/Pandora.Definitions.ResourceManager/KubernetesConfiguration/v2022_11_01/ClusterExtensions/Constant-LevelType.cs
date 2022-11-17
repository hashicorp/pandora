using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.ClusterExtensions;

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
