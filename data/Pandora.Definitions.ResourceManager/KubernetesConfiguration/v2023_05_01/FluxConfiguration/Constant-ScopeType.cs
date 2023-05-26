using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2023_05_01.FluxConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScopeTypeConstant
{
    [Description("cluster")]
    Cluster,

    [Description("namespace")]
    Namespace,
}
